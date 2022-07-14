using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    /// <summary>
    /// form shows file or folder info
    /// </summary>
    public partial class Features : Form
    {
        /// <summary>
        /// constructor sets text fields to panels with folder and file info
        /// </summary>
        /// <param name="path">path to element</param>
        public Features (string path)
        {
            InitializeComponent();


            if (Directory.Exists(path))
            {
                SetFolderLabels(path);
            }
            else if (File.Exists(path))
            {
                SetFileLabels(path);
            }

            foreach(var data in propertyLayoutPanel.Controls)
            {
                if(data is Label label)
                {
                    label.Width = propertyLayoutPanel.Width;
                }
            }
            foreach (var data in valueLayoutPanel.Controls)
            {
                if (data is Label label)
                {
                    label.Width = valueLayoutPanel.Width;
                }
            }
        }

        private void Features_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// function counts size of folder by counting size of every file in folder
        /// </summary>
        /// <param name="path">path to folder</param>
        /// <returns>returns long data with size of folder</returns>
        private long CountFolderLength(string path)
        {
            long totalSize;
            DirectoryInfo info = new DirectoryInfo(path);
            totalSize = info.EnumerateFiles().Sum(file => file.Length);
            foreach(var folder in info.EnumerateDirectories())
            {
                totalSize += CountFolderLength(folder.FullName);
            }
            return totalSize;
        }

        /// <summary>
        /// sets all labels to folder info
        /// </summary>
        /// <param name="path">path to folder</param>
        private void SetFolderLabels(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            Label fullPath = new Label();
            fullPath.Text = path;

            Label lastWriteTime = new Label();
            lastWriteTime.Text = directory.LastWriteTime.ToString();

            Label creationTime = new Label();
            creationTime.Text = directory.CreationTime.ToString();

            Label folderLength = new Label();
            folderLength.Text = CountFolderLength(path).ToString();

            valueLayoutPanel.Controls.AddRange(new[] { fullPath, lastWriteTime, creationTime, folderLength });

            Label fullPathValue = new Label();
            fullPathValue.Text = "full path to folder: ";

            Label lastWriteTimeValue = new Label();
            lastWriteTimeValue.Text = "last write time: ";

            Label creationTimeValue = new Label();
            creationTimeValue.Text = "creation time: ";

            Label folderLengthValue = new Label();
            folderLengthValue.Text = "folder size: ";

            propertyLayoutPanel.Controls.AddRange(new[] { fullPathValue, lastWriteTimeValue, creationTimeValue, folderLengthValue });

        }

        /// <summary>
        /// sets all labels to file info
        /// </summary>
        /// <param name="path">file path</param>
        private void SetFileLabels(string path)
        {
            FileInfo file = new FileInfo(path);

            Label fullPath = new Label();
            fullPath.Text = path;

            Label lastWriteTime = new Label();
            lastWriteTime.Text = file.LastWriteTime.ToString();

            Label creationTime = new Label();
            creationTime.Text = file.CreationTime.ToString();

            Label fileLength = new Label();
            fileLength.Text = file.Length.ToString();

            valueLayoutPanel.Controls.AddRange(new[] { fullPath, lastWriteTime, creationTime, fileLength });

            Label fullPathValue = new Label();
            fullPathValue.Text = "full path to file: ";

            Label lastWriteTimeValue = new Label();
            lastWriteTimeValue.Text = "last write time: ";

            Label creationTimeValue = new Label();
            creationTimeValue.Text = "creation time: ";

            Label fileLengthValue = new Label();
            fileLengthValue.Text = "file size: ";

            propertyLayoutPanel.Controls.AddRange(new[] { fullPathValue, lastWriteTimeValue, creationTimeValue, fileLengthValue });
        }
    }
}
