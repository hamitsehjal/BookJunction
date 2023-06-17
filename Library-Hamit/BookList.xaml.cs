using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library_Hamit
    {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookList : ContentPage
        {
        private User person;
        protected override async void OnAppearing()
            {
            base.OnAppearing();
            listOfBooks.ItemsSource = await App.Database.GetBooksAsync();
            }
        public BookList(string username)
            {
            InitializeComponent();
            person = new User(username);
            user.Text = $"Welcome {username}!";
            }
        async void Clicked_Borrowed(object sender, EventArgs e)
            {
            System.Console.WriteLine($"Current User is: {person.Name}");

            // Handle the Borrow action
            MenuItem menuItem = (MenuItem)sender;
            var selectedBook = (menuItem.BindingContext as Book)?.Title;
            if (selectedBook != null)
                {

                Book book = await App.Database.GetBookByTitle(selectedBook);
                if (book != null && !book.IsBorrowed)
                    {
                    // book is available for borrowing

                    book.IsBorrowed = true;
                    book.Borrower = person.Name;

                    // Update the book in the database
                    await App.Database.UpdateBook(book);


                    // show pop up with Operatin Successful Message
                    await DisplayAlert("Successful", "You have borrowed the book", "OK");
                    }
                else
                    {
                    // show pop up with Operation Failed Message
                    await DisplayAlert("Failed", "You can't borrow this book", "OK");
                    }
                }
            }

        async void Clicked_Return(object sender, EventArgs e)
            {
            System.Console.WriteLine($"Current User is: {person.Name}");
            // Handle the Return action
            MenuItem menuItem = (MenuItem)sender;
            var SelectedBook = (menuItem.BindingContext as Book)?.Title;

            if (SelectedBook != null)
                {
                Book book = await App.Database.GetBookByTitle(SelectedBook);
                if (book != null && book.Borrower.Equals(person.Name))
                    {
                    // Pop-up with Operation is successful
                    book.IsBorrowed = false;
                    book.Borrower = "";
                    await App.Database.UpdateBook(book);
                    await DisplayAlert("Successful", "Book is Returned", "OK");
                    }
                else
                    {
                    // Pop-up with Operation Failed
                    await DisplayAlert("Failed", "You can't return the Book", "OK");
                    }
                }
            }
        async void OnItemsSelected(object sender, SelectedItemChangedEventArgs e)
            {
            System.Console.WriteLine($"The current user is: {person.Name}");
            if (e.SelectedItem == null)
                {
                return;
                }

            bookStatus.Text = "";

            System.Console.WriteLine("Item Selected: ", e.SelectedItemIndex);

            // retrieve the selected item from ListView
            var selectedBook = (Book)e.SelectedItem;

            if (selectedBook != null)
                {
                // retrieve the selected item from database
                Book book = await App.Database.GetBookByTitle(selectedBook.Title);

                // check if retrieved book is borrowed or not
                if (book.IsBorrowed)
                    {
                    if (book.Borrower.Equals(person.Name))
                        {
                        System.Console.WriteLine($"You Checked out this Book!");
                        bookStatus.Text = "You Checked out this Book!";
                        }
                    else
                        {
                        System.Console.WriteLine($"The Book is checked out by {book.Borrower}");
                        bookStatus.Text = $"The Book is checked out by {book.Borrower}";
                        }
                    }
                else
                    {
                    System.Console.WriteLine("The Book is available for borrowing!");
                    bookStatus.Text = $"The Book is available for borrowing!";
                    }
                }
            }
        }
    }