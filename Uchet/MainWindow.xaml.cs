using System;
using System.Windows;
using Uchet.Class;
using Uchet.DataFiles;
using Uchet.Pages;

namespace Uchet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OdbConnectHelper.odbEnt = new UchetDBEntities();

            FrameApp.frameObj = MainFrame;
            FrameMenu.frameMenu = MenuFrame;
            FrameApp.frameObj.Navigate(new AutorizationPage());
        }
    }
}
