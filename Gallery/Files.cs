using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
   public class Files : INotifyPropertyChanged
    {
        public Files() { }
        public Files(string fileName, string fileSize, string fileAddDateTime)
        {
            FileName = fileName;
            FolderofFile = fileSize;
            FileAddDateTime = fileAddDateTime;
        }

        public Files(string fileName, string folderofFile, string fileAddDateTime, string filePath)
        {
            FileName = fileName;
            FolderofFile = folderofFile;
            FileAddDateTime = fileAddDateTime;
            FilePath = filePath;
        }

        string fileName; string folderofFile; string fileAddDateTime; string filePath;
        public string FileName { get { return fileName; } set { fileName = value; OnPropertyChanged();} }
        public string FolderofFile { get { return folderofFile; } set { folderofFile = value; OnPropertyChanged(); } }
        public string FileAddDateTime { get { return fileAddDateTime; } set { fileAddDateTime = value; OnPropertyChanged(); } }
        public string FilePath { get { return filePath; } set { filePath = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
