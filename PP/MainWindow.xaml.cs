using PP.Forms;
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

namespace PP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_UPS(object sender, RoutedEventArgs e)
        {

            SERVERAPP sERVERAPP = new SERVERAPP();
            sERVERAPP.Show();
            Close();
        }
        private void btn_SERVER(object sender, RoutedEventArgs e)
        {
            UPSAPP uPSAPP = new UPSAPP();
            uPSAPP.Show();
            Close();
        }
    }
}
