/*
* FILE          : Default.aspx.cs
* PROJECT       : WDD Assignment #5
* PROGRAMMERs   : Dave Yeardley
* FIRST VERSION : 2013-12-1
* DESCRIPTION   : This project is the implementation of basic text editor, that uses ASP.NET and AJAX
                  technologies. It has the ability to create, update, and read files. This file contains
                  the logic of the web app.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

//TODO
//On textChanged.


namespace TextEditor
{
    /*  Class       :  MainPage
     *  Purpose     :  This class models the a basic text editor. It allows the user to type in a text area 
     *                 and save the text to a file. Files may be created, opened and updated. This class
     *                 provides the logic for the web app.
     */
    public partial class MainPage : System.Web.UI.Page
    {
        #region Attributes
        const string folder = @"\Files\";       //The folder in which store all the text files
        private string serverPath;              //this will be the path on whichever server we are using
        #endregion

        /*  Method      :  Page-Load
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  Finds the location of the server so that the web app can
         *                 know where to save files to and get files from.
         *  Returns     : none
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            //Let's find out where we are on the server
            var root = Server.MapPath("~/");
            //Let's set the path to the folder containing the files
            ServerPath = root.ToString() + folder;
        }

        #region Properties
        public string ServerPath
        {
            get
            {
                return serverPath;
            }
            set
            {
                serverPath = value;
            }
        }
        #endregion

        #region Methods
        /*  Method      :  btnSaveFile_Click
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  Saves the contents of the notePad to the highlighted file in the listbox.
         *  Returns     :  none
         */
        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            //let's use the file that is selected in the List Box
            string file = fileList.SelectedValue.ToString();
            //in case there was an error message every button click will hide this
            lblMessage.Visible = false;
            //Was something selected?
            if (file.Length > 0)
            {
                //Yes, it is in the listbox so it is a valid file
                string path = ServerPath + file;
                //I just rewrite it all
                File.WriteAllText(path,textPad.Text);
            }
            else
            {
                //do some error checking
                lblMessage.Text = "You need to highlight a file. Click the file button to see the files";
                lblMessage.Visible = true;
            }
           
        }


        /*  Method     :  btnOpenFile_Click
        *  Parameters  :  object sender
        *                 EventArgs e
        *  Description :  Opens the highlighted file in the listbox. Prompts if nothing is highlighted.
        *  Returns     :  none
        */
        protected void btnOpenFile_Click(object sender, EventArgs e)
        {
            //in case there was an error message every button click will hide this
            lblMessage.Visible = false;
            //let's use the file that is selected in the List Box
            string file = fileList.SelectedValue.ToString();
            //Was something selected?
            if (file.Length > 0)
            {
                //Yes, it is in the listbox so it is a valid file
                string path = ServerPath + file;
                //let's put it in the textbox
               
                textPad.Text = File.ReadAllText(path);
            }
            else
            {
                //tel them how to get the file list and what to do
                lblMessage.Text = "You need to highlight a file. Click the file button to see the files";
                lblMessage.Visible = true;
            }
        }


        /*  Method     :  btnClear_Click  
        *  Parameters  :  object sender
        *                 EventArgs e
        *  Description :  Clears the text area.
        *  Returns     :  none
        */
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //in case there was an error message every button click will hide this
            lblMessage.Visible = false;
            //Are you sure?
            
            //clear the text area
            textPad.Text = "";
        }


        /*  Method     :  PopulateListBox 
        *  Parameters  :  ListBox lsb       - the listbox to poupulate
        *                 string path       - the path of the directory the files are in
        *                 string fileType   - the kinds of files to populate it with
        *  Description :  Populates a list box with all the files of a particualre type from a specified
         *                directory.
        *  Returns     :  none
        */
        private void PopulateListBox(ListBox lsb, string path, string fileType)
        {
            lsb.Items.Clear();
            //create a DirectoryInfo object using the path
            DirectoryInfo dinfo = new DirectoryInfo(path);
            //find all the files specified - in this case *.txt
            FileInfo[] Files = dinfo.GetFiles(fileType);
            //sort alphabetically
            Array.Sort(Files, delegate(FileInfo f1, FileInfo f2)
            {
                return f1.Name.CompareTo(f2.Name);
            });
            //iterate through all the files found and put them in the listbox
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
           
        }


        /*  Method      :  btnShowFiles_Click
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  Calls PopulateListBox() to show the user the files they may use.
         *  Returns     :  none
         */
        protected void btnShowFiles_Click(object sender, EventArgs e)
        {
            //in case there was an error message every button click will hide this
            lblMessage.Visible = false;
            //out with the old list
            fileList.Items.Clear();
            //in with the new list
            PopulateListBox(fileList, ServerPath, "*.*");
           
        }

        /*  Method      :  btnNewFile_Click
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  Shows the hidden elements that are used to create a new file.
         *  Returns     :  none
         */
        protected void btnNewFile_Click(object sender, EventArgs e)
        {
            

            lblMessage.Visible = true;
            lblMessage.Text = "Enter the name for the new file here";
            tbFileName.Visible = true;
            btnCreateNewFile.Visible = true;
            btnCloseNewFile.Visible = true;
        }


        /*  Method      :  createNewFile_Click
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  If something was entered it will create the file. This relies on
         *                 requiredFieldValidator since it will nly allow alphanumeric characters.
         *                 If the file exists or nothing was entered the use is informed.
         *  Returns     :  none
         */
        protected void createNewFile_Click(object sender, EventArgs e)
        {
            //in case there was an error message every button click will hide this
            lblMessage.Visible = false;
            //Get the name they entered
            string newFileName = tbFileName.Text;
           
            if (newFileName.Length > 0)
            {
                if (File.Exists(ServerPath + newFileName))
                {
                    lblMessage.Text = "That file already exists!";
                    //offer a way out
                }
                else
                {
                    //Check if it in fact it was created???
                    var newFile = File.Create(ServerPath + newFileName);
                    //close the file, always close the file Dave!
                    newFile.Close();
                    //Hide these guys
                    lblMessage.Visible = false;
                    tbFileName.Visible = false;
                    btnCreateNewFile.Visible = false;
                    btnCloseNewFile.Visible = false;
                    //Let's update the listbox
                    PopulateListBox(fileList, ServerPath, "*.*");
                }
            }
            else
            {
                lblMessage.Text = "You have to enter a name for the file!";
            }
        }


        /*  Method      :  notePad_TextChanged
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  This method is only a stub. It will be used to notify the user that there are
         *                  unsaved changes.
         *  Returns     :  none
         */
        protected void notePad_TextChanged(object sender, EventArgs e)
        {
            //This means the file is in an unsaved state!

        }


        /*  Method      :  btnCloseNewFile_Click
         *  Parameters  :  object sender
         *                 EventArgs e
         *  Description :  If the user decides they don't wish to create a new file this hides
         *                 the file create stuff.
         *  Returns     :  none
         */
        protected void btnCloseNewFile_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            tbFileName.Visible = false;
            btnCreateNewFile.Visible = false;
            btnCloseNewFile.Visible = false;
        }

        #endregion
    }
}