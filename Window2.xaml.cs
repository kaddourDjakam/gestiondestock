using appswindows.user_controle;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace appswindows
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public static emplyees Emplyee { set; get; }
        public Window2()
        {
            InitializeComponent();

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
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            gestion_stockEntities td1 = new gestion_stockEntities();
                if (user.Text != string.Empty && pass.Password != string.Empty)
                {
                    var users= td1.emplyees.FirstOrDefault(a => a.login_emp.Equals(user.Text));
                    if(users!=null)
                    {
                        if(users.password_emp.Equals(pass.Password))
                        {
                        Emplyee = users;
                        Window1 ls = new Window1();
                        ls.Show();
                        ls.nime.Text = "";
                        ls.nime.Text = users.nom;
                        ls.sec.Text = users.prenom;
                        this.Hide();



                        ls.imuser.ImageSource = users.image_emp != null ? ByteToImage(users.image_emp): ls.imuser.ImageSource;
                        }
                        else
                        {
                        eror.Text = "";
                        eror.Text = "mod de passe and Nom d'utilisateur not correct !";
                        eror.Visibility = Visibility.Visible;
                        error.Visibility = Visibility.Visible;
                        }
                    }else
                {
                    eror.Text = "";
                    eror.Text = "entrer le mod pass et Nom d'utilisateur";
                    eror.Visibility = Visibility.Visible;
                    error.Visibility = Visibility.Visible;
                }
                }
                else
                {
                eror.Text = "";
                eror.Text = "entrer le mod pass et Nom d'utilisateur";
                eror.Visibility = Visibility.Visible;
                error.Visibility = Visibility.Visible;

            }if(user.Text == string.Empty && pass.Password != string.Empty)
            {
                eror.Text = "";
                eror.Text = "entrer Nom d'utilisateur";
                eror.Visibility = Visibility.Visible;
                error.Visibility = Visibility.Visible;
            }
        }

    }
    }
