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
using ToruMalev.Classes;

namespace ToruMalev.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowHotelPage.xaml
    /// </summary>
    public partial class ShowHotelPage : Page
    {
        List<Tour> HotelFilter = BaseClass.ME.Tour.ToList();

        public ShowHotelPage()
        {
            InitializeComponent();

            BaseClass.ME = new MalevEntities();

            HotelFilter = BaseClass.ME.Tour.ToList();

            listHotel.ItemsSource = BaseClass.ME.Tour.ToList();

            List<Type> T = BaseClass.ME.Type.ToList();

            foreach (Type type in T)
            {
                cmbTips.Items.Add(type.Name_Type);
            }
        }

        private void tbTicket_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            int index = Convert.ToInt32(tb.Uid);

            List<Tour> T = BaseClass.ME.Tour.Where(x => x.Price == index).ToList();

            int count = new int();

            foreach (Tour t in T)
            {
                count = Convert.ToInt32(t.Price);
            }

            tb.Text = "Билетов: " + count.ToString();
        }

        void Filter()
        {
            List<Tour> tourList = new List<Tour>();

            string tip = cmbTips.SelectedValue.ToString();
            int index = cmbTips.SelectedIndex;

            if (index != 0)
            {
                List<TypeOfTour> typeOfTours = BaseClass.ME.TypeOfTour.Where(x => x.id_Type == index).ToList();

                foreach (TypeOfTour typeOfTour in typeOfTours)
                {
                    tourList.Add(HotelFilter.FirstOrDefault(x => x.id_Tour == typeOfTour.id_Type));
                }
            }

            else
            {
                tourList = BaseClass.ME.Tour.ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtblock_Poisk.Text))
            {
                tourList = tourList.Where(x => x.Name_Tour.ToLower().Contains(txtblock_Poisk.Text.ToLower())).ToList();
            }

            if (cbActual.IsChecked == true)

                tourList = tourList.Where(x => x.Is_Actual == true).ToList();
        }

        private void cmbTips_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Filter();
        }

        private void txtbox_Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbActual_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cmbTips_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnHotel_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new HotelPage());
        }
    }
}
