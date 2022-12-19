using PP;
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
using System.Windows.Shapes;

namespace PP.Forms
{
    /// <summary>
    /// Логика взаимодействия для UPSAPP.xaml
    /// </summary>
    public partial class UPSAPP : Window
    {
        MFCEntities2 MFC;
        public UPSAPP()
        {
            MFC = new MFCEntities2();
            InitializeComponent();
            IBP_List.ItemsSource = MFC.UPSU.ToList();
            cbStatus.ItemsSource = MFC.Stat.ToList();
            cbFilter.ItemsSource = MFC.Stat.ToList();
            cbUPS.ItemsSource = MFC.UPSMod.ToList();
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {

        }

        private void filterCB(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
