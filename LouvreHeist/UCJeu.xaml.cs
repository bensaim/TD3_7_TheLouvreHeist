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
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private static int pasSol = 8;
        private static int pasFond = 2;
        public static int vitesse = 2;
        public UCJeu()
        {
            InitializeComponent();
        }
        private void Jeu(object? sender, EventArgs e)
        {
            Deplace(imgFond1, pasFond);
            Deplace(imgFond2, pasFond);
            Deplace(imgSol1, pasSol);
            Deplace(imgSol2, pasSol);
        }
        public void Deplace(Image image, int pas)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);

            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, canvasJeu.ActualWidth);
        }

    }
}
