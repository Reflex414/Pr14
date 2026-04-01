using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Pr14;

namespace Pr14
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register(
                NameTextBox.Text.Trim(),
                LoginTextBox.Text.Trim(),
                MailTextBox.Text.Trim(),
                PasswordBox.Password,
                ConfirmPasswordBox.Password
            );
        }

        public bool Register(string name, string login, string mail, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return false;
            }
            if (password.Length < 3)
            {
                MessageBox.Show("Пароль слишком короткий! Минимум 3 символа.");
                return false;
            }

            if (!mail.Contains("@") || !mail.Contains("."))
            {
                MessageBox.Show("Введите корректный email!");
                return false;
            }

            try
            {
                if (Core.Context.Client.AsNoTracking().Any(c => c.Login == login))
                {
                    MessageBox.Show("Логин уже занят!");
                    return false;
                }

                var newClient = new Client
                {
                    Name = name,
                    Login = login,
                    Mail = mail,
                    Password = password
                };

                Core.Context.Client.Add(newClient);
                Core.Context.SaveChanges();

                MessageBox.Show("Регистрация успешна!");
                NavigationService?.GoBack();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }
        private void LoginLinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new LoginPage());
            }
        }
    }
}