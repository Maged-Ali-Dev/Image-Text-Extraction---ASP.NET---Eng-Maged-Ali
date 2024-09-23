using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace Image_Text_Extraction___ASP.NET___Eng_Maged_Ali
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadingLabel.Visible = false;
        }

        protected void btnSelectImage_Click(object sender, EventArgs e)
        {
            // Check if a file has been selected
            if (fileUpload.HasFile)
            {
                try
                {
                    // Get the name of the uploaded file
                    string fileName = Path.GetFileName(fileUpload.FileName);

                    // Define the path to save the uploaded file (Uploads folder inside the application)
                    string uploadFolder = Server.MapPath("~/Uploads/");

                    // Create the directory if it doesn't exist
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Combine the path and file name
                    string filePath = Path.Combine(uploadFolder, fileName);

                    // Save the uploaded file to the defined location
                    fileUpload.SaveAs(filePath);

                    // Update the ImageUrl of the imgUploaded control
                    imgUploaded.ImageUrl = "~/Uploads/" + fileName;

                    // Display success message
                    lblInstruction.ForeColor = System.Drawing.Color.Green;
                    lblInstruction.Text = "File uploaded successfully!";
                }
                catch (Exception ex)
                {
                    // Display error message if something goes wrong
                    lblInstruction.ForeColor = System.Drawing.Color.Red;
                    lblInstruction.Text = "File upload failed: " + ex.Message;
                }
            }
            else
            {
                // If no file is selected
                lblInstruction.Text = "Please select a file to upload.";
            }
        }

        protected async void btnExtractText_Click(object sender, EventArgs e)
        {
            // Ensure that the ImageUrl has been set after uploading the image
            if (!string.IsNullOrEmpty(imgUploaded.ImageUrl))
            {
                // Get the server path for the uploaded image
                string filePath = Server.MapPath(imgUploaded.ImageUrl);
                string selectedLanguage = ddlLanguage.SelectedValue;

                try
                {
                    loadingLabel.Visible = true;
                    await Task.Run(() =>
                    {
                        using (Bitmap selectedImage = new Bitmap(filePath))
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            selectedImage.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();

                            string tessDataPath = Server.MapPath("~/tessdata");

                            using (var ocrEngine = new TesseractEngine(tessDataPath, selectedLanguage, EngineMode.Default))
                            using (var pixImage = Pix.LoadFromMemory(imageBytes))
                            using (var page = ocrEngine.Process(pixImage))
                            {
                                string extractedText = page.GetText();

                                // Update UI
                                txtExtractedText.Text = extractedText;
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    lblInstruction.Text = "Error: " + ex.Message;
                }
                finally
                {
                    loadingLabel.Visible = false;
                }
            }
            else
            {
                lblInstruction.Text = "Please upload an image first.";
            }
        }




        protected void btnCopyText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExtractedText.Text))
            {
                // Use JavaScript to copy text to clipboard
                string textToCopy = HttpUtility.JavaScriptStringEncode(txtExtractedText.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "copyText", $"navigator.clipboard.writeText('{textToCopy}');", true);

                // Display success message in label
                lblInstruction.Text = "Text copied to clipboard!";
                lblInstruction.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblInstruction.Text = "No text to copy.";
                lblInstruction.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}