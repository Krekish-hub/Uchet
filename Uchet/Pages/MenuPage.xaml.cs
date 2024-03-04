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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uchet.Class;
using Uchet.MenuControl;

namespace Uchet.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();

            if (SlideMenu.Width == 0)
            {
                animation.To = 120; // Устанавливаем ширину, на которую нужно развернуть меню
            }
            else
            {
                animation.To = 0; // Скрываем меню
            }

            animation.Duration = TimeSpan.FromSeconds(0.3);
            SlideMenu.BeginAnimation(Border.WidthProperty, animation);
        }

        private void btnZarplata_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSmena_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTabel_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new TabelPage());
        }
    }
}
