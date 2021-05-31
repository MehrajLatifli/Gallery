using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        
        public ObservableCollection<Files> FileList { get; set; }
        public ObservableCollection<Files> nList = new ObservableCollection<Files>();
        public MainWindow()
        {



            string Imagefilepath_1 = "Files/p1.jpg";
            FileInfo Imageinfo_1 = new FileInfo(Imagefilepath_1);
            var ImagefileFolder_1 = new DirectoryInfo(Imagefilepath_1);


            string Imagefilepath_2 = "Files/p2.jpg";
            FileInfo Imageinfo_2 = new FileInfo(Imagefilepath_2);
            var ImagefileFolder_2 = new DirectoryInfo(Imagefilepath_2);

            string Imagefilepath_3 = "Files/p3.jpg"; ;
            FileInfo Imageinfo_3 = new FileInfo(Imagefilepath_3);
            var ImagefileFolder_3 = new DirectoryInfo(Imagefilepath_3);

            string Imagefilepath_4 = "Files/p4.jpg"; ;
            FileInfo Imageinfo_4 = new FileInfo(Imagefilepath_4);
            DirectoryInfo ImagefileFolder_4 = new DirectoryInfo(Imagefilepath_4);

            FileList = new ObservableCollection<Files>
            {
                new Files
                {
                    FileName=$"{Imageinfo_1.Name}",
                    FileAddDateTime= $" Add Time: {DateTime.Now.ToLocalTime()}",
                    FilePath=Imagefilepath_1,
                    FolderofFile=$" Folder of File: {ImagefileFolder_1}",
                },

                new Files
                {
                    FileName=$"{ Imageinfo_3.Name}",
                    FileAddDateTime= $" Add Time: {DateTime.Now.ToLocalTime()}",
                    FilePath=Imagefilepath_3,
                    FolderofFile=$" Folder of File: { ImagefileFolder_3}",
                },

                new Files
                {
                    FileName=$"{Imageinfo_2.Name}",
                    FileAddDateTime= $" Add Time: {DateTime.Now.ToLocalTime()}",
                    FilePath=Imagefilepath_2,
                    FolderofFile=$" Folder of File: {ImagefileFolder_2}",
                },

                new Files
                {
                    FileName=$"{ Imageinfo_4.Name}",
                    FileAddDateTime= $" Add Time: {DateTime.Now.ToLocalTime()}",
                    FilePath=Imagefilepath_4,
                    FolderofFile=$" Folder of File: { ImagefileFolder_4}",
                },
            };

         

            this.DataContext = this;

            InitializeComponent();


       
        }

        public object selecti ;
        private void Listbox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selecti = Listbox1.SelectedItem;



            try
            {

                //var view = new AllView();

                //this.Close();
                //view.ShowDialog();

                //var all = new All();
                //all.ViewFiles = (sender as ListBox).SelectedItem as Files;

                var viewImage = new ViewImage();

                viewImage.MyData = FileList;
                viewImage.ViewFiles = Listbox1.SelectedItem as Files;
                viewImage.ShowDialog();

                //var viewImage = new ViewImage();

                //viewImage.file = (sender as ListBox).SelectedItem as Files;
                //viewImage.ShowDialog();
            }
            catch (Exception)
            {

              
            }
        }

        string imagelocation = "";


       

        void addList()
        {
            Listbox1.ItemsSource = null;

            Listbox1.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(imagelocation);

            Listbox1.ItemsSource = null;

            Listbox1.Items.Clear();

          //  List<Files> Distinct = nList.Distinct().ToList();


            FileList.Add(new Files()
            {

                FileName = $"{System.IO.Path.GetFileName(imagelocation)}",
                FileAddDateTime = $" Add Time: {DateTime.Now.ToLocalTime()}",
                FilePath = $"{ imagelocation}",
                FolderofFile = $" Folder of File: {d}",

            });




        }

        
        private void AddMenuButton_Click(object sender, RoutedEventArgs e)
        {

            AddMenuButton.IsChecked = true;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.jpg;*.png;)|*.jpg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imagelocation = openFileDialog.FileName;


                //  MessageBox.Show($"{imagelocation}");


                //  System.IO.File.Copy(imagelocation, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(imagelocation), System.IO.Path.GetFileNameWithoutExtension(imagelocation) + ".png"),true);

              

                addList();


                try
                {
                    Listbox1.ItemsSource = null;

                    Listbox1.Items.Clear();

                    foreach (var item in FileList)
                    {

                        Listbox1.Items.Add(item);

                    }

                    Listbox1.ItemsSource = FileList;
                }
                catch (Exception)
                {

                  
                }


                Listbox1.ItemsSource = null;

            }
        }

        private void EditMenuButton_Click(object sender, RoutedEventArgs e)
        {

        }


      
        private void SearchTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {



            if (string.IsNullOrEmpty(SearchTextbox.Text)==false)
            {
                Listbox1.ItemsSource = null;
                Listbox1.Items.Clear();

                foreach (var item in FileList)
                {
                    if (item.FileName.StartsWith(SearchTextbox.Text)) 
                    {
                        Listbox1.Items.Add(item);
                    }
                   Listbox1.ItemsSource = null;
                }
            }

            else
            {
                Listbox1.Items.Clear();

                foreach (var item in FileList)
                {
              
                        Listbox1.Items.Add(item);
                    

                }
            }

   
        }

        ObservableCollection<Files> MyData { get; set; }

        private void ViewMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddMenuButton.IsChecked == true)
            {

                var viewImage = new ViewImage();

                viewImage.MyData = FileList;
                viewImage.ViewFiles = Listbox1.SelectedItem as Files;


                viewImage.ShowDialog();
            }

          
        }

        private void AboutMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }
    }
}
