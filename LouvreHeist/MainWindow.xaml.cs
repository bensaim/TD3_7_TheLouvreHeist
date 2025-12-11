using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LouvreHeist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UCDemarrage uc = new UCDemarrage();
            ZoneJeu.Content = uc;
            uc.butStart.Click += AfficherTenue;
        }

        public void ShowUCDebutRue()
        {
            ZoneJeu.Content = new UCDebutRue();
        }
        private void AfficherTenue(object sender, RoutedEventArgs e)
         {
             UCTenue uc = new UCTenue();
             ZoneJeu.Content = uc;
             uc.butValiderTenue.Click += AfficherDate;
         }

         private void AfficherDate(object sender, RoutedEventArgs e)
         {
             UCDate uc = new UCDate(this);
             ZoneJeu.Content = uc;

         }
    }
}