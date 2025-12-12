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
    /// Logique d'interaction pour UCDialogue.xaml
    /// </summary>
    public partial class UCDialogue : UserControl
    {
        private MainWindow _mainWindow;
        public UCDialogue(MainWindow mainWindow)
        {
            InitializeComponent();
            labDialoguePresentation.Content = MainWindow.texte[MainWindow.indiceDebutUCRue];
            MainWindow.indiceDebutUCRue++;
            _mainWindow = mainWindow;
            butMdp.Visibility = Visibility.Hidden;
        }


        private void butMdp_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCQuestion();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labDialoguePresentation.Content = "t'a bien le code des caméras ?";
            butMdp.Visibility = Visibility.Visible;
        }
    }
}
