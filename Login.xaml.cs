using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace MyDairy
{
    public partial class Login : Window
    {
        string folderPath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");

        string filePath;

        public Login()
        {
            InitializeComponent();

            filePath = System.IO.Path.Combine(folderPath, "users.json");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Please enter Username and Password.");
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No registered users found.");
                return;
            }

            string json = File.ReadAllText(filePath);

            List<Users> users = JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();

            Users user = users.FirstOrDefault(u =>
                u.Username.Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password == txtPassword.Password);

            if (user != null)
            {
                MessageBox.Show("Login Successful!");
                Session.LoggedInUsername = user.Username;

                Dashboard dashboard = new Dashboard();
                dashboard.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }

        private void BtnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
