using Xamarin.Forms;

namespace IdleChopper.Views
{
    public partial class GamePage : ContentPage
    {

        public GamePage()
        {
            InitializeComponent();

            this.BindingContext = new GamePageViewModel();
        }
    }
}