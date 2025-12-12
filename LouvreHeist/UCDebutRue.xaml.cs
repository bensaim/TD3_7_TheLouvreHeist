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
    /// Logique d'interaction pour UCDebutRue.xaml
    /// </summary>
    public partial class UCDebutRue : UserControl
    {
        private MainWindow _mainWindow;
        public UCDebutRue(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void UCRue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labDialoguePresentation.Content = "t'a bien le code des caméras ?";
        }

        private void butMdp_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCQuestion();
        }

    }
}
