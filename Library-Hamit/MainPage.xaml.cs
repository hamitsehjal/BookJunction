using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library_Hamit
    {
    public partial class MainPage : ContentPage
        {
        public MainPage()
            {
            InitializeComponent();
            background.Source = ImageSource.FromResource("Library-Hamit.images.lib-background.jpg");
            }
        
        async void Login_Clicked(object sender, EventArgs e)
            {
            string passwordEntered = passwordEntry.Text;
            string usernameEntered= usernameEntry.Text;

            if (string.IsNullOrWhiteSpace(usernameEntered))
                {
                System.Console.WriteLine("Username REQUIRED");
                errorFrame.BackgroundColor = Color.Red;
                errors.Text = "Username REQUIRED";
                }
            else if (string.IsNullOrWhiteSpace(passwordEntered))
                {
                System.Console.WriteLine("Password REQUIRED");
                errorFrame.BackgroundColor = Color.Red;
                errors.Text = "Password REQUIRED";
                }
            else if(usernameEntered=="peter")
                {
                if(passwordEntered=="1234")
                    {
                System.Console.WriteLine("VALIDATION PASSED!!");
                    errorFrame.BackgroundColor= Color.White;
                    errors.Text = "";
                    passwordEntry.Text = "";
                    usernameEntry.Text="";
                    await Navigation.PushAsync(new BookList(usernameEntered));

                    }
                else
                    {
                    System.Console.WriteLine("Wrong Password");
                    errorFrame.BackgroundColor = Color.Red;
                    errors.Text = "Wrong Password";
                    }
                }
            else if (usernameEntered == "mary")
                {
                if (passwordEntered == "0000")
                    {
                    System.Console.WriteLine("VALIDATION PASSED!!");
                    errorFrame.BackgroundColor = Color.White;
                    errors.Text = "";
                    passwordEntry.Text = "";
                    usernameEntry.Text = "";
                    await Navigation.PushAsync(new BookList(usernameEntered));

                    }
                else
                    {
                    System.Console.WriteLine("Wrong Password");
                    errorFrame.BackgroundColor = Color.Red;
                    errors.Text = "Wrong Password";
                    }
                }
            else
                {
                System.Console.WriteLine("Incorrect Username or Password");
                errorFrame.BackgroundColor = Color.Red;
                errors.Text = "Incorrect Username or Password";
                }
            } 


        }
  
    }
