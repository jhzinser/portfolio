/** Rename Utility App
  * 
  * Author: Jeremy Zinser 
  * 
  * Description: This program can navigate through the folders on the user's system and display
  * all files within, labeling them as either folders or files. When in a folder, the user can
  * rename its non-directory contents en masse. The user may set a filter so that only files with
  * certain names and/or extensions are filtered. The new filenames are also based on settings the
  * user chooses.
  * 
  * Written: 1/7/2019
  * Refactored: 6/13/2023
  */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PathTooLong;

namespace RenameUtility
{
    public partial class Form1 : Form
    {
        LinkedList<string> filepathList;
        string currentPath;
        string[] allDriveLetters;
        Image fileIcon;
        Image folderIcon;


        /// <summary>
        /// Initializes the form, populates the Drives shortcut menu, and shows the contents of either the C drive or the first drive alphabetically.
        /// </summary>
        public Form1()
        {
            //Get the drives and populate the DrivesComboBox with them.
            InitializeComponent();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            allDriveLetters = new string[allDrives.Length];
            for (var i = 0; i < allDrives.Length; i++)
            {
                allDriveLetters[i] = allDrives[i].Name.Replace("\\", "");
                DrivesComboBox.Items.Add(allDriveLetters[i]);
            }

            //Get all the filepaths of the C drive,
            //or the first drive letter if C: does not exist.
            filepathList = new LinkedList<string>();
            if (allDriveLetters.Contains("C:"))
            {
                filepathList.AddLast("C:");
                currentPath = "C:\\";
            }
            else if (allDriveLetters.Length > 0)
            {
                filepathList.AddLast(allDriveLetters[0]);
                currentPath = allDriveLetters[0];
            }

            //Set the file and folder icons and clear the Data View.
            fileIcon = imageList1.Images[0];
            folderIcon = imageList1.Images[1];

            FileDataView.Rows.Clear();
            FolderNamesBox.Items.Clear();

            //Refresh the directory.
            RefreshDirectory();
        }

