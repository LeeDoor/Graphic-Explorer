using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public class Explorer
    {
        private DriveInfo[] drives;
        public string Path { get; set; } = "";

        public Explorer()
        {
            this.drives = DriveInfo.GetDrives();
        }

        public string[] SetFilesAndFolders()
        {
            if (Path == "")
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
                return Directory.GetFileSystemEntries(Path);
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
    }
}
