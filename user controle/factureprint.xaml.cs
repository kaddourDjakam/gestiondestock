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

namespace appswindows.user_controle
{
    /// <summary>
    /// Interaction logic for factureprint.xaml
    /// </summary>
    public partial class factureprint : Window
    {
        public factureprint()
        {
            InitializeComponent();
            facture ls = new facture();
            ls.Load(@"facture.rep");
        }
    }
}
