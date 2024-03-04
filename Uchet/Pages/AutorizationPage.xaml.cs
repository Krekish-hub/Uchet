using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Uchet.Class;
using Uchet.Controller;
using Uchet.DataFiles;

namespace Uchet.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();

            if (Properties.Settings.Default.EventSaveLogin != string.Empty)
            {
                txtLogin.Text = Properties.Settings.Default.EventSaveLogin;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.odbEnt.User.FirstOrDefault
                    (
                        x => x.Login == txtLogin.Text && x.Password == psbPassword.Password
                    );
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                    //FrameApp.frameObj.Navigate(new RegPage());
                }
                else
                {
                    UserControllerHelp.IdUser = userObj.ID;
                    UserControllerHelp.NameUser = userObj.Name;
                    switch (userObj.IDRole)
                    {
                        case 1:
                            UserControllerHelp.LoginUser = txtLogin.Text;
                            FrameApp.frameObj.Navigate(new InfoPage());
                            FrameMenu.frameMenu.Navigate(new MenuPage());
                            break;
                        //case 2:
                        //    RememberMe();
                        //    FrameApp.frmObj.Navigate(new PageTeacher());
                        //    break;
                        //case 3:
                        //    WindowDirector windowDirector = new WindowDirector();
                        //    windowDirector.Show();
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая сбор в работе приложения:" + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            //FrameApp.frameObj.Navigate(new InfoPage());

            //FrameMenu.frameMenu.Navigate(new MenuPage());
        }
    }
}
