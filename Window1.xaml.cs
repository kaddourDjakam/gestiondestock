using appswindows.user_controle;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace appswindows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            StartClock();
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            datet.Text = DateTime.Now.ToString(@"hh:mm:ss");
            datee.Text = DateTime.Now.ToString(@"d/MMM/yyyy");
        }

    

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 ls = new Window2();
            ls.Show();
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlCustomers();

                    GridMain.Children.Add(usc);
                    break;
                case "dashboard":
                    usc = new dashboard();
                   
                    GridMain.Children.Add(usc);
                    break;
                case "client":
                    usc = new UserControlCustomers();

                    GridMain.Children.Add(usc);
                    break;
                case "emploiyee":
                    usc = new UserControluser();
                    GridMain.Children.Add(usc);
                    break;
                case "fournisseur":
                    usc = new UserControlProviders();
                    GridMain.Children.Add(usc);
                    break;
                case "produit":
                    usc = new UserControl1();
                    GridMain.Children.Add(usc);
                    break;
                case "achat":
                    usc = new achattt();
                    GridMain.Children.Add(usc);
                    break;
                case "sales":
                    usc = new sales();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(3));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        
        string prod;
        gestion_stockEntities td1 = new gestion_stockEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            usc = new sales();

            GridMain.Children.Add(usc);     
            try
            {
                var users = td1.achats.FirstOrDefault(a => a.qte_achat <= 0);
                if (users != null)
                {
                    this.prod = users.produits.nom_produit;
                    notr.Visibility = Visibility.Visible;
                }
            }catch(Exception ex)
            {

            }

        }

        private void ext_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void notr_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var users = td1.achats.FirstOrDefault(a => a.qte_achat <= 0);
            if(users!=null)
            {
                if (notr.Visibility == Visibility.Hidden)
                {
                    notifier.ShowSuccess("il'ya pas erour");
                }
                else
                {
                    notifier.ShowError(prod + " Finira bientôt");
                    notr.Visibility = Visibility.Hidden;
                }
            }
           

        }
    }
 }

