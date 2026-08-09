using MyDairy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace MyDairy.pages
{
    public partial class MyNewEntryPage : Page
    {
        string folderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");

        string filePath;

        public MyNewEntryPage()
        {
            InitializeComponent();

            filePath = Path.Combine(folderPath, "DiaryEntries.json");

            dpDate.SelectedDate = DateTime.Today;
            txtTime.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void BtnSaveEntry_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(folderPath);

            List<DiaryEntry> entries = new List<DiaryEntry>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                entries = JsonSerializer.Deserialize<List<DiaryEntry>>(json)
                          ?? new List<DiaryEntry>();
            }

            entries.Add(new DiaryEntry
            {
                Username = Session.LoggedInUsername,
                Date = dpDate.SelectedDate ?? DateTime.Today,
                Time = txtTime.Text,
                Content = txtdate.Text
            });

            File.WriteAllText(filePath,
                JsonSerializer.Serialize(entries,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }));

            MessageBox.Show("Diary Entry Saved Successfully!");

            dpDate.SelectedDate = DateTime.Today;
            txtTime.Text = DateTime.Now.ToString("hh:mm tt");
            txtdate.Clear();
        }
    }
}