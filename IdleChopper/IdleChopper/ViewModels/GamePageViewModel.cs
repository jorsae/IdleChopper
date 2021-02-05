
using Model.Items;
using System;
using System.Collections.ObjectModel;
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

        private ObservableCollection<BaseItem> _ObservableBaseItems;
        public ObservableCollection<BaseItem> ObservableBaseItems
        {
            get => _ObservableBaseItems;
            set
            {
                _ObservableBaseItems = value;
                OnPropertyChanged();
            }
        }

        public Command LogClickCommand { get; }
        public Command BuyItemCommand { get; }

        public GamePageViewModel()
        {
            LogClickCommand = new Command(LogClickCommandClicked);
            BuyItemCommand = new Command(BuyItemCommandClicked);
            GameTick.Elapsed += GameTick_Elapsed;
            //GameTick.Start();

            ObservableBaseItems = new ObservableCollection<BaseItem>
            {
                itemController.Items["Axe"],
                itemController.Items["Wood Truck"]
            };
        }

        private void GameTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("GameTick_Elapsed");
            Logs += itemController.IdleDamage;
        }

        private void BuyItemCommandClicked(object obj)
        {
            Console.WriteLine($"BuyItemCommand_Clicked: {obj}");
        }

        private void LogClickCommandClicked(object obj)
        {
            Logs += itemController.ClickDamage;
            Console.WriteLine($"Clicked log. Logs: {Logs}");
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}