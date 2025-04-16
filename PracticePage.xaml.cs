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

namespace LearnIO
{
    /// <summary>
    /// Interaction logic for PracticePage.xaml
    /// </summary>
    public partial class PracticePage : Window
    {
        public PracticePage()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();

            // Optional: Close or hide current window
            this.Close(); // or this.Hide();
        }
    }
}
