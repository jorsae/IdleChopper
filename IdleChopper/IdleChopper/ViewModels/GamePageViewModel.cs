
using Model.Items;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Timers;
using Xamarin.Forms;

namespace IdleChopper.Views
{
    public partial class GamePageViewModel : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ItemController itemController = new ItemController();
        private Timer GameTick = new Timer(100);

        private BigInteger _Logs;
        public BigInteger Logs
        {
            get => _Logs;
            set
            {
                _Logs = value;
                OnPropertyChanged();
            }
        }

        public Command LogClickCommand { get; }
        public Command BuyAxeCommand { get; }
        public Command BuyWoodTruckCommand { get; }

        public GamePageViewModel()
        {
            LogClickCommand = new Command(LogClickCommandClicked);
            BuyAxeCommand = new Command(BuyAxeCommandClicked);
            BuyWoodTruckCommand = new Command(BuyWoodTruckCommandClicked);
            GameTick.Elapsed += GameTick_Elapsed;
            GameTick.Start();
        }

        private void GameTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("GameTick_Elapsed");
            Logs += itemController.IdleDamage;
        }

        private void LogClickCommandClicked(object obj)
        {
            Logs += itemController.ClickDamage;
            Console.WriteLine($"Clicked log. Logs: {Logs}");
        }

        private void BuyAxeCommandClicked(object obj)
        {
            itemController.AddItem("Axe", 1);
        }

        private void BuyWoodTruckCommandClicked(object obj)
        {
            itemController.AddItem("Wood Truck", 1);
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}