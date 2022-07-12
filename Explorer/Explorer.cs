﻿using System;
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
    }
}
