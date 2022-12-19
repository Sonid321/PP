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
        MFCEntities2 MFC { get; set; }
        public UPSAPP()
        {
            MFC = new MFCEntities2();
            InitializeComponent();
            IBP.ItemsSource = MFC.UPSU.ToList();
            sStatus.ItemsSource = MFC.Stat.ToList();
            SbFilter.ItemsSource = MFC.Stat.ToList();
            SUPS.ItemsSource = MFC.UPSMod.ToList();
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            UPSU ups = new UPSU();

            //Добавление вводимых данных в базу
            var model = SUPS.SelectedItem as UPSMod;
            ups.UPSModel = model.ID;
            ups.SerialNum = SSerial.Text;
            ups.InvNum =SInventory.Text;
            var upsStatus = sStatus.SelectedItem as Stat;
            ups.Status = upsStatus.ID;



            MessageBox.Show("ИБП успешно добавлен в базу!");

            try
            {
                MFC.UPSU.Add(ups);
                MFC.SaveChanges();
                IBP.ItemsSource = MFC.UPSU.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            SUPS.SelectedValue = -1;
            SSerial.Clear();
            SInventory.Clear();
            sStatus.SelectedValue = -1;
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Close();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(tbID.Text);
            var eRow = MFC.UPSU.Where(x => x.ID == num).FirstOrDefault();
            var model = SUPS.SelectedItem as UPSMod;
            eRow.UPSModel = model.ID;
            eRow.SerialNum = SSerial.Text;
            eRow.InvNum = SInventory.Text;
            var Status = sStatus.SelectedItem as Stat;
            eRow.Status = Status.ID;
            MessageBox.Show("Данные обновлены!");

            try
            {
                MFC.SaveChanges();
                IBP.ItemsSource = MFC.UPSU.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            SUPS.SelectedValue = -1;
            SSerial.Clear();
            SInventory.Clear();
            sStatus.SelectedValue = -1;
        }

        private void filterCB(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
