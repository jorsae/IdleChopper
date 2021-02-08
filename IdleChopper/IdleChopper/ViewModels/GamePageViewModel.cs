
using Model.Game;
using Model.Items;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        public Timer CoinTick = new Timer(1000);
        public CoinMarket coinMarket = new CoinMarket();

        private BigInteger _Coins;
        public BigInteger Coins
        {
            get => _Coins;
            set
            {
                _Coins = value;
                OnPropertyChanged();
            }
        }

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
            GameTick.Start();
            CoinTick.Elapsed += CoinTick_Elapsed;
            CoinTick.Start();

            ObservableBaseItems = new ObservableCollection<BaseItem>();
            foreach (BaseItem baseItem in itemController.Items
                                                        .Select(i => i.Value)
                                                        .OrderBy(i => i.Basecost))
            {
                ObservableBaseItems.Add(baseItem);
            }
            Coins = 10; // Temporary start with 10coins, to buy an Axe
        }

        private void CoinTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Logs > coinMarket.LogsPerTick)
            {
                Coins += coinMarket.CoinsPerTick;
                Logs -= coinMarket.LogsPerTick;
            }
        }

        private void GameTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            Logs += itemController.IdleDamage;
        }

        private void BuyItemCommandClicked(object obj)
        {
            string itemName = obj.ToString();
            BaseItem item = itemController.Items.Select(i => i.Value).Where(i => i.Name == itemName).First();
            BigInteger cost = item.GetSinglePurchaseCost();
            Console.WriteLine($"{item.Name}: {item.Quantity} | c:{cost}");
            Console.WriteLine($"logs/t:{coinMarket.LogsPerTick}, coins/t: {coinMarket.CoinsPerTick}, tick:{coinMarket.TickInterval}ms");
            if(Coins >= cost)
            {
                bool addedItem = itemController.AddItem(itemName, 1);
                if (addedItem)
                {
                    Coins -= cost;
                    item.Quantity = itemController.Items[itemName].Quantity;
                    item.GetDamageForUI = "N/A";// Update UI
                }
            }
            
        }

        private void LogClickCommandClicked(object obj)
        {
            Logs += itemController.ClickDamage;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}