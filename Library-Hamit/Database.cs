using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace Library_Hamit
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
            {

            if(File.Exists(dbPath))
                {
                File.Delete(dbPath );
                }
            _database = new SQLiteAsyncConnection(dbPath,SQLiteOpenFlags.Create|SQLiteOpenFlags.ReadWrite|SQLiteOpenFlags.FullMutex);
            _database.CreateTableAsync<Book>().Wait();
            List<Book> books = new List<Book>
            {
            new Book{ ISBN_10 = 0321751043, Author="J.K.Rowling",Title="Harry Potter and the Sorcerer's Stone" },
            new Book{ ISBN_10 = 0062459368,Author = "George Orwell",Title="1984" },
            new Book{ ISBN_10 = 1400034779, Author = "Jane Austen", Title = "Pride and Prejudice" },
            new Book{ ISBN_10 = 0743273567, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" },
            new Book{ ISBN_10 = 0061120081, Author = " Harper Lee", Title = "To Kill a Mockingbird" }
            };

            _database.InsertAllAsync(books).Wait();
            }

        public Task<List<Book>> GetBooksAsync()
            {
            return _database.Table<Book>().ToListAsync();
            }
    }
}
