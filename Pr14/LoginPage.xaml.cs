using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Pr14;

namespace Pr14
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Auth(LoginTextBox.Text.Trim(), PasswordBox.Password);
        }

        public bool Auth(string login, string password)
        {
            try
            {
                var client = Core.Context.Client.AsNoTracking()
                    .FirstOrDefault(c => c.Login == login && c.Password == password);

                if (client != null)
                {
                    CurrentUser.ClientId = client.ID;
                    CurrentUser.ClientLogin = client.Login;
                    CurrentUser.ClientName = client.Name;

                    if (Application.Current != null && Application.Current.MainWindow is MainWindow mainWindow)
                    {
                        mainWindow.UpdateAuthUI();
                    }

                    if (LoginTextBox != null) LoginTextBox.Clear();
                    if (PasswordBox != null) PasswordBox.Clear();

                    MessageBox.Show($"Добро пожаловать, {client.Name}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    NavigationService?.GoBack();
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Критический сбой", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void RegisterLinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}