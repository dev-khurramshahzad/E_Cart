using E_Cart.Admin_Pages;
using E_Cart.Models;
using E_Cart.User_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_Cart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_Page : ContentPage
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.db.CreateTable<Remember>();
            var check = App.db.Table<Remember>().ToList();
            if (check.Count == 1)
            {
                int id = check[0].UserID;
                App.LoggedInUser = App.db.Table<Users>().FirstOrDefault(x => x.UserID == id);
                App.Current.MainPage = new UserSidebar();
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new LoginUser());
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginAdmin());
        }

        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            App.db.DropTable<Models.Users>();
            App.db.CreateTable<Models.Users>();
            App.db.Insert(new Models.Users { UserID = 1, Name = "Admin", Email = "admin@admin.com", Password = "admin", Type = "Admin" });
            App.db.Insert(new Models.Users { UserID = 1, Name = "Customer", Email = "customer@customer.com", Password = "customer", Type = "Customer", Address = "Gujranwala Main City", phone="0300-00000000" });

            App.db.DropTable<Models.Categories>();
            App.db.CreateTable<Models.Categories>();
            App.db.Insert(new Models.Categories {CatID=2, CatName = "Mobiles", CatImage = "smart6.jpg", CatDetails = "All kinds of Mobiles", Status="Available"  });
            App.db.Insert(new Models.Categories {CatID=3, CatName = "Laptops", CatImage = "", CatDetails = "All kinds of Laptops", Status="Available"  });
            App.db.Insert(new Models.Categories { CatID = 4, CatName = "HeadPhones", CatImage = "", CatDetails = "All kinds of Headphones", Status = "Available" });
            App.db.DropTable<Models.Items>();
            App.db.CreateTable<Models.Items>();
            App.db.Insert(new Models.Items { ItemID=1, CatFID=1, ItemName= "Android Mobiles", PPrice=30000, SPrice=35000, ItemImage= "", Rating=5,  ItemDetail="Latest and new Mobiles", ItemStatus="Available" });
            App.db.Insert(new Models.Items { ItemID =1 , CatFID = 1, ItemName = "Iphones", PPrice = 120000, SPrice = 125000, ItemImage = "", Rating = 5, ItemDetail = "Latest and new Iphones", ItemStatus = "Available" });
            App.db.Insert(new Models.Items { ItemID=2, CatFID=2, ItemName= "Laptops", PPrice=60000, SPrice=65000, ItemImage= "", Rating=5,  ItemDetail="Latest and new laptops", ItemStatus="Available" });
            App.db.Insert(new Models.Items { ItemID=3, CatFID=3, ItemName= "Headphones", PPrice=1000, SPrice=1350, ItemImage= "", Rating=5,  ItemDetail="Latest and new Headphones", ItemStatus="Available" });

            await DisplayAlert("Message", "Application is restored to defaults", "OK");
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");

                if (result)
                {
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
            });
            return true;
        }
    }
}
