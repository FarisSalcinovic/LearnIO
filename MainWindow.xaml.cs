using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LearnIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private T? FindVisualChildByName<T>(DependencyObject parent, string name) where T : FrameworkElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t && t.Name == name)
                    return t;

                T? result = FindVisualChildByName<T>(child, name);
                if (result != null)
                    return result;
            }
            return null;
        }


        // Event handler for GotFocus (When the TextBox gets focus)
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var placeholder = FindVisualChildByName<TextBlock>(textBox, "PlaceholderText");
                if (placeholder != null)
                    placeholder.Visibility = Visibility.Collapsed;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                var placeholder = FindVisualChildByName<TextBlock>(textBox, "PlaceholderText");
                if (placeholder != null)
                    placeholder.Visibility = Visibility.Visible;
            }
        }


        // Event handler for TextChanged (When the text changes in the TextBox)
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                var placeholder = FindVisualChildByName<TextBlock>(textBox, "PlaceholderText");
                if (placeholder != null)
                    placeholder.Visibility = Visibility.Collapsed;
            }
        }

        //-----------------------------------------------------------------------------------------------------------//

        // Event handler for PasswordBox GotFocus
        // Event handler for PasswordBox GotFocus
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                var placeholder = FindVisualChildByName<TextBlock>(passwordBox, "PlaceholderText");
                if (placeholder != null)
                    placeholder.Visibility = Visibility.Collapsed;
            }
        }

        // Event handler for PasswordBox LostFocus
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox && string.IsNullOrEmpty(passwordBox.Password))
            {
                var placeholder = FindVisualChildByName<TextBlock>(passwordBox, "PlaceholderText");
                if (placeholder != null)
                    placeholder.Visibility = Visibility.Visible;
            }
        }

        // Event handler for PasswordBox PasswordChanged
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                var placeholder = FindVisualChildByName<TextBlock>(passwordBox, "PlaceholderText");
                if (placeholder != null)
                {
                    placeholder.Visibility = string.IsNullOrEmpty(passwordBox.Password)
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();

            // Optional: Close or hide current window
            this.Close(); // or this.Hide();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PracticePage practicePage = new PracticePage();
            practicePage.Show();

            // Optional: Close or hide current window
            this.Close(); // or this.Hide();
        }

    }
}
