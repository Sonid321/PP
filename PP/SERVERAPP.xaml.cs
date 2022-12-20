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
    /// Логика взаимодействия для SERVERAPP.xaml
    /// </summary>
    public partial class SERVERAPP : Window
    {
        MFCEntities2 MFC1;
        public SERVERAPP()
        {

            MFC1 = new MFCEntities2();
            InitializeComponent();
            IBP.ItemsSource = MFC1.ServU.ToList();
            sStatus.ItemsSource = MFC1.Stat.ToList();
            SUPS.ItemsSource = MFC1.ModelSer.ToList();
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            ServU ups = new ServU();

            //Добавление вводимых данных в базу
            var model = SUPS.SelectedItem as ModelSer;
            ups.ModelServ = model.ID;
            ups.SerNum = SSerial.Text;
            ups.InvNum = SInventory.Text;
            var upsStatus = sStatus.SelectedItem as Stat;
            ups.Status = upsStatus.ID;
            ups.DateState = DateTime.Parse(Convert.ToString(data));
            MessageBox.Show("ИБП успешно добавлен в базу!");

            try
            {
                MFC1.ServU.Add(ups);
                MFC1.SaveChanges();
                IBP.ItemsSource = MFC1.ServU.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            SUPS.SelectedValue = -1;
            SSerial.Clear();
            SInventory.Clear();
            sStatus.SelectedValue = -1;
            data.Text = null;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MFC1 = new MFCEntities2();
            ServU item = IBP.SelectedItem as ServU;
            try
            {
                ServU ser = MFC1.ServU.Where(c => c.ID == item.ID).Single();
                MFC1.ServU.Remove(ser);
                MFC1.SaveChanges();

                MessageBox.Show("Данные успешно удалены");
                refreshdatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void refreshdatagrid()
        {
            MFC1 = new MFCEntities2();
            IBP.ItemsSource = MFC1.ServU.ToList();
            IBP.Items.Refresh();
        }
        private void btnEdit(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(tbID.Text);
            var eRow = MFC1.ServU.Where(x => x.ID == num).FirstOrDefault();
            var model = SUPS.SelectedItem as ServU;
            eRow.ModelServ = model.ID;
            eRow.SerNum = SSerial.Text;
            eRow.InvNum = SInventory.Text;
            var Status = sStatus.SelectedItem as Stat;
            eRow.Status = Status.ID;
            MessageBox.Show("Данные обновлены!");

            try
            {
                MFC1.SaveChanges();
                IBP.ItemsSource = MFC1.ServU.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            SUPS.SelectedValue = -1;
            SSerial.Clear();
            SInventory.Clear();
            sStatus.SelectedValue = -1;
            data.Text = null;
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Close();
        }

        public void ReadData()
        {
            MFC1 = new MFCEntities2();
            IBP.ItemsSource = MFC1.ServU.ToList();
            Title = $"База данных";
        }
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = (sender as TextBox).Text.ToLower();
            if (!(String.IsNullOrEmpty(input)))
            {
                int resultCount = MFC1.UPSU.Count(x => x.Stat.Status.Contains(input));
                IBP.ItemsSource = MFC1.UPSU.Where(x => x.Stat.Status.Contains(input)).ToList();
                Title = $"База данных | Поиск: {input} | Результатов: {resultCount} из {MFC1.UPSU.ToList().Count()}";
            }
            else
                ReadData();
        }
    }
}

