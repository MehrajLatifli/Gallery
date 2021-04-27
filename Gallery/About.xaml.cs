using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
            Window mainWindow = new Window();
    public About()
    {
        InitializeComponent();
        //AllFrame.Content = null;

        //   AllFrame.Source = new Uri(@"https://www.youtube.com/results?search_query=root+element+is+not+valid+for+navigation+wpf", UriKind.RelativeOrAbsolute);
    }



    private void Window_Loaded(object sender, RoutedEventArgs e)
    {

        //AllView main = Application.Current.Windows.OfType<AllView>().FirstOrDefault();

        //main.AllFrame.NavigationService.Navigate(new Uri("ViewImage.xaml", UriKind.Relative));

        Page page = new Page();



        AllFrame.Source = new Uri("AboutPage.xaml", UriKind.RelativeOrAbsolute);


        try
        {

            //ViewImage viewImage = new ViewImage();


            //viewImage2.AllFrame.Source = new Uri("/Gallery;component/ViewImage.xaml", UriKind.Relative);


        }
        catch (Exception)
        {

        }

        //NavigationService nav = NavigationService.GetNavigationService(viewImage);
        //nav.Navigate(new System.Uri(@"/Gallery;component/ViewImage.xaml", UriKind.RelativeOrAbsolute));
    }


}
}
