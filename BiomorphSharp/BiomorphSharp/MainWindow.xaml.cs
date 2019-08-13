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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiomorphSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController mainController;

        public MainWindow()
        {
            InitializeComponent();
            mainController = new MainController();

            mainController.Reproduce(new Biomorph());
            DisplayImages();
        }

        private void Biomorph_OnClick(object sender, RoutedEventArgs e)
        {
            mainController.Reproduce((Biomorph)((Button) sender).Tag);
        }

        private void DisplayImages()
        {
            Image00.Background = mainController.Biomorph[0,0].Brush;
            Image00.Tag = mainController.Biomorph[0,0];

            //Image10
            //Image20
            //Image40
            //Image50
            //Image60

            //Image01
            //Image61

            //Image02
            //Image62

            //Image03
            //Image63

            //Image04
            //Image14
            //Image24
            //Image44
            //Image54
            //Image64

        }
    }
}
