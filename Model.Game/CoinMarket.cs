using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Model.Game
{
    public class CoinMarket : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private BigInteger _CoinsPerTick;
        public BigInteger CoinsPerTick { get => _CoinsPerTick; set => _CoinsPerTick = value; }

        private BigInteger _LogsPerTick;
        public BigInteger LogsPerTick { get => _LogsPerTick; set => _LogsPerTick = value; }

        private int _TickInterval;
        public int TickInterval { get => _TickInterval; set => _TickInterval = value; }

        private double _SliderValue;
        public double SliderValue
        {
            get => _SliderValue;
            set
            {
                _SliderValue = value;
                SetMarketPrice();
            }
        }


        private string _MarketPrice = "haha";
        public string MarketPrice
        {
            get => _MarketPrice;
            set
            {
                _MarketPrice = value;
                OnPropertyChanged();
            }
        }
        /*
        public string MarketPrice
        {
            get
            {
                BigInteger logsPerSecond = LogsPerTick / TickInterval * 1000;
                BigInteger coinsPerSecond = CoinsPerTick / TickInterval * 1000;
                return $"Selling {logsPerSecond}logs for coins: {coinsPerSecond} per sec";
            }
            set
            {
                OnPropertyChanged();
            }
        }*/

        public void SetMarketPrice()
        {
            TickInterval = 1100 - (int)(SliderValue * 10);
            CoinsPerTick = (BigInteger)SliderValue * (BigInteger)Math.Pow(2, SliderValue);
            LogsPerTick = (BigInteger)SliderValue * (BigInteger)Math.Pow(4, SliderValue);
            
            MarketPrice = "N/A";// Update MarketPrice
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}