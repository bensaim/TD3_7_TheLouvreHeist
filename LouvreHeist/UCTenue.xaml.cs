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

namespace LouvreHeist
{
    /// <summary>
    /// Logique d'interaction pour UCTenue.xaml
    /// </summary>
    public partial class UCTenue : UserControl
    {
        public UCTenue()
        {
            InitializeComponent();
            labDialoguePresentation.Content = MainWindow.DIALOGUE[MainWindow.indiceDialogue];
            MainWindow.indiceDialogue++;
        }


        private void butValiderTenue_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tenue1_Click(object sender, RoutedEventArgs e)
        {
            butValiderTenue.IsEnabled = true;
            MainWindow.Perso = "Tutu";
        }

        private void tenue2_Click(object sender, RoutedEventArgs e)
        {
            butValiderTenue.IsEnabled = true;
            MainWindow.Perso = "GiletOrange";
        }

        private void tenue3_Click(object sender, RoutedEventArgs e)
        {
            butValiderTenue.IsEnabled = true;
            MainWindow.Perso = "Emo";
        }

        private void tenue4_Click(object sender, RoutedEventArgs e)
        {
            butValiderTenue.IsEnabled = true;
            MainWindow.Perso = "Flou";
        }
    }
}
