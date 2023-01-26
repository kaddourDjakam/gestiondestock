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

namespace appswindows
{
    /// <summary>
    /// Interaction logic for UserControluser.xaml
    /// </summary>
    public partial class UserControluser : UserControl
    {
        gestion_stockEntities td1 = new gestion_stockEntities();
        public UserControluser()
        {
            InitializeComponent();
            countemp.Text = "";
            countemp.Text = td1.emplyees.Count().ToString();

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }       
        private void dataemp_Loaded(object sender, RoutedEventArgs e)
        {
            data_grid();
        }
        public void data_grid()
        {
            dataemp.ItemsSource = td1.emplyees.Select(p => new { p.id_emp, p.image_emp, p.nom, p.prenom, p.Ntele }).ToList();

        }
        string source = "";

        private void addClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                source = op.FileName.ToString();
                picbox.ImageSource = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            UserControluser usercont = new UserControluser();
            byte[] image = null;
            if (source == "")
            {
                MessageBox.Show("add picture of emplyee");
            }
            else
            {
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
            }
            emplyees ls = new emplyees();
            gestion_stockEntities td1 = new gestion_stockEntities();
            int ids = int.Parse(id.Text);
            var emp = td1.emplyees.Where(a => a.id_emp == ids).Count();
            if (emp == 0)
            {
                ls.id_emp = int.Parse(id.Text);
                ls.login_emp = usernime.Text;
                ls.password_emp = password.Password;
                ls.nom = nime.Text;
                ls.Ntele = int.Parse(telephone.Text);
                ls.type_emp = ((ComboBoxItem)catigo.SelectedItem).Content.ToString();
                ls.image_emp = image;
                ls.prenom = second.Text;
                td1.emplyees.Add(ls);
                td1.SaveChanges();
                data_grid();
                accpet lm = new accpet();
                lm.Show();
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.acp.Visibility = Visibility.Hidden;
                lm.bacp.Visibility = Visibility.Hidden;
                lm.textp.Text = "";
                lm.textp.Text = "emplyee n'est pas accepte";
                lm.@ref.Visibility = Visibility.Visible;
                lm.bref.Visibility = Visibility.Visible;
            }
        }

        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            byte[] image = null;
            if (source == "")
            {
                MessageBox.Show("add picture of emplyee");
            }
            else
            {
                FileStream stream = new FileStream(source, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
            }
            gestion_stockEntities td1 = new gestion_stockEntities();
            int ids = int.Parse(id.Text);
            emplyees emp = td1.emplyees.Where(a => a.id_emp == ids).First();
            emp.id_emp=ids;
            emp.nom =nime.Text;
            emp.login_emp=usernime.Text;
            emp.Ntele = int.Parse(telephone.Text);
            emp.image_emp = image;
            emp.prenom  = second.Text ;
            emp.password_emp = password.Password  ;
            emp.type_emp = ((ComboBoxItem)catigo.SelectedItem).Content.ToString();
            td1.Entry(emp).State = EntityState.Modified;
            td1.SaveChanges();
            accpet lm = new accpet();
            lm.Show();
            lm.textp.Text = "";
            lm.textp.Text = "emplyee a est modifier";
            data_grid();
        }
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            gestion_stockEntities td1 = new gestion_stockEntities();
            int max = td1.emplyees.Max(p => (int?)p.id_emp) ?? 0 + 1;
            id.Text = (max + 1).ToString();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dataemp.SelectedItem;
                string m = (dataemp.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int idsss = int.Parse(m);
                var em1 = td1.emplyees.SingleOrDefault(b => b.id_emp == idsss) ;
                if (em1 != null)
                {
                    id.Text = em1.id_emp.ToString();
                    nime.Text = em1.nom;
                    usernime.Text = em1.login_emp;
                    telephone.Text = em1.Ntele.ToString();
                    picbox.ImageSource = ByteToImage(em1.image_emp);
                    second.Text = em1.prenom;
                    password.Password = em1.password_emp;
                    catigo.SelectedItem = em1.type_emp;

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

        private void btnsup_Click(object sender, RoutedEventArgs e)
        {

            object item = dataemp.SelectedItem;
            string m = (dataemp.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int idss = int.Parse(m);
            var ach = td1.achats.Where(p => p.id_emp.Equals(idss));
            if (ach!=null)
            {
                foreach (achats achc in ach)
                {
                    td1.achats.Remove(achc);
                }
                td1.SaveChanges();
            }
           
            var emmmps = td1.emplyees.Where(b => b.id_emp == idss).First();
            if(emmmps!= null)
            {
                td1.emplyees.Remove(emmmps);
                try
                {
                    td1.SaveChanges();
                    data_grid();
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
            
        }

        private void dataemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataemp.SelectedItem;
            string m = (dataemp.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int stk = int.Parse(m);
            DateTime date = DateTime.Now.Date; 
            var empp = td1.ventes.Where(p => p.id_emp.Equals(stk)&& p.date_vente.Equals(date));
             if(empp != null)
            {
                int countt = empp.Count();
                salee.Text = countt.ToString();
                var emp = td1.ventes.Where(p => p.id_emp.Equals(stk) && p.date_vente.Equals(date)).Select(a => (decimal?)a.prix_vente).Sum() ?? 0;
                decimal ls = emp;
                nbrsal.Text = ls.ToString();
            }
            else
            {
                salee.Text = "0";
            }
        }

        private void dataemp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataemp.SelectedItem;
            string m = (dataemp.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int stk = int.Parse(m);
            DateTime date = DateTime.Now.Date; 
            var empp = td1.ventes.Where(p => p.id_emp.Equals(stk) && p.date_vente.Equals(date));
            if(empp != null)
            {
                int countt = empp.Count();
                salee.Text = countt.ToString();
                var emp = td1.ventes.Where(p => p.id_emp.Equals(stk) && p.date_vente.Equals(date)).Select(a=> (decimal?)a.prix_vente).Sum() ?? 0;
                decimal ls = emp;
                nbrsal.Text = ls.ToString();
            }
            else
            {
                salee.Text = "0";
            }
            
        }

        private void datasearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (datasearch.Text.Equals(""))
            {
                data_grid();
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if(cosearch.Text.Equals("Nom emplyee"))
            {
             var prod = td1.emplyees.FirstOrDefault(p => p.nom.Equals(datasearch.Text));
            if (prod != null)
            {
                int i = prod.id_emp;
                    this.dataemp.ItemsSource = td1.emplyees.Where(k => k.id_emp.Equals(i)).Select(p => new { p.id_emp, p.image_emp, p.nom, p.prenom, p.Ntele }).ToList();
            }
            else
            {
                accpet lm = new accpet();
                lm.Show();
                lm.acp.Visibility = Visibility.Hidden;
                lm.bacp.Visibility = Visibility.Hidden;
                lm.textp.Text = "";
                lm.textp.Text = " Nom emplyee n'est pas existé";
                lm.@ref.Visibility = Visibility.Visible;
                lm.bref.Visibility = Visibility.Visible;
            }
            }else if (cosearch.Text.Equals("prenom"))
            {
                var prod = td1.emplyees.FirstOrDefault(p => p.prenom.Equals(datasearch.Text));
                if (prod != null)
                {
                    int i = prod.id_emp;
                    this.dataemp.ItemsSource = td1.emplyees.Where(k => k.id_emp.Equals(i)).Select(p => new { p.id_emp, p.image_emp, p.nom, p.prenom, p.Ntele }).ToList();
                }
                else
                {
                    accpet lm = new accpet();
                    lm.Show();
                    lm.acp.Visibility = Visibility.Hidden;
                    lm.bacp.Visibility = Visibility.Hidden;
                    lm.textp.Text = "";
                    lm.textp.Text = " Nom emplyee n'est pas existé";
                    lm.@ref.Visibility = Visibility.Visible;
                    lm.bref.Visibility = Visibility.Visible;
                }
            }
            
        }

        private void cosearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
