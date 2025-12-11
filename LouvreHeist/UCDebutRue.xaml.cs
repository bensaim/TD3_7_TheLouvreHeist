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
        public UCDebutRue()
        {
            InitializeComponent();

            this.Focusable = true;
            this.Focus();
            this.KeyDown += UCDebutRue_KeyDown;
        }


        private void UCDebutRue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                labDialoguePresentation.Content = "try try try try try";
            }
        }
    }
}
