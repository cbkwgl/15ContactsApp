using _15ContactsApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _15ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void BtnNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.Show();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DataBasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (contacts != null) 
            { 
                //foreach(var c in contacts)
                //{
                //    LstViewContacts.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    });
                //}
                LstViewContacts.ItemsSource = contacts;
            
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.Contains(searchTextBox.Text)).ToList();

            LstViewContacts.ItemsSource = filteredList;
        }

        private void LstViewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)LstViewContacts.SelectedItem;

            if (selectedContact !=null)
            {
                ContactWindow contactWindow = new ContactWindow(selectedContact);
                contactWindow.Show();

                ReadDatabase();
            }
        }
    }
}
