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

namespace AntiVirus.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для AccountDetailsDialog.xaml
    /// </summary>
    public partial class AccountDetailsDialog : Window
    {
        public AccountDetailsDialog()
        {
            InitializeComponent();
        }

        private void CloseProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToggleProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

    }

}
