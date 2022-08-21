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
        //Update the code to allow binding on Contact -> use propdp to create a dependency property.


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(UsrControlContact), new PropertyMetadata(new Contact() { Name = "Name LastName", Phone = "(0123) 456 789", Email="email@email.com"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UsrControlContact control = d as UsrControlContact;

            if (control != null)
            {
                control.txtBlockName.Text = (e.NewValue as Contact).Name;
                control.txtBlockEmail.Text = (e.NewValue as Contact).Email;
                control.txtBlockPhone.Text = (e.NewValue as Contact).Phone;

            }
        }



        //private Contact contact;
        //
        //public Contact Contact
        //{
        //    get { return contact; }
        //    set 
        //    { 
        //        contact = value;
        //        txtBlockName.Text = contact.Name;
        //        txtBlockEmail.Text = contact.Email;
        //        txtBlockPhone.Text = contact.Phone;
        //    }
        //}

        public UsrControlContact()
        {
            InitializeComponent();
        }
    }
}
