using _15ContactsApp.Classes;
using SQLite;
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

namespace _15ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        Contact contact;
        public ContactWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            TxtBoxName.Text = contact.Name;
            TxtBoxemail.Text = contact.Email;
            TxtBoxPhone.Text = contact.Phone;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = TxtBoxName.Text;
            contact.Email = TxtBoxemail.Text;
            contact.Phone = TxtBoxPhone.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            this.Close();
        }
    }
}
