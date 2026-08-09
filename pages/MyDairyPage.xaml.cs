using MyDairy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MyDairy.pages
{
    public partial class MyDairyPage : Page
    {
        string folderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");


        string filePath;
        string diaryFilePath;


        public MyDairyPage()
        {
            InitializeComponent();

            filePath = Path.Combine(folderPath, "users.json");

            diaryFilePath = Path.Combine(folderPath, "diary.json");


            LoadUserDetails();

            LoadDiaryEntries();
        }


        private void LoadUserDetails()
        {
            if (!File.Exists(filePath))
                return;


            List<Users> users = JsonSerializer.Deserialize<List<Users>>
                (File.ReadAllText(filePath))
                ?? new List<Users>();


            if (users.Count == 0)
                return;


            // Currently loading first user
            Users user = users.First();


            txtName.Text = user.FullName;
            txtEmail.Text = user.Email;



            if (!string.IsNullOrWhiteSpace(user.PhotoPath) &&
                File.Exists(user.PhotoPath))
            {
                imgProfile.ImageSource =
                    new BitmapImage(new Uri(user.PhotoPath));
            }
        }



        // Load Diary Entries
        private void LoadDiaryEntries()
        {
            if (!File.Exists(diaryFilePath))
                return;


            List<DiaryEntry> entries =
                JsonSerializer.Deserialize<List<DiaryEntry>>
                (File.ReadAllText(diaryFilePath))
                ?? new List<DiaryEntry>();


            // Show current user's diary
            var userEntries = entries
                .Where(e => e.Username == Session.LoggedInUsername)
                .OrderByDescending(e => e.Date)
                .ToList();


            lstDiary.ItemsSource = userEntries;
        }
    }
}