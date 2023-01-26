using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace appswindows.user_controle
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();
        }
        gestion_stockEntities td1 = new gestion_stockEntities();
        Func<ChartPoint, string> label = ChartPoint => string.Format("{0} ({1:p})", ChartPoint.Y, ChartPoint.Participation);
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SeriesCollection serie = new SeriesCollection();
            int l = td1.emplyees.Max(p => (int?)p.id_emp) ?? 0;
            DateTime date = DateTime.Now.Date;
            for (int i = 1; i <= l; i++)
            {
                var emps = td1.emplyees.FirstOrDefault(a => a.id_emp.Equals(i));
                if(emps!= null)
                {
                    String nom = emps.login_emp;
                    var vlst = td1.ventes.Where(p => p.id_emp.Equals(i) && p.date_vente.Equals(date)).Select(p => p.prix_vente).ToList();
                    decimal sum = vlst.Sum();
                    serie.Add(new PieSeries() { Title = nom, Values = new ChartValues<decimal> { sum }, DataLabels = true, LabelPoint = label });
                    prchart1.Series = serie;
              }      
            }
            prchart1.LegendLocation = LegendLocation.Bottom;
           data_vent.ItemsSource = td1.ventes.Select(p => new
            {
                p.date_vente,
                p.qentity_vente,
                nom_produit = td1.produits.Where(c => c.id_produit == p.id_produit).Select(c => c.nom_produit).FirstOrDefault()
           ,
                nom_client = td1.clients.Where(c => c.id_client == p.id_client).Select(c => c.nom_client).FirstOrDefault(),
                login_emp = td1.emplyees.Where(c => c.id_emp == p.id_emp).Select(c => c.login_emp).FirstOrDefault(),
                p.prix_vente
            }).ToList();
            var qt = td1.achats.Select(p => p.qte_achat).ToList();
            int qtee = qt.Sum();
            qte.Text = qtee.ToString();
            var pr = td1.produits.Select(p => p.id_produit);
            int countpr = pr.Count();
            prod.Text = countpr.ToString();
            var cl = td1.clients.Select(p => p.id_client);
            int countcl = cl.Count();
            client.Text = countcl.ToString();
            var eml = td1.emplyees.Select(p => p.id_emp);
            int countemp = eml.Count();
            emplyeesss.Text = countemp.ToString();
            var forss = td1.fornisuers.Select(p => p.id_fornisuer);
            int countfor = forss.Count();
            forniseurss.Text = countfor.ToString();
            var slt = td1.ventes.Select(p => p.prix_vente).ToList();
            decimal totsl = slt.Sum();
            totsl = (decimal)System.Math.Round(totsl, 1);
            salestout.Text = totsl.ToString();
            
        }
        private ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
        decimal max = 0;
        int idss;
        int nbr = 0;
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            decimal vsum;
            int l = td1.emplyees.Max(p => (int?) p.id_emp) ?? 0;
            for (int i = 1; i <= l; i++)
            {
                var vlst = td1.ventes.Where(p => p.id_emp.Equals(i)).Select(p => p.prix_vente).ToList();
                vsum = vlst.Sum();
                if (max < vsum && nbr<vlst.Count())
                {
                    max = vsum;
                    nbr = vlst.Count;
                    idss = i;
                }
                else
                {
                    max = 0;
                    nbr = 0;
                    idss = i;
                }
            }
            var emms = td1.emplyees.Where(p =>p.id_emp.Equals(idss)).First();
            if (emms != null)
            {
                id.Text = idss.ToString();
                name.Text = emms.nom + " "+emms.prenom;
                emplyeess.ImageSource = emms.image_emp != null? ByteToImage(emms.image_emp): emplyeess.ImageSource;
                catigo.Text = emms.type_emp;
            }
            else
            {
                id.Text = " ";
                name.Text = " ";
                emplyeess.ImageSource = null;
                catigo.Text = " ";
            }
            var ven  = td1.ventes.Where(p=>p.id_emp.Equals(idss)).Select(p => p.prix_vente).ToList();
            if(ven != null)
            {
                decimal si = ven.Sum();
                si = (decimal)System.Math.Round(si, 1);
                xemp.Text = si.ToString();
                nmbrprod.Text = ven.Count().ToString();
            }
            else
            {
                xemp.Text = "0";
                nmbrprod.Text = "0";
            }

        }

       
    }
}
