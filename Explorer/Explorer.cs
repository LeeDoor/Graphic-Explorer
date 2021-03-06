using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public class Explorer
    {
        /// <summary>
        /// a string constant for a path when 
        /// the path contains nothing. for example, 
        /// when choosing a disk, our path is equal 
        /// to an empty string, that is, this constant.
        /// 
        /// константа строки для пути, когда путь ничего 
        /// не содержит. например при выборе диска наш путь 
        /// равен пустой строке, то есть этой константе.
        /// </summary>
        public const string EMPTYDATA = "";

        /// <summary>
        /// list of drives on your pc. dont unplug USB
        /// </summary>
        private DriveInfo[] drives;

        /// <summary>
        /// current path in our explorer
        /// </summary>
        private string? _path;

        /// <summary>
        /// property for correctly getting and setting path
        /// </summary>
        public string Path {
            get { 
                return _path ?? EMPTYDATA; 
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _path = value;
                }
                else if(!File.Exists(value))
                {
                    _path = EMPTYDATA;
                }
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Explorer()
        {
            drives = DriveInfo.GetDrives();
            Path = EMPTYDATA;
        }

        /// <summary>
        /// public func set path level higher
        /// </summary>
        public void SetPathToParent()
        {
            if (Path != EMPTYDATA)
            {
                var par = Directory.GetParent(Path);
                if (par != null)
                    Path = par.FullName;
                else
                    Path = EMPTYDATA;
            }
        }

        /// <summary>
        /// gets files and folders from current directory
        /// </summary>
        /// <returns>returns list of paths to elements</returns>
        public string[] GetFilesAndFolders()
        {
            if (Path == EMPTYDATA)
            {
                string[] dri = new string[drives.Length];
                for (int i = 0; i < drives.Length; i++)
                {
                    dri[i] = drives[i].Name;
                }
                return dri;
            }
            try
            {
                var entries = Directory.GetFileSystemEntries(Path);
                string[] names = new string[entries.Length];
                for (int i = 0; i < entries.Length; i++)
                {
                    names[i] = entries[i];
                }
                return names;
            }
            catch
            {
                MessageBox.Show("forbidden folder");
                var par = Directory.GetParent(Path);
                if (par != null)
                    Path = par.FullName;
                else 
                    return new string[] { }; 
                return GetFilesAndFolders();
            }
        }

        /// <summary>
        /// function creates folder with given name in current directory
        /// </summary>
        /// <param name="folderName">name of folder</param>
        public void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(Path + '\\' + folderName);
        }

        /// <summary>
        /// creates text file in current directory with given name
        /// name should contain expantion like file.txt
        /// </summary>
        /// <param name="fileName">file name</param>
        public void CreateFile(string fileName)
        {
            var file = File.Create(Path + '\\' + fileName);
            file.Dispose();
        }

        /// <summary>
        /// defines, is it file or folder, and deletes it
        /// </summary>
        /// <param name="name"></param>
        public void Delete(string name)
        {
            string path = Path + '\\' + name;
            if (Directory.Exists(path))
            {
                DeleteFolder(path);
            }
            else if (File.Exists(path))
            {
                DeleteFile(path);
            }
        }

        /// <summary>
        /// deletes folder on this path
        /// </summary>
        /// <param name="path">path to folder</param>
        private void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        /// <summary>
        /// deletes file on this path
        /// </summary>
        /// <param name="path">path to file</param>
        private void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// pastes file or folder from given directory
        /// </summary>
        /// <param name="copyBuff">directory of copying file</param>
        public void Paste(string copyBuff)
        {
            if (File.Exists(copyBuff))
            {
                FileInfo from = new FileInfo(copyBuff);
                FileInfo to = new FileInfo(Path + "\\" + from.Name);
                PasteFile(from, to);
            }
            else if (Directory.Exists(copyBuff))
            {

                DirectoryInfo from = new DirectoryInfo(copyBuff);
                DirectoryInfo to = new DirectoryInfo(Path + "\\" + from.Name);
                if (drives.Where(drive => drive.Name == from.Name || drive.Name == to.Name).FirstOrDefault() != null) return;
                string adding = "";
                while (to.Exists)
                {
                    adding += "copied ";
                    to = new DirectoryInfo(Path + "\\" + adding + from.Name);
                }
                PasteFolder(from, to);
            }
        }

        /// <summary>
        /// pastes folder to current directory
        /// </summary>
        /// <param name="from">directory of copying file</param>
        /// <param name="to">pasting directory</param>
        private void PasteFolder(DirectoryInfo from, DirectoryInfo to)
        {
            to.Create();

            try
            {
                foreach(var file in from.GetFiles())
                {
                    file.CopyTo(to.FullName + "\\" + file.Name);
                }
            }
            catch { }

            try
            {
                foreach (var folder in from.GetDirectories())
                {
                    PasteFolder(folder, new DirectoryInfo(to.FullName + "\\" + folder.Name));
                }
            }
            catch { }

        }

        /// <summary>
        /// pastes file to given directory
        /// </summary>
        /// <param name="from">directory of copying file</param>
        /// <param name="to">pasting directory</param>
        private void PasteFile(FileInfo from, FileInfo to)
        {
            string adding = "";
            DirectoryInfo toDir = new DirectoryInfo(to.Directory.FullName);
            var files = toDir.EnumerateFiles();
            while (files.Where(file=>file.FullName == to.Directory + "\\" + adding + to.Name).FirstOrDefault() != null)
            {
                adding += "copied ";
                files = toDir.EnumerateFiles();
            }
            File.Copy(from.FullName, to.Directory + "\\" + adding + to.Name);
        }
    }
}
