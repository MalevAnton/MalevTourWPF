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
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {

        List<Hotel> hotel = new List<Hotel>();

        public HotelPage()
        {
            InitializeComponent();

            hotel = BaseClass.ME.Hotel.ToList();

            hotelList.ItemsSource = BaseClass.ME.Hotel.ToList();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new ShowHotelPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowHotel windowHotel = new WindowHotel();

            windowHotel.ShowDialog();

            FrameClass.MainFrame.Navigate(new HotelPage());
        }

        private void updateHotelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            int index = Convert.ToInt32(button.Uid);

            Hotel hotel = BaseClass.ME.Hotel.FirstOrDefault(x => x.id_Hotel == index);

            WindowHotel windowHotel = new WindowHotel();

            windowHotel.ShowDialog();

            FrameClass.MainFrame.Navigate(new HotelPage());
        }

        private void deleteHotelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            int index = Convert.ToInt32(button.Uid);

                Hotel hotel = BaseClass.ME.Hotel.FirstOrDefault(x => x.id_Hotel == index);

                BaseClass.ME.Hotel.Remove(hotel);

                BaseClass.ME.SaveChanges();

                FrameClass.MainFrame.Navigate(new HotelPage());
        }
    }
}
