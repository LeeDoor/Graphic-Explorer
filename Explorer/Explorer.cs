using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public class Explorer
    {
        public const string EMPTYDATA = "";
        private DriveInfo[] drives;
        private string? _path;
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

        public Explorer()
        {
            drives = DriveInfo.GetDrives();
            Path = EMPTYDATA;
        }

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

        public string[] SetFilesAndFolders()
        {
            if (Path == EMPTYDATA)
            {
                string[] dri = new string[drives.Length];
                for (int i = 0; i < drives.Length; i++)
                {
                    dri[i] = drives[i].Name;//.Substring(0, drives[i].Name.Length-1);
                }
                return dri;
            }
            try
            {
                var entries = Directory.GetFileSystemEntries(Path);
                string[] names = new string[entries.Length];
                for (int i = 0; i < entries.Length; i++)
                {
                    names[i] = CutPath(entries[i]);
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
                return SetFilesAndFolders();
            }
        }

        private string CutPath(string enter)
        {
            return enter;
        }
    }
}
