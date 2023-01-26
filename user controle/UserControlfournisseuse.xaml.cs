using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace appswindows
{
    /// <summary>
    /// Interaction logic for UserControlProviders.xaml
    /// </summary>
    public partial class UserControlProviders : UserControl
    {
        gestion_stockEntities td1 = new gestion_stockEntities();
        public UserControlProviders()
        {
            InitializeComponent();
            numberfor.Text = "";
            numberfor.Text = td1.fornisuers.Count().ToString();
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

    
        private void datafor_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid();
        }
        public void datagrid()
        {
            datafor.ItemsSource = td1.fornisuers.Select(p => new { p.image, p.nom_fourniseur, p.address_forniseur, p.tele_forniseur }).ToList();

        }
        string source = "";
        private void suppremer_Copy_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                source = op.FileName.ToString();
                adpic3.ImageSource = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "" || nime.Text == "" || adress.Text == "" || telephone.Text == null )
            {
                tools.vide mm = new tools.vide();
                mm.Show();
            }
            else{
                UserControluser usercont = new UserControluser();
                byte[] image = null;
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                fornisuers ls = new fornisuers();
                gestion_stockEntities td1 = new gestion_stockEntities();
                int ids = int.Parse(id.Text);
                var forni = td1.fornisuers.Where(a => a.id_fornisuer == ids).Count();
                if (forni == 0)
                {
                    ls.id_fornisuer = ids;
                    ls.nom_fourniseur = nime.Text;
                    ls.tele_forniseur = telephone.Text;
                    ls.address_forniseur = adress.Text;
                    ls.prenom = prenom.Text;
                    ls.image = image;
                    td1.fornisuers.Add(ls);
                    td1.SaveChanges();
                    accpet lm = new accpet();
                    lm.Show();
                    datagrid();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = "fourniseur n'est pas accepte";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
           
        }


        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            int ids = int.Parse(id.Text);
            var result = td1.fornisuers.SingleOrDefault(b => b.id_fornisuer == ids);
            if (result != null)
            {
                byte[] image = null;
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                result.nom_fourniseur = nime.Text;
                result.address_forniseur = adress.Text;
                result.tele_forniseur = telephone.Text;
                result.image = image;
                td1.fornisuers.Attach(result);
                td1.Entry(result).State = System.Data.Entity.EntityState.Modified;
                td1.SaveChanges();
                datagrid();
                accpet lm = new accpet();
                lm.Show();
                lm.textp.Text = "";
                lm.textp.Text = "forniseur is edit";
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.textp.Text = "";
                lm.textp.Text = "forniseur not found try again";
            }
        }



        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            int max = td1.fornisuers.Max(p => (int?)p.id_fornisuer) ?? 0 + 1;
            id.Text = (max + 1).ToString();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (csearch.Text.Equals("id fornisour"))
            {
                int ids = int.Parse(datasearch.Text);
                var prod = td1.fornisuers.FirstOrDefault(p => p.id_fornisuer.Equals(ids));
                if (prod != null)
                {
                    this.datafor.ItemsSource = td1.fornisuers.Where(k => k.id_fornisuer.Equals(ids)).Select(p => new { p.image, p.nom_fourniseur, p.address_forniseur, p.tele_forniseur }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " forniseur n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            else if (csearch.Text.Equals("Nom"))
            {
                var prod = td1.fornisuers.FirstOrDefault(p => p.nom_fourniseur.Equals(datasearch.Text));
                if (prod != null)
                {
                    int ids = prod.id_fornisuer;
                    this.datafor.ItemsSource = td1.fornisuers.Where(k => k.id_fornisuer.Equals(ids)).Select(p => new { p.image, p.nom_fourniseur, p.address_forniseur, p.tele_forniseur }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " nom fornisuer n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;


                }

            }
            else if (csearch.Text.Equals("telephone"))
            {
                number(datasearch.Text);
                var prod = td1.fornisuers.FirstOrDefault(p => p.tele_forniseur.Equals(datasearch.Text));
                if (prod != null)
                {
                    int ids = prod.id_fornisuer;
                    this.datafor.ItemsSource = td1.fornisuers.Where(k => k.id_fornisuer.Equals(ids)).Select(p => new { p.image, p.nom_fourniseur, p.address_forniseur, p.tele_forniseur }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " forniseur n'est pas existé";
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
                        MessageBox.Show(aChar + " is not numeric");
                        actualdata.Replace(aChar, ' ');
                        actualdata.Trim();
                        warning.Visibility = Visibility.Visible;
                    }
                }
                telephone.Text = actualdata;
               for (int i = 0; i <= entereddata.Length; i++)
               {
                if (i >= 10)
                {
                    MessageBox.Show("format n'est pas exist");
                }
            }
        }
        int i = 0;
        private void btnsup_Click(object sender, RoutedEventArgs e)
        {

            object item = datafor.SelectedItem;
            string m = (datafor.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            var forni = td1.fornisuers.FirstOrDefault(p => p.nom_fourniseur.Equals(m));
            int idd =forni.id_fornisuer;
            var ach = td1.achats.Where(b => b.id_fornisuer == idd);
            foreach (achats ache in ach)
            {
                td1.achats.Remove(ache);
            }
            td1.SaveChanges();
            var fornidele = td1.fornisuers.Where(b => b.id_fornisuer == idd).First();
            td1.fornisuers.Attach(fornidele);
            td1.Entry(fornidele).State = System.Data.Entity.EntityState.Deleted;
            try
            {
                td1.SaveChanges();
                this.i = this.i + 1;
                datagrid();

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
                object item = datafor.SelectedItem;
                string m = (datafor.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                var fors = td1.fornisuers.SingleOrDefault(b => b.nom_fourniseur == m);
                    if(fors != null)
                {
                    id.Text = fors.id_fornisuer.ToString();
                    nime.Text = fors.nom_fourniseur;
                    adress.Text = fors.address_forniseur;
                    telephone.Text = fors.tele_forniseur;
                    adpic3.ImageSource = ByteToImage(fors.image);
                    modifier.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void datafor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = datafor.SelectedItem;
            string m = (datafor.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;  
            var forni = td1.fornisuers.FirstOrDefault(p => p.tele_forniseur.Equals(m));
            var ach = td1.achats.Where(p => p.id_fornisuer.Equals(forni.id_fornisuer));
            if(ach != null)
            {
                prdAF.Text = ach.Count().ToString();
            }
            else
            {
                prdAF.Text = "0";
            }
        }

        private void datafor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = datafor.SelectedItem;
            string m = (datafor.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            var forni = td1.fornisuers.FirstOrDefault(p => p.tele_forniseur.Equals(m));
            var ach = td1.achats.Where(p => p.id_fornisuer.Equals(forni.id_fornisuer));
            if (ach != null)
            {
                prdAF.Text = ach.Count().ToString();
            }
            else
            {
                prdAF.Text = "0";
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
