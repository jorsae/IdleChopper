
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using Xamarin.Forms;

namespace IdleChopper.Views
{
    public partial class GamePageViewModel : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Timer GameTick = new Timer(100);

        private double _Logs;
        public double Logs
        {
            get => _Logs;
            set
            {
                _Logs = value;
                OnPropertyChanged();
            }
        }

        public Command LogClickCommand { get; }

        public GamePageViewModel()
        {
            LogClickCommand = new Command(LogClickCommandClicked);
            GameTick.Elapsed += GameTick_Elapsed;
        }

        private void GameTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("GameTick_Elapsed");
        }

        private void LogClickCommandClicked(object obj)
        {
            Logs += 1;
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