using AForge.Video;
using AForge.Video.DirectShow;
using appswindows.user_controle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        gestion_stockEntities td1 = new gestion_stockEntities();
        private void dataprod_Loaded(object sender, RoutedEventArgs e)
        {
            data_grid();
        }
        public void data_grid()
        {
            dataprod.ItemsSource = td1.produits.Select(p => new { p.id_produit, p.nom_produit, p.prix_vent, p.prix_unitare_prod, p.code_bare, p.type_produit }).ToList();

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
        byte[] imgbytes = null;
        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            randomnumber lm = new randomnumber();
            barcod.Text = lm.RandomPassword( );
            try
            {
                System.Drawing.Image img = null;
                BitmapImage bimg = new BitmapImage();
                using (var ms = new MemoryStream())
                {
                    BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.CODE_93};
                    writer.Options.Height = 100;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    img = writer.Write(this.barcod.Text);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = null;
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.barcodeim.Source = bimg;// return File(ms.ToArray(), "image/jpeg"); 
                    img.Save(ms, ImageFormat.Jpeg);
                    this.imgbytes = ms.GetBuffer();
                    data_grid();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void Border_Loaded_1(object sender, RoutedEventArgs e)
        {

            gestion_stockEntities td1 = new gestion_stockEntities();
            int max = td1.produits.Max(p => (int?)p.id_produit) ?? 0;
            id.Text = (max + 1).ToString();
            numberachat.Text = max.ToString();


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
                barcod.Text = resultat.ToString();
                barcodeim.Source = ImageSourceFromBitmap(bitmap);
            }
        }
        private void scanner(object sender, RoutedEventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[came.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        private System.Drawing.Image ByteToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
        private void printer_Click(object sender, RoutedEventArgs e)
        {
            codeprinte ls = new codeprinte();
            codbar ln = new codbar();
            object item = dataprod.SelectedItem;
            string m = (dataprod.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int idsss = int.Parse(m);
            var cod = td1.produits.Where(p => p.id_produit.Equals(idsss)).Select(p => new { nom_produit = p.nom_produit, image = p.image, code_bare = p.code_bare, prix_vent = p.prix_vent });
            ln.SetDataSource(cod.ToList());
            ls.view.ViewerCore.ReportSource = ln;
            ls.Show();
            //PrintDialog dialog = new PrintDialog();
            //if (!(bool)dialog.ShowDialog())
            //{
            //    return;
            //}
            //dialog.PrintVisual(this.barcodeim, "MyDocument");
        }

        private void ajouter_Click_1(object sender, RoutedEventArgs e)
        {
            if (nime.Text == "" || catigo.SelectedItem == null || prixuni.Text == null || prixve.Text == null || barcod.Text == "" || imgbytes == null)
            {
                notifier.ShowWarning("il'ya colum vide !");
            }
            produits ls = new produits();
            gestion_stockEntities td1 = new gestion_stockEntities();
            int ids = int.Parse(id.Text);
            var emp = td1.produits.Where(a => a.id_produit == ids).Count();
            if (emp == 0)
            {
                ls.id_produit = int.Parse(id.Text);
                ls.nom_produit = nime.Text;
                ls.prix_unitare_prod = int.Parse(prixuni.Text);
                ls.type_produit = ((ComboBoxItem)catigo.SelectedItem).Content.ToString();
                ls.prix_vent = int.Parse(prixve.Text);
                ls.code_bare = barcod.Text;
                ls.image = imgbytes;
                td1.produits.Add(ls);
                td1.SaveChanges();
                accpet lm = new accpet();
                notifier.ShowSuccess("Success");
                lm.Show();
                data_grid();
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.acp.Visibility = Visibility.Hidden;
                lm.bacp.Visibility = Visibility.Hidden;
                lm.textp.Text = "";
                lm.textp.Text = "produit n'est pas accepte";
                lm.@ref.Visibility = Visibility.Visible;
                lm.bref.Visibility = Visibility.Visible;
            }
        }
        private void check1_Checked(object sender, RoutedEventArgs e)
        {
            check2.IsEnabled = false;
            scannere.Visibility = Visibility.Hidden;
            produire.Visibility = Visibility.Visible;
            came.Visibility = Visibility.Hidden;
        }

        private void check2_Checked(object sender, RoutedEventArgs e)
        {
            check1.IsEnabled = false;
            scannere.Visibility = Visibility.Visible;
            came.Visibility = Visibility.Visible;
        }

        private void check1_Unchecked(object sender, RoutedEventArgs e)
        {
            check2.IsEnabled = true;
            produire.Visibility = Visibility.Hidden;
        }

        private void check2_Unchecked_1(object sender, RoutedEventArgs e)
        {
            check1.IsEnabled = true;
            scannere.Visibility = Visibility.Hidden;
            came.Visibility = Visibility.Hidden;
        }

        private void UserControl_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }

        private void UserControl_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in FilterInfoCollection)
                came.Items.Add(device.Name);
            came.SelectedIndex = 0;
        }

        private void dataprod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataprod.SelectedItem;
            string m = (dataprod.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int idsss = int.Parse(m);
            var venss = td1.ventes.Where(p => p.id_produit.Equals(idsss));
            if (venss != null)
            {
                qty_ah.Text = venss.Count().ToString();
            }
            else
            {
                qty_ah.Text = "0";
            }
        }

        private void dataprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataprod.SelectedItem;
            string m = (dataprod.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int idsss = int.Parse(m);
            var venss = td1.ventes.Where(p => p.id_produit.Equals(idsss));
            if (venss != null)
            {
                qty_ah.Text = venss.Count().ToString();
            }
            else
            {
                qty_ah.Text = "0";
            }
            string prix_v = (dataprod.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            double prix_ven = double.Parse(prix_v);
            string prix_a = (dataprod.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            double prix_ach = double.Parse(prix_a);
            int stk = int.Parse(m);
            double x = (prix_ach * 100) / prix_ven;
            x = (double)System.Math.Round(x, 1);
            prosontage.Text = x.ToString();

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (xsearch.Text.Equals("Nom produit"))
            {
                var prod = td1.produits.FirstOrDefault(p => p.nom_produit.Equals(datasearch.Text));
                if (prod != null)
                {
                    this.dataprod.ItemsSource = td1.produits.Where(k => k.id_produit.Equals(prod.id_produit)).Select(p => new { p.id_produit, p.nom_produit, p.prix_vent, p.prix_unitare_prod, p.code_bare, p.type_produit }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "nom de produit n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            else if(xsearch.Text.Equals("id produit"))
            {
                int i = int.Parse(datasearch.Text);
                var prod = td1.achats.FirstOrDefault(p => p.id_achat.Equals(i));
                if (prod != null)
                {
                    this.dataprod.ItemsSource = td1.produits.Where(k => k.id_produit.Equals(i)).Select(p => new { p.id_produit, p.nom_produit, p.prix_vent, p.prix_unitare_prod, p.code_bare, p.type_produit }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "produit n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }

            }else if (xsearch.Text.Equals("type"))
            {
                var prod = td1.produits.FirstOrDefault(p => p.type_produit.Equals(datasearch.Text));
                if (prod != null)
                {
                    int i = prod.id_produit;
                    this.dataprod.ItemsSource = td1.produits.Where(k => k.id_produit.Equals(i)).Select(p => new { p.id_produit, p.nom_produit, p.prix_vent, p.prix_unitare_prod, p.code_bare, p.type_produit }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " type de produit n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
        }

        private void datasearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (datasearch.Text.Equals(""))
            {
                data_grid();
            }
        }
    }
}
