using E_Cart.Models;
using E_Cart;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace E_Cart
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Voting.db3");
        public static SQLiteConnection db = new SQLiteConnection(dbPath);
        public static List<OrderDetail> Cart = new List<OrderDetail>();

        public static Users LoggedInUser = null;

        public static double? Total = 0;

        public App()
        {


            InitializeComponent();

            MainPage = new Home_Page();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
