<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"  Inherits="Image_Text_Extraction___ASP.NET___Eng_Maged_Ali.Default"  Async="true" %>
 

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Text Extraction - ASP.NET - Eng Maged Ali</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">
  <style>
    body {
        font-family: 'Roboto', sans-serif;
        background-color: #f4f4f4;
        color: #333;
    }
    .container {
        margin-top: 50px;
        max-width: 900px;
        background-color: #fff;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
    }

    h1, h2 {
        color: #624E88;
        text-align: center;
    }
    #btnSelectImage, #btnExtractText, #btnCopyText {
        background-color: #624E88;
        color: white;
        border: none;
        padding: 10px 20px;
        border-radius: 4px;
        margin: 10px 0;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }
    #btnSelectImage:hover, #btnExtractText:hover, #btnCopyText:hover {
        background-color: #4b3c6d;
    }
    #fileUpload, #txtExtractedText {
        width: 100%;
        padding: 10px;
        border-radius: 4px;
        border: 1px solid #ddd;
        margin-bottom: 10px;
    }
    .file-upload {
        height: 50px; /* Adjust the height as needed */
        padding: 10px; /* Adjust the padding as needed */
    }
    #txtExtractedText {
        height: 200px;
    }
    .loading-label {
        display: none;
        color: #ff6f61;
    }
    .success-message {
        color: green;
        font-weight: bold;
    }
    .error-message {
        color: red;
        font-weight: bold;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Image Text Extraction - ASP.NET - Eng Maged Ali</h2>

            <div class="form-group">
                <label for="fileUpload">Select Image:</label>
               <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control file-upload" />

            </div>

            <div class="form-group">
                <asp:Button ID="btnSelectImage" runat="server" Text="Upload Image" OnClick="btnSelectImage_Click" CssClass="btn" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblInstruction" runat="server" Text="" CssClass="success-message"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Image ID="imgUploaded" runat="server" CssClass="img-fluid" />
            </div>

            <div class="form-group">
                <label for="ddlLanguage">Select Language:</label>
                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                    <asp:ListItem Text="English" Value="eng"></asp:ListItem>
                    <asp:ListItem Text="Arabic" Value="ara"></asp:ListItem>
                    
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Button ID="btnExtractText" runat="server" Text="Extract Text" OnClick="btnExtractText_Click" CssClass="btn" />
            </div>

            <div class="form-group">
                <asp:Label ID="loadingLabel" runat="server" Text="Extracting text, please wait..." CssClass="loading-label"></asp:Label>
            </div>

            <div class="form-group">
                <label for="txtExtractedText">Extracted Text:</label>
                <asp:TextBox ID="txtExtractedText" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btnCopyText" runat="server" Text="Copy Text" OnClick="btnCopyText_Click" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
