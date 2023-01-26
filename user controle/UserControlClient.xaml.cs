using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace appswindows
{
    /// <summary>
    /// Interaction logic for UserControlCustomers.xaml
    /// </summary>
    public partial class UserControlCustomers : UserControl
    {
        gestion_stockEntities td1 = new gestion_stockEntities();
        public UserControlCustomers()
        {
            InitializeComponent();
            countclient.Text = "";
            countclient.Text = td1.clients.Count().ToString();

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

        private void dataclie_Loaded(object sender, RoutedEventArgs e)
        {
            datagridv();
        }
        public void datagridv()
        {
            dataclie.ItemsSource = td1.clients.Select(p => new { p.id_client, p.image, p.nom_client, p.adress_client, p.tele_client }).ToList();

        }
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "" || nime.Text == "" || adress.Text == "" || telephone.Text == null  )
            {
                notifier.ShowWarning("il'ya colum vide !");
            }
            int ids = int.Parse(id.Text);
            var result = td1.clients.SingleOrDefault(b => b.id_client == ids);
            if (result != null)
            {
                byte[] image = null;
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                result.nom_client = nime.Text;
                result.adress_client = adress.Text;
                result.tele_client = telephone.Text;
                result.prenom = prenom.Text;
                result.image = image;
                td1.clients.Attach(result);
                td1.Entry(result).State = EntityState.Modified;
                td1.SaveChanges();
                accpet lm = new accpet();
                lm.Show();
                lm.textp.Text = "";
                lm.textp.Text = "client a est modifier";
                datagridv();
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.textp.Text = "";
                lm.textp.Text = "client n'esxiste pas";
            }
        }
        string source = "";
        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            UserControluser usercont = new UserControluser();
            byte[] image = null;
            if (source != "")
            {
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                if (stream.Equals(null))
                {
                    MessageBox.Show("ajouter l'image ");
                }
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
            }
            
            clients ls = new clients();
            int ids = int.Parse(id.Text);
            var forni = td1.clients.Where(a => a.id_client == ids).Count();
            if (forni == 0)
            {
                ls.id_client = ids;
                ls.nom_client = nime.Text;
                ls.prenom = prenom.Text;
                ls.tele_client = telephone.Text;
                ls.adress_client = adress.Text;
                ls.image = image;
                td1.clients.Add(ls);
                td1.SaveChanges();
                accpet lm = new accpet();
                lm.Show();
                notifier.ShowSuccess("Success");
                datagridv();
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.acp.Visibility = Visibility.Hidden;
                lm.bacp.Visibility = Visibility.Hidden;
                lm.textp.Text = "";
                lm.textp.Text = "client n'est pas accepte";
                lm.@ref.Visibility = Visibility.Visible;
                lm.bref.Visibility = Visibility.Visible;
            }
        }

        
        private void ajouterphot(object sender, RoutedEventArgs e)
        {
              OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                source = op.FileName.ToString();
                clinetph.ImageSource = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if(csearch.Text.Equals("nom client"))
            {
                var prod = td1.clients.FirstOrDefault(p => p.nom_client.Equals(txtresh.Text));
                if (prod != null)
                {
                    int i = prod.id_client;
                    this.dataclie.ItemsSource = td1.clients.Where(k => k.id_client.Equals(i)).Select(p => new { p.id_client, p.image, p.nom_client, p.adress_client, p.tele_client }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " nom client n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            else
            if(csearch.Text.Equals("id client"))
            {
                number(txtresh.Text);
                int id = int.Parse(txtresh.Text);
                var prod = td1.clients.FirstOrDefault(p => p.id_client.Equals(id));
                if (prod != null)
                {
                    this.dataclie.ItemsSource = td1.clients.Where(k => k.id_client.Equals(id)).Select(p => new { p.id_client, p.image, p.nom_client, p.adress_client, p.tele_client }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " id de client n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }else if (csearch.Text.Equals("telephone"))
            {
                number(txtresh.Text);
                int ntele = int.Parse(txtresh.Text);
                var prod = td1.clients.FirstOrDefault(p => p.tele_client.Equals(ntele));
                if (prod != null)
                {
                    this.dataclie.ItemsSource = td1.clients.Where(k => k.id_client.Equals(prod.id_client)).Select(p => new { p.id_client, p.image, p.nom_client, p.adress_client, p.tele_client }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " nimiro  de client n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            
        }
        public void number(String nmber)
        {
            string actualdata = string.Empty;
            char[] entereddata = nmber.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                    warning.Visibility = Visibility.Visible;
                }
            }
            nmber = actualdata;
        }

        private void telephone_TextChanged(object sender, TextChangedEventArgs e)
        {

            string actualdata = string.Empty;
            char[] entereddata = telephone.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    notifier.ShowWarning(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                    warning.Visibility = Visibility.Visible;
                    for (int i = 0; i <= entereddata.Length; i++)
                    {
                        if (i >= 10)
                        {
                            notifier.ShowError("Format pas existé");
                            actualdata.Replace(aChar, ' ');
                        }
                    }
                }
            }
            telephone.Text = actualdata;        
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            int max = td1.clients.Max(p => (int?)p.id_client) ?? 0 + 1;
            id.Text = (max + 1).ToString();
        }
        int i = 0;
        private void btnsup_Click(object sender, RoutedEventArgs e)
        {
                object item = dataclie.SelectedItem;
                string m = (dataclie.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int idd = int.Parse(m);
                var venteee = td1.ventes.Where(b => b.id_client == idd);
                 foreach(ventes vens in venteee)
                 {
                   td1.ventes.Remove(vens);
                 }
                 td1.SaveChanges();
                 var clientdele = td1.clients.Where(b => b.id_client == idd).First();
                 td1.clients.Attach(clientdele);
                 td1.Entry(clientdele).State = EntityState.Deleted;
            try
            {
                td1.SaveChanges();
                datagridv();
                i = i + 1;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
                MessageBox.Show(m);

        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dataclie.SelectedItem;
                string m = (dataclie.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int idss = int.Parse(m);
                var fors = td1.clients.SingleOrDefault(b => b.id_client == idss);
                if (fors != null)
                {
                    id.Text = fors.id_client.ToString();
                    nime.Text = fors.nom_client;
                    adress.Text = fors.adress_client;
                    telephone.Text = fors.tele_client;
                    prenom.Text = fors.prenom;
                    clinetph.ImageSource = ByteToImage(fors.image);
                    modifier.Visibility = Visibility.Visible;
                }
                MessageBox.Show(m);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dataclie_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataclie.SelectedItem;
            string m = (dataclie.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int stk = int.Parse(m);
            var v = td1.ventes.Where(p => p.id_client.Equals(stk));
            int counttr = v.Count();
            clineta.Text = counttr.ToString();

        }

        private void Border_Loaded_1(object sender, RoutedEventArgs e)
        {
            suppremeclient.Text = i.ToString();
        }

        private void dataclie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataclie.SelectedItem;
            string m = (dataclie.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
            int stk = int.Parse(m);
            var v = td1.ventes.Where(p => p.id_client.Equals(stk));
            if (v != null)
            {
                int counttr = v.Count();
                clineta.Text = counttr.ToString();
            }
            else
            {
                clineta.Text = "0";
            }
           
        }

        private void txtresh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtresh.Text.Equals(""))
            {
                datagridv();
            }
        }
    }
}
