using Microsoft.Win32;
using MyDairy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyDairy.pages
{
    public partial class MyProfilePage : Page
    {
        string folderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");

        string filePath;

        string selectedPhoto = "";

        public MyProfilePage()
        {
            InitializeComponent();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            filePath = Path.Combine(folderPath, "users.json");

            LoadProfile();
        }

        private void LoadProfile()
        {
            if (!File.Exists(filePath))
                return;

            List<Users> users =
                JsonSerializer.Deserialize<List<Users>>
                (File.ReadAllText(filePath))
                ?? new List<Users>();

            Users? user = users.FirstOrDefault();

            if (user == null)
                return;

            txtAboutMe.Text = user.AboutMe;

            selectedPhoto = user.PhotoPath;

            if (!string.IsNullOrEmpty(selectedPhoto) &&
                File.Exists(selectedPhoto))
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(selectedPhoto);
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                ProfileBrush.ImageSource = image;
            }
        }

        private void BtnUploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == true)
            {
                string photoFolder = Path.Combine(folderPath, "ProfilePhotos");

                if (!Directory.Exists(photoFolder))
                    Directory.CreateDirectory(photoFolder);

                string extension = Path.GetExtension(dialog.FileName);

                string destination = Path.Combine(photoFolder,
                    "profile" + extension);

                File.Copy(dialog.FileName, destination, true);

                selectedPhoto = destination;

                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(selectedPhoto);
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                ProfileBrush.ImageSource = image;
            }
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("User data not found.");
                return;
            }

            List<Users> users =
                JsonSerializer.Deserialize<List<Users>>
                (File.ReadAllText(filePath))
                ?? new List<Users>();

            Users? user = users.FirstOrDefault();

            if (user == null)
                return;

            user.AboutMe = txtAboutMe.Text;

            user.PhotoPath = selectedPhoto;

            File.WriteAllText(
                filePath,
                JsonSerializer.Serialize(
                    users,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

            MessageBox.Show("Profile Updated Successfully!");
        }
    }
}