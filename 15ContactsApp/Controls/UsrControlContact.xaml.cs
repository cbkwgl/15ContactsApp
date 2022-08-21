using _15ContactsApp.Classes;
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

namespace _15ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for UsrControlContact.xaml
    /// </summary>
    public partial class UsrControlContact : UserControl
    {
        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set 
            { 
                contact = value;
                txtBlockName.Text = contact.Name;
                txtBlockEmail.Text = contact.Email;
                txtBlockPhone.Text = contact.Phone;
            }
        }

        public UsrControlContact()
        {
            InitializeComponent();
        }
    }
}
