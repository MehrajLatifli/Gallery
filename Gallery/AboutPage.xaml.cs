using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Gallery
{
    /// <summary>
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {

        List<Files> nf = new List<Files>();
        MainWindow mainWindow = new MainWindow();




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

        public AboutPage()
        {

            //nf = mainWindow.FileList;

            //MessageBox.Show($"{nf[1].FileName}")  ;

            this.DataContext = this;



            this.Loaded += new RoutedEventHandler(General1_Loaded);

            InitializeComponent();
        }




        public Window activeform = null;

        int valueFromPage1;
        public AboutPage(int val) : this()
        {
            valueFromPage1 = val;
            this.Loaded += new RoutedEventHandler(General1_Loaded);

        }


        Binding bindings = new Binding();
        private void General1_Loaded(object sender, RoutedEventArgs e)
        {



            ListBox newListbox = mainWindow.Listbox1;

            newListbox.ItemsSource = nf;

            var i = mainWindow.selecti;


            // imagebox1.Source = new BitmapImage(new Uri("Files/p1.jpg", UriKind.Relative));




            //TextBox FileNameTxtbox = new TextBox();

            //FileNameTxtbox.Background = new SolidColorBrush(Color.FromArgb(255, 37, 171, 205));
            //FileNameTxtbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 37, 191, 255));
            //FileNameTxtbox.Margin = new Thickness(5, 5, 0, 0);
            //FileNameTxtbox.FontSize = 20;

            //bindings.Path = new PropertyPath("Files.FileName");






            //FileNameTxtbox.SetBinding(TextBox.TextProperty, bindings);

            StackList.Visibility = Visibility.Visible;


            this.DataContext = this;



         //   MessageBox.Show($"{nf[1].FilePath}");
        }
    }
}
