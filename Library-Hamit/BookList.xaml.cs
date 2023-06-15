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
    public BookList(string username)
        {
        InitializeComponent();

            user.Text = $"Hi {username}!, How are youu??";
        }
    }
}