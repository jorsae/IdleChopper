using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Model.Game
{
    public class CoinMarket : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const int MAX_SLIDER_VALUE = 100;
        private const int MIN_SLIDER_VALUE = 1;

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

        public void SetMarketPrice()
        {
            TickInterval = 1100 - (int)(SliderValue * 10);
            CoinsPerTick = (BigInteger)SliderValue * (BigInteger)Math.Pow(2, SliderValue);
            LogsPerTick = (BigInteger)SliderValue * (BigInteger)Math.Pow(4, SliderValue);
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}