using AForge.Video;
using AForge.Video.DirectShow;
using appswindows.user_controle;
using appswindows.ViewModel;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ZXing;

namespace appswindows
{
    /// <summary>
    /// Interaction logic for sales.xaml
    /// </summary>
    public partial class sales : UserControl
    {
 
        
        public sales()
        {
            InitializeComponent();
            itemlists = new ObservableCollection<itemlist>();
            this.DataContext = this;
        }
        private ObservableCollection<itemlist> _itemlist;
        public ObservableCollection<itemlist> itemlists
        {
            get { return _itemlist; }
            set { _itemlist = value; }
        }

        gestion_stockEntities td1 = new gestion_stockEntities();
        
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            Window1 lb = new Window1();
            var emp = td1.emplyees.FirstOrDefault(a => a.nom.Equals(lb.nime.Text)) ;
            MessageBox.Show(lb.nime.Text);
            int maxs = max();
            ids.Text = maxs.ToString();
            for (int i = 1; i <= 100; i++)
            {
                qutitiy.Items.Add(i);
            }
        }
        public int max()
        {
            int max;
            max = td1.ventes.Max(p => (int?)p.id_vente) ?? 0;
            return max = max + 1;
        }

        private void produit_Loaded(object sender, RoutedEventArgs e)
        {
            produitt.ItemsSource = td1.produits.Select(p => p.nom_produit).ToList();

        }

        private void cliemt_Loaded(object sender, RoutedEventArgs e)
        {
            cliemt.ItemsSource = td1.clients.Select(p => p.nom_client).ToList();

        }

        private void scanner_Checked(object sender, RoutedEventArgs e)
        {
            btnscanner.Visibility = Visibility.Visible;
            maachater.IsChecked = false;
            barcod.Visibility = Visibility.Visible;
            produitt.IsEnabled = false;
            qutitiy.IsEnabled = false;
        }

