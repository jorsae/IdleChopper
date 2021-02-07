using System;
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

        private void Slider_DragCompleted(object sender, System.EventArgs e)
        {
            Slider s = sender as Slider;
            gamePageViewModel.coinMarket.SliderValue = s.Value;
            Console.WriteLine($"Slider_DragCompleted: {s.Value}");
            gamePageViewModel.CoinTick.Interval = gamePageViewModel.coinMarket.TickInterval;
        }
    }
}