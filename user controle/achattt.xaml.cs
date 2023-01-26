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

namespace appswindows.user_controle
{
    /// <summary>
    /// Interaction logic for achattt.xaml
    /// </summary>
    public partial class achattt : UserControl
    {
        public achattt()
        {
            InitializeComponent();
        }
        gestion_stockEntities ls = new gestion_stockEntities();
        gestion_stockEntities td1 = new gestion_stockEntities();
        private void dataachat_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid();
        }
        public void datagrid()
        {
            dataachat.ItemsSource = ls.achats.Select(p => new
            {
                p.date_achat,
                p.qte_achat,
                nom_produit = ls.produits.Where(c => c.id_produit == p.id_produit).Select(c => c.nom_produit).FirstOrDefault()
,
                nom_fourniseur = ls.fornisuers.Where(c => c.id_fornisuer == p.id_fornisuer).Select(c => c.nom_fourniseur).FirstOrDefault(),
                login_emp = ls.emplyees.Where(c => c.id_emp == p.id_emp).Select(c => c.login_emp).FirstOrDefault(),
              
            }).ToList();
            dataachat.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "" || produit1.SelectedItem == null || qt.Text == ""  || forni.SelectedItem == null )
            {
                tools.vide mm = new tools.vide();
                mm.Show();
            }
            else
            {


                achats lr = new achats();
                string nm_prod = produit1.SelectionBoxItem.ToString();
                var prod = ls.produits.SingleOrDefault(a => a.nom_produit.Equals(nm_prod));
                if (prod != null)
                {
                    int id_prod = prod.id_produit;
                    var ach = ls.achats.FirstOrDefault(a => a.id_produit.Equals(id_prod));
                    if (ach != null)
                    {
                        id.Text = ach.id_achat.ToString();
                        ach.id_achat = int.Parse(id.Text);
                        ach.qte_achat = int.Parse(qt.Text) + ach.qte_achat;
                        ach.date_achat = DateTime.Now;
                        string combo2 = forni.SelectionBoxItem.ToString();
                        var users2 = td1.fornisuers.FirstOrDefault(a => a.nom_fourniseur.Equals(combo2));
                        ach.id_fornisuer = users2.id_fornisuer;
                        int idm = Window2.Emplyee.id_emp;
                        ach.id_emp = idm;
                        ls.SaveChanges();
                        accpet lm = new accpet();
                        lm.textp.Text = "";
                        lm.textp.Text = "achat est accepte";
                        lm.Show();
                        datagrid();                  }
                    else
                    {
                        int ids = int.Parse(id.Text);
                        var emp1 = td1.achats.Where(a => a.id_achat == ids).Count();
                        if (emp1 == 0)
                        {
                            lr.id_achat = ids;
                            lr.qte_achat = int.Parse(qt.Text);
                            lr.date_achat =DateTime.Now;
                            string combo1 = produit1.SelectionBoxItem.ToString();
                            var users = td1.produits.FirstOrDefault(a => a.nom_produit.Equals(combo1));
                            lr.id_produit = users.id_produit;
                            string combo2 = forni.SelectionBoxItem.ToString();
                            var users2 = td1.fornisuers.FirstOrDefault(a => a.nom_fourniseur.Equals(combo2));
                            lr.id_fornisuer = users2.id_fornisuer;
                            int idm = Window2.Emplyee.id_emp;
                            lr.id_emp = idm ;
                            td1.achats.Add(lr);
                            td1.SaveChanges();
                            accpet lm = new accpet();
                            lm.textp.Text = "";
                            lm.textp.Text = "achat est accepte";
                            lm.Show();
                            datagrid();
                        }
                    }
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "achat n'est pas accepte";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

    

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            int max;
            max = td1.achats.Max(p => (int?)p.id_achat) ?? 0;
            max = max + 1;
            id.Text = max.ToString();
        }

        private void forni_Loaded(object sender, RoutedEventArgs e)
        {
            forni.ItemsSource = td1.fornisuers.Select(p => p.nom_fourniseur).ToList();

        }

        private void produit_Loaded(object sender, RoutedEventArgs e)
        {
            produit1.ItemsSource = td1.produits.Select(p => p.nom_produit).ToList();
        }

        private void produit1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_Loaded_1(object sender, RoutedEventArgs e)
        {
            int nmb = td1.achats.Max(p => (int?)p.id_achat) ?? 0;
            numberproduit.Text = nmb.ToString();
            int finnn = td1.achats.Where(a => a.qte_achat == 0).Count();
            fin.Text = finnn.ToString();

        }

        private void dataachat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            object item = dataachat.SelectedItem;
            string m = (dataachat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            int stk = int.Parse(m);
            int x = (stk * 100) / 5000;
            borsontage.Text = x.ToString() + "%";

        }

        private void dataachat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataachat.SelectedItem;
            string m = (dataachat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            int stk = int.Parse(m);
            int x = (stk * 100) / 5000;
            borsontage.Text = x.ToString() + "%";

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (cosearch.Text.Equals("Nom produit"))
            {
                var prod = td1.produits.FirstOrDefault(p => p.nom_produit.Equals(datasearch.Text));
                if (prod != null)
                {    this.dataachat.ItemsSource = td1.achats.Where(k => k.id_produit.Equals(prod.id_produit)).Select(p => new
                    {
                        p.date_achat,
                        p.qte_achat,
                        nom_produit = datasearch.Text,
                        nom_fourniseur = p.produits.nom_produit,
                        login_emp = p.emplyees.login_emp,
                    }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "achat n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            else
            {
                int i = int.Parse(datasearch.Text);
                var prod = td1.achats.FirstOrDefault(p => p.id_achat.Equals(i));
                if (prod != null)
                {
                    this.dataachat.ItemsSource = td1.achats.Where(k => k.id_achat.Equals(i)).Select(p => new
                    {
                        p.date_achat,
                        p.qte_achat,
                        nom_produit = p.produits.nom_produit,
                        nom_fourniseur = p.produits.nom_produit,
                    }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "achat n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }

            }
        }

        private void datasearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (datasearch.Text.Equals(""))
            {
                datagrid();
                
            }
        }
    }
}