        private void scanner_Unchecked(object sender, RoutedEventArgs e)
        {
            btnscanner.Visibility = Visibility.Hidden;
            barcod.Visibility = Visibility.Hidden;
            produitt.IsEnabled = true;
            qutitiy.IsEnabled = true;
            maachater.IsChecked = true;
        }
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(1),
                maximumNotificationCount: MaximumNotificationCount.FromCount(3));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        int id_produitr;
        gestion_stockEntities ls = new gestion_stockEntities();
        decimal sum = 0;
        int i=0;
        string prix_vented;
        private void ajouter2_Click(object sender, RoutedEventArgs e)
        {
            if ( produitt.SelectedItem == null || qutitiy.SelectedItem == null || cliemt.SelectedItem == null)
            {
                notifier.ShowWarning("il'ya colun vide !");
            }
            else
            {
             ventes lr = new ventes();
                int id = int.Parse(ids.Text);
                var ventss = td1.ventes.Where(a => a.id_vente == id).Count();
                string quntity;
                if (ventss == 0)
                {
                    String date = DateTime.Now.Date.ToString();
                    if(manual.IsChecked == false)
                    {
                        quntity = (this.qutitiy.SelectedItem).ToString();

                    }
                    else
                    {
                        quntity = maquteity.Text;
                    }
                    /*********** qentity vente*****/                  
                    string prod = this.produitt.SelectedItem.ToString();
                    var idsprod = td1.produits.FirstOrDefault(a => a.nom_produit.Equals(prod));
                    if (idsprod != null)
                    {
                        id_produitr = idsprod.id_produit;
                        /*********** id produit *****/
                        lr.id_produit = id_produitr;
                        this.prix_vented = idsprod.prix_vent.ToString() + " " + "DZ";
                        decimal price = idsprod.prix_vent * int.Parse(quntity);
                        price = (decimal)System.Math.Round(price, 1);
                        pritxt.Text = (price).ToString();
                        /*********** prix unitare achat *****/
                        lr.prix_unitare_achat = idsprod.prix_unitare_prod;
                        /*********** prix vente *****/
                        lr.prix_vente = idsprod.prix_vent;

                    }
                   
                    string combo2 = cliemt.SelectionBoxItem.ToString();
                    var users2 = td1.clients.FirstOrDefault(a => a.nom_client.Equals(combo2));
                    /*********** id client *****/
                    lr.id_client = users2.id_client;
                    /*********** id vente *****/
                    lr.id_vente = id;
                    /*********** id emplyee *****/
                    int idm = Window2.Emplyee.id_emp;
                    lr.id_emp = idm;
                    /*********** date vente *****/
                    lr.date_vente = DateTime.Now.Date;
                    /*********** mouvement *****/
                    lr.mouvement = (this.movement.SelectedItem as ComboBoxItem).Content.ToString();
                    /*********** produit *****/
                    lr.nom_prod = this.produitt.SelectedItem.ToString();
                    /*********** note *****/
                 
                    var qauntity = td1.achats.FirstOrDefault(a => a.id_produit.Equals(id_produitr));
                    if (qauntity != null)
                    {
                        if (qauntity.qte_achat != 0)
                        {
                            ids.Text = (int.Parse(ids.Text) + 1).ToString();

                            itemlists.Add(new itemlist()
                            {
                                idvente = id,
                                produittt = prod,
                                Quantity = quntity,
                                Price = pritxt.Text,
                                date = date
                            });
                            this.DataContext = itemlists;
                            stoutt.Text = prix_vented;
                            this.sum = this.sum + decimal.Parse(pritxt.Text);
                            toutt.Text = this.sum.ToString() + " " + "DZ";
                            lr.qentity_vente = int.Parse(quntity);
                            int quantitiy3 = qauntity.qte_achat - int.Parse(quntity);
                            qte.Text = quantitiy3.ToString();
                            qauntity.qte_achat = quantitiy3;
                            td1.SaveChanges();
                            ls.ventes.Add(lr);
                            try
                            {
                                ls.SaveChanges();
                                notifier.ShowSuccess("le venete est success");
                                this.i = this.i + 1;
                                number.Text = i.ToString();
                            }
                            catch (DbEntityValidationException ex)
                            {
                                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                                {
                                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                                    {
                                        MessageBox.Show("le produit et fin demender un neveau  quantity!");

                                    }
                                }
                            }
                        }

                        else
                        {
                            notifier.ShowError("le produit egale 0");
                        }
                    }
                }
                Clearall();
            }
            
        }
        
        public void Clearall()
        {
            qutitiy.SelectedItem = null;
            cliemt.SelectedItem = "";
            produitt.SelectedItem = null;
        }
        public void print()
        {
            factureprint ln = new factureprint();
            facture ls = new facture();
            if (i != 0)
            {
                int mx = td1.ventes.Max(p => p.id_vente);
                int id = mx - i;
                ls.SetDataSource(td1.ventes.Where(p => p.id_vente <= mx && p.id_vente > id).Select(p => new { nom_prod = p.nom_prod, mouvement = p.mouvement, qentity_vente = p.qentity_vente, prix_vente = p.prix_vente }).ToList());
                ln.view.ViewerCore.ReportSource = ls;
                ln.Show();
               
            }
            else
            {
                 notifier.ShowInformation("il'ya pas de venete");
            }
        }
        private void codepromo_Copy2_Click(object sender, RoutedEventArgs e)
        {
        }
         
 
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var resultat = reader.Decode(bitmap);
            if (resultat != null)
            {
                String barcode = resultat.ToString();
                var prods = td1.produits.FirstOrDefault(p => p.code_bare.Equals(barcode));

                if (produitt.SelectedItem == null || qutitiy.SelectedItem == null || cliemt.SelectedItem == null )
                {
                    tools.vide mm = new tools.vide();
                    mm.Show();
                }
                else
                {
                    if(prods != null)
                    {
                        ventes lr = new ventes();
                        int id = int.Parse(ids.Text);
                        var ventss = td1.ventes.Where(a => a.id_vente == id).Count();
                        if (ventss == 0)
                        {
                            String date = DateTime.Now.Date.ToString();
                            int quntity;
                            if (manual.IsChecked == null)
                            {
                                quntity = 1;

                            }
                            else
                            {
                                quntity = int.Parse(maquteity.Text);
                            }
                            /*********** qentity vente*****/
                            lr.qentity_vente = quntity;
                            string prod = prods.nom_produit;
                            produitt.Text = prods.nom_produit;
                            qutitiy.Text = "1";
                            var idsprod = td1.produits.FirstOrDefault(a => a.nom_produit.Equals(prod));
                            if (idsprod != null)
                            {
                                id_produitr = idsprod.id_produit;
                                /*********** id produit *****/
                                lr.id_produit = id_produitr;
                                stoutt.Text = idsprod.prix_vent.ToString() + " " + "DZ";
                                pritxt.Text = (idsprod.prix_vent * quntity).ToString();
                                /*********** prix unitare achat *****/
                                lr.prix_unitare_achat = idsprod.prix_unitare_prod;
                                /*********** prix vente *****/
                                lr.prix_vente = idsprod.prix_vent;
                            }
                            var qauntity = td1.achats.FirstOrDefault(a => a.id_produit.Equals(id_produitr));
                            if (qauntity != null)
                            {
                                int quantitiy3 = qauntity.qte_achat - quntity;
                                qte.Text = quantitiy3.ToString();
                                qauntity.qte_achat = quantitiy3;
                                td1.SaveChanges();
                            }
                            string combo2 = cliemt.SelectionBoxItem.ToString();
                            var users2 = td1.clients.FirstOrDefault(a => a.nom_client.Equals(combo2));
                            /*********** id client *****/
                            lr.id_client = users2.id_client;
                            /*********** id vente *****/
                            lr.id_vente = id;
                            /*********** id emplyee *****/
                            Window1 lb = new Window1();
                            var emp = td1.emplyees.FirstOrDefault(a => a.nom.Equals(lb.nime.Text));
                            lr.id_emp = emp.id_emp;
                            /*********** date vente *****/
                            lr.date_vente = DateTime.Now.Date;
                            /*********** mouvement *****/
                            lr.mouvement = (this.movement.SelectedItem as ComboBoxItem).Content.ToString();
                            ls.ventes.Add(lr);
                            try
                            {
                                ls.SaveChanges();
                                this.i = this.i + 1;
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
                            ids.Text = (int.Parse(ids.Text) + 1).ToString();

                            itemlists.Add(new itemlist()
                            {
                                produittt = prod,
                                Quantity = quntity.ToString(),
                                Price = pritxt.Text,
                                date = date
                            });

                            this.sum = this.sum + decimal.Parse(pritxt.Text);
                            toutt.Text = this.sum.ToString() + " " + "DZ";

                        }
                        Clearall();
                    }
                }
            }
        }
        private void btnscanner_Click(object sender, RoutedEventArgs e)
        {
            barcod.Focus();
        }

        private void maachater_Unchecked(object sender, RoutedEventArgs e)
        {
            scanner.IsEnabled = true;
            scanner.IsChecked = true;
            maachater.IsEnabled = false;
        }

        private void maachater_Checked(object sender, RoutedEventArgs e)
        {
            maachater.IsEnabled = true;
            scanner.IsEnabled = false;

        }

        private void manual_Checked(object sender, RoutedEventArgs e)
        {
            maquteity.IsEnabled = true;
            qutitiy.IsEnabled = false;
        }

        private void manual_Unchecked(object sender, RoutedEventArgs e)
        {
            maquteity.IsEnabled = false;
            qutitiy.IsEnabled = true;

        }
        private void modifier(object sender, RoutedEventArgs e)
        {

        }

        private void validier(object sender, RoutedEventArgs e)
        {
            if (itemlists != null)
            {
                itemlists.Clear();
                stoutt.Text = "--";
                toutt.Text = "--";
                this.i = 0;
                number.Text = "0";
                pritxt.Text = "0.0";
                qte.Text = "0";
            }
            else
            {
                notifier.ShowError("il n ya pas des vente");

            }
        }

        private void impremer(object sender, RoutedEventArgs e)
        {
            print();

        }

   
    }
}

