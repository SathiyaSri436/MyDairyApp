using System;
using System.Collections.Generic;
using System.Text;

namespace MyDairy
{
    public class Users
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Profile Information
        public string AboutMe { get; set; } = string.Empty;

        public string PhotoPath { get; set; } = string.Empty;
        public DateTime MemberSince { get; set; } = DateTime.Now;



    }
    public static class Session
    {
        public static string LoggedInUsername { get; set; } = "";
    }
    public class DiaryEntry
    {
        public string Username { get; set; } = "";
        public DateTime Date { get; set; }
        public string Time { get; set; } = "";
        public string Content { get; set; } = "";
    }
    public class Expense
    {
        public string Username { get; set; } = "";

        public DateTime Date { get; set; }

        public double Amount { get; set; }
        public string productname { get; set; } = "";
    }
}
