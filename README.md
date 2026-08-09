# 📝 MyDairy

MyDairy is a simple and user-friendly **Personal Diary Management Desktop Application** developed using **C# and WPF (Windows Presentation Foundation)**.

The application allows users to create an account, securely log in, manage diary entries, maintain personal profile information, and track daily expenses.

---

## 📌 Project Overview

MyDairy is designed to provide users with a simple digital platform for maintaining their personal diary.

Instead of maintaining a physical diary, users can use this application to:

- Register and create an account
- Login using username and password
- Create and manage diary entries
- View personal profile information
- Add and manage expenses
- Maintain personal information
- Logout from the application

---

## ✨ Features

### 🔐 User Registration

Users can create a new account by providing:

- Full Name
- Email
- Username
- Password

The application stores registered user information in a JSON file.

---

### 🔑 User Login

Users can login using their registered:

- Username
- Password

The application validates the entered credentials before opening the dashboard.

---

### 🏠 Dashboard

After successful login, users are redirected to the main dashboard.

The dashboard provides navigation options for:

- 📖 My Diary
- ➕ New Entry
- 👤 Profile
- 💰 Expenses
- 🚪 Logout

The dashboard uses WPF navigation to open different application pages. 

---

### 📖 My Diary

Users can access their diary section and manage their personal diary information.

---

### ✍️ New Diary Entry

Users can create new diary entries containing:

- Date
- Time
- Diary Content

Each diary entry is associated with the logged-in username.

---

### 👤 Profile

Users can manage their profile information.

The user model contains:

- Full Name
- Email
- Username
- About Me
- Photo Path
- Member Since

---

### 💰 Expense Management

Users can maintain their daily expenses.

Expense information includes:

- Username
- Date
- Amount
- Product Name

---

### 🚪 Logout

The logout option clears the current login session and closes the application.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|------------|---------|
| C# | Application Programming |
| WPF | Desktop User Interface |
| XAML | UI Design |
| .NET | Application Framework |
| JSON | Data Storage |
| Visual Studio | Development Environment |

---

## 📂 Project Structure

```text
MyDairy/
│
├── App.xaml
├── App.xaml.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
│
├── Login.xaml
├── Login.xaml.cs
│
├── Dashboard.xaml
├── Dashboard.xaml.cs
│
├── Users.cs
│
├── Pages/
│   ├── MyDairyPage.xaml
│   ├── MyNewEntryPage.xaml
│   ├── MyProfilePage.xaml
│   └── MyExpensesPage.xaml
│
├── MyDairy.csproj
├── MyDairy.slnx
└── README.md
