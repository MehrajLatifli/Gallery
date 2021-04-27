using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for ViewImage.xaml
    /// </summary>
    public partial class ViewImage : Window, INotifyPropertyChanged
    {
        private Files file;

        public Files ViewFiles { get { return file; } set { file = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(name));
            }
        }


     public   ObservableCollection<Files> MyData { get; set; }
        public ViewImage()
        {
            this.DataContext = this;

         

            InitializeComponent();
        }

        MainWindow mainwindow = new MainWindow();
        int i = 0;
        DispatcherTimer timer = new DispatcherTimer();
        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {


            //MediaElement mediaPlayer = new MediaElement();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    mediaPlayer.Source = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);

            //    mediaPlayer.LoadedBehavior = MediaState.Play;
            //    mediaPlayer.UnloadedBehavior = MediaState.Manual;

            //    mediaPlayer.Volume = 50;

            //    mediaPlayer.Play();
            //}



            slider();

         
            timer.Tick += new EventHandler(t_tick);
        }

        private void t_tick(object sender, EventArgs e)
        {
            slider();
        }

        void slider(){
            ObservableCollection<Files> NextList = mainwindow.FileList;
            //ObservableCollection<Files> NextList2 = mainwindow.nList;

            //NextList2.AddRange(NextList);


            timer.Start();

            try
            {
                   timer.Interval = new TimeSpan(0, 0, 0, 2);

                   ImageViewImage.Source = new BitmapImage(new Uri(MyData[i].FilePath, UriKind.RelativeOrAbsolute));

                    i++;

                

            }
            catch (Exception)
            {
                for (int i = 0; i < 1; i++)
                {
                    timer.Stop();
                MessageBox.Show("End of Slide", "End", MessageBoxButton.OK, MessageBoxImage.Warning);

                    break;
                }
            }
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Files> NextList = MyData;
            //List<Files> NextList2 = mainwindow.nList;

            //   NextList2.AddRange(NextList);


            i++;

            try
            {


                ImageViewImage.Source = new BitmapImage(new Uri(NextList[i].FilePath, UriKind.RelativeOrAbsolute));

                

            }
            catch (Exception)
            {
                MessageBox.Show( "End of Slide", "End", MessageBoxButton.OK, MessageBoxImage.Warning);
          
            }

        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {

            ObservableCollection<Files> PreviewList = MyData;
            //List<Files> PreviewList2 = mainwindow.nList;

            //PreviewList2.AddRange(PreviewList);

            i--;

            try
            {

                ImageViewImage.Source = new BitmapImage(new Uri(PreviewList[i].FilePath, UriKind.RelativeOrAbsolute));



            }
            catch (Exception)
            {

      
            }
        }
        private bool mediaPlayerIsPlaying = false;
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

            ObservableCollection<Files> PreviewList = mainwindow.FileList;


           // FileInfo info_1 = new FileInfo(PreviewList[1].FileName);

      
                MessageBox.Show($"{ PreviewList[1].FileName}");

    
                // Media.Source = new Uri(openFileDialog.FileName);

                //MessageBox.Show($"{ openFileDialog.FileName}");


                //Media.LoadedBehavior = MediaState.Play;
                //Media.UnloadedBehavior = MediaState.Manual;

                //var videoPath = Directory.GetCurrentDirectory();

                //Media.Source = new Uri(videoPath+PreviewList[1].FileName,UriKind.RelativeOrAbsolute);



                //Media.Volume = 50;


                //Media.Play();
        

  

        }

        
 
    }
}
