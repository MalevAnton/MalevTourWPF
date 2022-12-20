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
using ToruMalev.Classes;

namespace ToruMalev
{
    /// <summary>
    /// Логика взаимодействия для WindowHotel.xaml
    /// </summary>
    public partial class WindowHotel : Window
    {
        public Hotel hotel = new Hotel();

        public WindowHotel()
        {
            InitializeComponent();

            List<Country> countries = new List<Country>();

            foreach (Country country in countries)
            {
                countryComboBox.Items.Add(country.Name_Country);
            }

            countStarsComboBox.SelectedIndex = 0;

            countryComboBox.SelectedIndex = 0;

            countryComboBox.Items.Add("Не выбрано");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameHotelTextBox.Text != "")
            {
                if (descriptionTextBox.Text != "")
                {
                    if (countryComboBox.SelectedIndex != 0)
                    {

                        Country country = BaseClass.ME.Country.FirstOrDefault(x => x.Name_Country == countryComboBox.Text);

                        if (hotel.id_Hotel > 0)
                        {
                            hotel.Name_Hotel = nameHotelTextBox.Text;

                            hotel.Country_Of_Stars = countStarsComboBox.SelectedIndex;

                            hotel.Description = descriptionTextBox.Text;

                            hotel.Code_Country = country.Code_Country;
                        }

                        else
                        {
                            Hotel newHotel = new Hotel()
                            {
                                Name_Hotel = nameHotelTextBox.Text,

                                Country_Of_Stars = countStarsComboBox.SelectedIndex,

                                Description = descriptionTextBox.Text,

                                Code_Country = country.Code_Country,
                            };

                            BaseClass.ME.Hotel.Add(newHotel);
                        }

                        BaseClass.ME.SaveChanges();

                        MessageBox.Show("Редактировано");

                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Выберите страну");
                    }
                }

                else
                {
                    MessageBox.Show("Пишите описание");
                }
            }

            else
            {
                MessageBox.Show("Пишите наименование");
            }

        }

        public WindowHotel(Hotel hotel)
        {
            InitializeComponent();

            this.hotel = hotel;

            addButton.Content = "Изменить";

            headerAddWindow.Text = "Редактирование отеля";

            List<Country> countries = BaseClass.ME.Country.ToList();

            foreach (Country country in countries)
            {
                countryComboBox.Items.Add(country.Name_Country);
            }

            int index = countries.FindIndex(x => x.Code_Country == hotel.Code_Country) + 1;

            countryComboBox.Items.Add("Не выбрано");

            nameHotelTextBox.Text = hotel.Name_Hotel;

            countStarsComboBox.SelectedIndex = hotel.Country_Of_Stars;

            descriptionTextBox.Text = hotel.Description;

            countryComboBox.SelectedIndex = index;
        }

        private void addClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