        /// <summary>
        /// When a drive in the Drives Combo Box is selected, jumps to that drive in the File Data View..
        /// </summary>
        /// <param name="sender">Stock Visual Studio parameter.</param>
        /// <param name="e">Stock Visual Studio parameter.</param>
        private void DrivesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrivesComboBox.Items.Contains(DrivesComboBox.Text))
            {
                filepathList.Clear();
                filepathList.AddLast(DrivesComboBox.Text);
                DrivesComboBox.Text = string.Empty;
                RefreshDirectory();
            }
        }

        /// <summary>
        /// Navigates to a folder that's double clicked in the File Data View.
        /// </summary>
        /// <param name="sender">Stock Visual Studio parameter.</param>
        /// <param name="e">Stock Visual Studio parameter.</param>
        private void FileDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (FileDataView.Rows.Count > row)
            {
                //Check if the item is a folder.
                if (FolderNamesBox.Items.Contains(FileDataView.Rows[row].Cells[1].Value))
                {
                    filepathList.AddLast(FileDataView.Rows[row].Cells[1].Value.ToString());
                    RefreshDirectory();
                }
            }

        }
        
        /// <summary>
        /// Refreshes the File Data View.
        /// </summary>
        private void RefreshDirectory()
        {
            //Back up the old path and make the new path.
            var oldPath = currentPath + "";
            var makePath = string.Empty;
            for (var i = 0; i < filepathList.Count; i++)
            {
                makePath = makePath + filepathList.ElementAt(i) + "\\";
            }
            currentPath = makePath;

            FileDataView.Rows.Clear();
            FolderNamesBox.Items.Clear();

            var scanner = new FileSystemScanner();
            DirectoryLabel.Text = currentPath;

            try
            {
                //Get the data for the new directory.
                var dirData = scanner.EnumerateDirectoryContents(currentPath);

                for (var i = 0; i < dirData.Count(); i++)
                {
                    if (dirData.ElementAt(i).IsDirectory)
                    {
                        FileDataView.Rows.Add(folderIcon, dirData.ElementAt(i).Name);
                        FolderNamesBox.Items.Add(dirData.ElementAt(i).Name);
                    }
                }
                for (var i = 0; i < dirData.Count(); i++)
                {
                    if (!dirData.ElementAt(i).IsDirectory)
                    {
                        FileDataView.Rows.Add(fileIcon, dirData.ElementAt(i).Name);
                    }
                }

            }
            catch
            {
                //If navigation fails, return to the old directory.
                MessageBox.Show("Could not access the selected directory.");
                currentPath = oldPath;
                var returnToFilepathArray = oldPath.Split('\\');
                filepathList.Clear();
                for (var i = 0; i < returnToFilepathArray.Length; i++)
                {
                    if (returnToFilepathArray[i] != string.Empty)
                    {
                        filepathList.AddLast(returnToFilepathArray[i]);
                    }
                }
                DirectoryLabel.Text = oldPath;

                var dirData = scanner.EnumerateDirectoryContents(currentPath);

                for (var i = 0; i < dirData.Count(); i++)
                {
                    if (dirData.ElementAt(i).IsDirectory)
                    {
                        FileDataView.Rows.Add(folderIcon, dirData.ElementAt(i).Name);
                        FolderNamesBox.Items.Add(dirData.ElementAt(i).Name);
                    }
                }
                for (var i = 0; i < dirData.Count(); i++)
                {
                    if (!dirData.ElementAt(i).IsDirectory)
                    {
                        FileDataView.Rows.Add(fileIcon, dirData.ElementAt(i).Name);
                    }
                }

            }

        }

        /// <summary>
        /// Moves to the parent folder in the File Data View when the Up button is clicked.
        /// </summary>
        /// <param name="sender">Stock Visual Studio parameter.</param>
        /// <param name="e">Stock Visual Studio parameter.</param>
        private void upButton_Click(object sender, EventArgs e)
        {
            if (filepathList.Count > 1)
            {
                filepathList.RemoveLast();
                RefreshDirectory();
            }
        }

        /// <summary>
        /// Allows the user to jump to a manually selected folder.
        /// </summary>
        /// <param name="sender">Stock Visual Studio parameter.</param>
        /// <param name="e">Stock Visual Studio parameter.</param>
        private void JumpToFolderButton_Click(object sender, EventArgs e)
        {
            var openFolder = new FolderBrowserDialog();
            DialogResult result = openFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(openFolder.SelectedPath);

                var jumpToFilepathArray = openFolder.SelectedPath.Split('\\');
                filepathList.Clear();
                for (var i = 0; i < jumpToFilepathArray.Length; i++)
                {
                    if (jumpToFilepathArray[i] != string.Empty)
                    {
                        filepathList.AddLast(jumpToFilepathArray[i]);
                    }
                }
                RefreshDirectory();
            }
        }

        /// <summary>
        /// Initiates a bulk renaming operation after confirming that the user wants to do so.
        /// </summary>
        /// <param name="sender">Stock Visual Studio parameter.</param>
        /// <param name="e">Stock Visual Studio parameter.</param>
        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (currentPath.Equals("C:\\"))
            {
                //Don't do a mass rename on the C drive! That's a very bad idea!
                MessageBox.Show("Don't do a mass rename on the C drive! That's a very bad idea!");
                return;
            }
            DialogResult result = MessageBox.Show("It is recommended to back up your files first.", "Really rename?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DoRename();
            }
            RefreshDirectory();
        }

        /// <summary>
        /// Renames every item that matches the filters according to the parameters set in the form.
        /// It gets the filepaths to rename first before doing any renaming, 
        /// because renaming a file may change its order in the FileData object.
        /// Recursively calls itself for subfolders.
        /// </summary>
        /// <param name="pathIn">Used when DoRename is called recursively to determine the correct filepath for subfolders.</param>
        /// <param name="scanner">Used when DoRename is called recursively to avoid making excess Scanner objects.</param>
        /// <param name="initialized">Used to determine if this is the parent or child DoRename method.</param>
        /// <returns></returns>
        private List<string[]> DoRename(string pathIn = "", FileSystemScanner scanner = null, bool parent = true)
        {
            if (parent) //Subfolders inherit the scanner from the parent.
            {
                scanner = new FileSystemScanner();
            }
            var count = (int)NumRenameStart.Value;
            var increment = (int)NumRenameIncrement.Value;
            var pathPairs = new List<string[]>(); 
            //This always has 2 strings; dirData changes as you edit files, so you have to edit them last

            try
            {

                string workingCurrentDirectory;
                if (pathIn.Equals(string.Empty))
                {
                    workingCurrentDirectory = currentPath;
                }
                else
                {
                    workingCurrentDirectory = pathIn;
                }

                var dirData = scanner.EnumerateDirectoryContents(workingCurrentDirectory);

                for (var i = 0; i < dirData.Count(); i++)
                {
                    string workingCurrentPath = workingCurrentDirectory + dirData.ElementAt(i).Name;

                    if (CheckBoxSubfolders.Checked && dirData.ElementAt(i).IsDirectory)
                    {
                        //Console.WriteLine(workingCurrentPath + "\\");
                        var newPathPairs = DoRename(workingCurrentPath + "\\", scanner, false);
                        for (var j = 0; j < newPathPairs.Count; j++)
                        {
                            pathPairs.Add(newPathPairs.ElementAt(j));
                        }
                    }

                    if (dirData.ElementAt(i).IsDirectory)
                    {
                        continue;
                    }
                    
                    var filename = dirData.ElementAt(i).Name;
                    //Get Extension.
                    var indexOfLastPeriod = filename.LastIndexOf(".");
                    string justName, extension;
                    if (indexOfLastPeriod < 0)
                    {
                        extension = string.Empty;
                        justName = filename;
                    }
                    else
                    {
                        extension = filename.Substring(indexOfLastPeriod);
                        justName = filename.Substring(0, indexOfLastPeriod);
                    }
                    //Console.WriteLine(extension + "|" + justName);

                    //Run filters.
                    if (!CheckFilters(justName, extension))
                    {
                        continue;
                    }

                    //Construct the new filename.
                    var newFilename = TextRenamePrefix.Text + count + TextRenameSuffix.Text;

                    if (KeepExtCheckBox.Checked)
                    {
                        newFilename = newFilename + extension;
                    }
                    bool checkForExistingFiles = true;
                    while (checkForExistingFiles)
                    {
                        var added = string.Empty;
                        if (scanner.Exists(workingCurrentDirectory + newFilename))
                        {
                            added = "_c";
                            if (KeepExtCheckBox.Checked)
                            {
                                newFilename = TextRenamePrefix.Text + count + TextRenameSuffix.Text + added + extension;
                            }
                            else
                            {
                                newFilename = TextRenamePrefix.Text + count + TextRenameSuffix.Text + added;
                            }
                        }
                        else
                        {
                            checkForExistingFiles = false;
                        }
                    }

                    string newFilepath;
                    newFilepath = workingCurrentDirectory + newFilename;

                    count = count + increment;

                    //Add the next path pair.
                    var nextPair = new string[2];
                    nextPair[0] = workingCurrentPath;
                    nextPair[1] = newFilepath;
                    pathPairs.Add(nextPair);
                }

                if (parent)
                {
                    finishRename(pathPairs);
                }

            }
            catch
            {

            }
            return pathPairs;
        }
        
        /// <summary>
        /// Takes the list of path pairs created by DoRename and renames files accordingly.
        /// </summary>
        /// <param name="pairsIn">The list of path pairs contained in the parent DoRename.</param>
        private void finishRename(List<string[]> pairsIn)
        {
            //This is the actual renaming step. Take the pathPairs, and for each of them, do the Rename.
            var manager = new FileSystemManager();
            for (var i = 0; i < pairsIn.Count; i++)
            {
                Console.WriteLine(pairsIn.ElementAt(i)[0] + ", " + pairsIn.ElementAt(i)[1]);
                manager.Copy(pairsIn.ElementAt(i)[0], pairsIn.ElementAt(i)[1]);
                manager.Delete(pairsIn.ElementAt(i)[0]);
            }
        }


        /// <summary>
        /// Returns true if the item passes the filters set in the form. Returns false if not.
        /// </summary>
        /// <param name="nameToCheck">The file's name, minus the extension.</param>
        /// <param name="extToCheck">The file's extension (such as .txt or .dcm).</param>
        /// <returns></returns>
        private bool CheckFilters(string nameToCheck, string extToCheck)
        {
            if (TextFilenameFilter.Text.Equals(string.Empty) & TextExtensionBox.Text.Equals(string.Empty))
            {
                return true;
            }

            //Check the name.
            if ((BtnFilenameContains.Checked && !nameToCheck.Contains(TextFilenameFilter.Text)) ||
                (BtnFilenameMatches.Checked && !nameToCheck.Equals(TextFilenameFilter.Text) && !TextFilenameFilter.Text.Equals(string.Empty)) ||
                (BtnFilenameStartsWith.Checked && !nameToCheck.StartsWith(TextFilenameFilter.Text)) ||
                (BtnFilenameEndsWith.Checked && !nameToCheck.EndsWith(TextFilenameFilter.Text)) )
            {
                return false;
            }

            //Check the extension.
            //Remove periods to check extension properly.
            var workingExtToCheck = "" + extToCheck;
            var checkAgainstExt = "" + TextExtensionBox.Text;

            workingExtToCheck = workingExtToCheck.Replace(".", "");
            checkAgainstExt = checkAgainstExt.Replace(".", "");
            if ((BtnExtensionContains.Checked && !workingExtToCheck.Contains(checkAgainstExt)) ||
                (BtnExtensionMatches.Checked && !workingExtToCheck.Equals(checkAgainstExt) && !checkAgainstExt.Equals(string.Empty)) ||
                (BtnExtensionStartsWith.Checked && !workingExtToCheck.StartsWith(checkAgainstExt)) ||
                (BtnExtensionEndsWith.Checked && !workingExtToCheck.EndsWith(checkAgainstExt)))
            {
                return false;
            }
            
            return true;
        }
    }
}
