using MyDairy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace MyDairy.pages
{
    public partial class MyExpensesPage : Page
    {

        string folderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "mydairy");


        string expenseFilePath;


        List<Expense> expenses = new List<Expense>();


        public MyExpensesPage()
        {
            InitializeComponent();


            expenseFilePath = Path.Combine(folderPath, "expenses.json");

            LoadExpenses();
        }



        private void BtnAddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpenseName.Text))
            {
                MessageBox.Show("Enter expense Name");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Enter expense amount");
                return;
            }


            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Enter valid amount");
                return;
            }


            Expense expense = new Expense
            {
                Username = Session.LoggedInUsername,
                Date = DateTime.Now,
                productname = txtExpenseName.Text,
                Amount = amount
            };


            expenses.Add(expense);


            SaveExpenses();


            txtAmount.Clear();


            LoadExpenses();
        }



        private void LoadExpenses()
        {
            if (File.Exists(expenseFilePath))
            {
                expenses = JsonSerializer.Deserialize<List<Expense>>
                    (File.ReadAllText(expenseFilePath))
                    ?? new List<Expense>();
            }


            var userExpenses = expenses
                .Where(e => e.Username == Session.LoggedInUsername)
                .OrderByDescending(e => e.Date)
                .ToList();



            lstExpenses.Items.Clear();


            double total = 0;


            foreach (var expense in userExpenses)
            {
                lstExpenses.Items.Add(
                    $"{expense.Date:dd-MM-yyyy}  - {expense.productname}  ₹{expense.Amount}"
                );


                total += expense.Amount;
            }


            txtTotal.Text = $"Total Expense: ₹{total}";
        }




        private void SaveExpenses()
        {
            File.WriteAllText(
                expenseFilePath,
                JsonSerializer.Serialize(expenses,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
        }

    }
}