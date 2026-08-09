using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDairy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string folderPath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");

        string filePath;

        public MainWindow()
        {
            InitializeComponent();

            filePath = System.IO.Path.Combine(folderPath, "users.json");
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text == "" ||
                txtUsername.Text == "" ||
                txtPassword.Password == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            Directory.CreateDirectory(folderPath);

            List<Users> users = new List<Users>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();
            }

            if (users.Any(u => u.Username == txtUsername.Text))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            users.Add(new Users
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Password
            });

            File.WriteAllText(filePath,
                JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

            MessageBox.Show("Registration Successful!");

            txtFullName.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void BtnGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            // Optional: Close the current window
            this.Close();

        }
    }
}