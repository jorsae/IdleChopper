using IdleChopper.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IdleChopper.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}