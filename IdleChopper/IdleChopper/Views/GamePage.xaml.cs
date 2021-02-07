using Xamarin.Forms;

namespace IdleChopper.Views
{
    public partial class GamePage : ContentPage
    {
        private GamePageViewModel gamePageViewModel;
        public GamePage()
        {
            InitializeComponent();
            gamePageViewModel = new GamePageViewModel();
            this.BindingContext = gamePageViewModel;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            gamePageViewModel.coinMarket.SliderValue = e.NewValue;
            gamePageViewModel.CoinTick.Interval = gamePageViewModel.coinMarket.TickInterval;
        }
    }
}