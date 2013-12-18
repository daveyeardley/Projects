<!--
* FILE          : Default.aspx
* PROJECT       : WDD Assignment #5
* PROGRAMMERs   : Dave Yeardley
* FIRST VERSION : 2013-12-1
* DESCRIPTION   : This project is the implementation of basic text editor, that uses ASP.NET and AJAX
                  technologies. It has the ability to create, update, and read files. This file contains
                  basic elements of the page.
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TextEditor.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e-Pad</title>
    <link rel="stylesheet" type="text/css" href="styles.css"/>
</head>
<body>
   <div id="Container">
    <form id="theForm" runat="server">
    <h1>e-Pad</h1> 
        <h3>Files</h3>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate> 
                    <!--Listbox with the files -->
                    <asp:ListBox class="ListBox"  ID="fileList" runat="server" ToolTip="Highlight a file here" ></asp:ListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
                    <!--This label is used to inform the user what to do, or for error reporting -->
                    <asp:Label runat="server" Text="Enter the name of the new file: " Visible="False" ID="lblMessage"></asp:Label>
                    <!-- Elements for creating a new file. Hidden unless creating a new file -->
                    <asp:TextBox class="NewFileName" runat="server" Visible="False" ID="tbFileName"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbFileName" ErrorMessage="Alphanumeric characters only!" ValidationExpression="^[0-9a-zA-Z]*$" OnDataBinding="btnCloseNewFile_Click"></asp:RegularExpressionValidator>
                    <br />
                    <asp:Button cssClass="button" ID="btnCreateNewFile" runat="server" Text="OK" Visible="False" OnClick="createNewFile_Click" />
                    <asp:Button cssClass="button" ID="btnCloseNewFile" runat="server" Text="Cancel" Visible="False" OnClick="btnCloseNewFile_Click" />
        <div class ="ButtonContainer">
            <!--The Buttons -->
            <!--Populates the ListBox with the files -->
            <asp:Button cssClass="button" ID="btnShowFiles" runat="server" OnClick="btnShowFiles_Click" Text="Files" ToolTip="Updates the file list" />
            <!--Save the text to a file -->
            <asp:Button cssClass="button" ID="btnSaveFile" runat="server" OnClick="btnSaveFile_Click" Text="Save" ToolTip="Click to save the highlighted file" />
            <!--Open the highlighted File -->
            <asp:Button cssClass="button" ID="btnOpenFile" runat="server" OnClick="btnOpenFile_Click" Text="Open" ToolTip="Click to open the highlighted file" />
            <!--Makes the Create new File stuff visible -->
            <asp:Button cssClass="button" ID="btnNewFile" runat="server" OnClick="btnNewFile_Click" Text=" New" ToolTip="Creates a new file" />
            <!--Clears the notePad -->
            <asp:Button cssClass="button"  ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" ToolTip="Clears the text area" />
        </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate> <!-- File input and output. Only update this when opening or saving-->
                        <!--The text box for typing. Files get input from and send output to this element -->                    
                        <asp:TextBox class="TextPad" ID="textPad" runat="server"  TextMode="MultiLine" ToolTip="Write stuff here!" ></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</div>
</body>
</html>
