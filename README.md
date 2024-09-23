# Image Text Extraction - ASP.NET - Eng Mage-Ali

![zUntitled](https://github.com/user-attachments/assets/8f0e2f01-cfa1-41e0-82d3-63511252bf8e)


Project Overview

This ASP.NET Web Forms application allows users to upload images and extract text from them using Tesseract OCR (Optical Character Recognition). The project is designed with a modern UI using Bootstrap for styling, providing a user-friendly experience.

File Structure

1. Default.aspx: This is the main user interface where users can upload images, select languages, and view the extracted text.
2. Default.aspx.cs: This code-behind file contains the server-side logic for handling user interactions and processing the uploaded images.

Key Components

1. User Interface (Default.aspx)

- HTML Structure: The page is structured with a `<form>` that runs on the server (`runat="server"`). It includes various controls for file upload, buttons, dropdown selection, and text display.
  
- Bootstrap: The project utilizes Bootstrap for responsive design, ensuring compatibility across devices.

- Styling: Custom CSS is used to enhance the visual appeal, with a consistent color scheme and layout.

- Controls:
  - `FileUpload`: Allows users to select an image file.
  - `Button`: For uploading the selected image and triggering text extraction.
  - `Label`: Displays messages such as success or error notifications.
  - `Image`: Displays the uploaded image.
  - `DropDownList`: Lets users select the language for OCR (English or Arabic).
  - `TextBox`: Displays the extracted text, set to multiline for better visibility.
  - Additional buttons for extracting text and copying it to the clipboard.

2. Code-Behind Logic (Default.aspx.cs)

- Page_Load: Initializes the page and hides the loading label.

- btnSelectImage_Click: This event handler is triggered when the "Upload Image" button is clicked. 
  - It checks if a file has been uploaded, saves it to the server in a designated "Uploads" folder, and displays the image on the page.
  - If the upload is successful, it shows a success message; otherwise, it shows an error.

- btnExtractText_Click: Triggered when the "Extract Text" button is clicked.
  - It verifies that an image has been uploaded and retrieves the file path.
  - The selected language for OCR is also retrieved.
  - The image is processed in a separate task to avoid blocking the UI.
  - Tesseract OCR processes the image, and the extracted text is displayed in the `TextBox`.
  - The loading label is shown during processing and hidden afterward.

- btnCopyText_Click: This event handler is invoked when the "Copy Text" button is clicked.
  - It checks if there is text to copy. If so, it uses JavaScript to copy the extracted text to the clipboard and provides feedback to the user.

Key Technologies Used

- ASP.NET Web Forms: The framework used to create the web application.
- Tesseract OCR: An open-source OCR engine used to extract text from images.
- Bootstrap: A CSS framework for building responsive web designs.
- C#: The programming language used for server-side logic.

Folder Structure

- Uploads: This folder is dynamically created in the server's file system to store uploaded images.
- tessdata: Contains the language data files required by Tesseract for text extraction (should be added to the project).

User Flow

1. Upload Image: The user selects an image file and clicks "Upload Image."
2. Image Preview: The uploaded image is displayed on the page.
3. Select Language: The user selects the desired language for OCR.
4. Extract Text: The user clicks "Extract Text," triggering the OCR process.
5. Display Text: The extracted text appears in the designated text box.
6. Copy Text: The user can click "Copy Text" to copy the extracted content to the clipboard.

 
