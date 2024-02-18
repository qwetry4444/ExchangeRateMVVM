using System.Collections.ObjectModel;
using ExchangeRateMVVM.Model;
using ExchangeRateMVVM.Services;


namespace ExchangeRateMVVM.ViewModel
{
    public partial class ValutesViewModel : BaseViewModel
    {
        ValuteService valuteService;

        public Command DateSelectedCommand { get; }
        public ObservableCollection<Valute> Valutes { get; } = new();

        public int countAdd = 0;
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if(_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                    ValuteExchange();
                }
                GetValutesAsync();
            }
        }

        public String _dateLabel;
        public String DateLabel
        {
            get => _dateLabel;
            set
            {
                if (_dateLabel != value)
                {
                    _dateLabel = value;
                    OnPropertyChanged();
                }
            }
        }
        

        private double _amountSrc;
        public double AmountSrc
        {
            get => _amountSrc;
            set
            {
                if (_amountSrc != value) 
                {
                    _amountSrc = value;
                    OnPropertyChanged();
                    ValuteExchange();
                }
            }
        }

        private double _amountDest;
        public double AmountDest
        {
            get => _amountDest;
            set
            {
                if (_amountDest != value)
                {
                    _amountDest = value;
                    OnPropertyChanged();
                }
            }
        }

        private Valute _selectedValuteSrc;
        public Valute SelectedValuteSrc
        {
            get => _selectedValuteSrc;
            set
            {
                if (_selectedValuteSrc != value)
                {
                    _selectedValuteSrc = value;
                    OnPropertyChanged();
                    ValuteExchange();
                }
            }
        }

        private Valute _selectedValuteDest;
        public Valute SelectedValuteDest
        {
            get => _selectedValuteDest;
            set
            {
                if (_selectedValuteDest != value)
                {
                    _selectedValuteDest = value;
                    OnPropertyChanged();
                    ValuteExchange();
                }
            }
        }

        public ValutesViewModel(ValuteService valuteService)
        {
            this.valuteService = valuteService;
            Date = DateTime.Now;
        }

        private async void GetValutesAsync()
        {
            CurrencyRates currencyRates = await valuteService.GetCurrencies(Date);
            Dictionary<String, Valute> valutes = currencyRates.Valutes;
            DateLabel = currencyRates.Date.ToString();

            if (Valutes.Count != 0)
            {
                Valutes.Clear();
            }

            foreach (KeyValuePair<string, Valute> pair in valutes)
            {
                Valutes.Add(pair.Value);
            }
        }

        private void ValuteExchange()
        {
            if (SelectedValuteSrc != null && SelectedValuteDest != null)
                AmountDest = SelectedValuteSrc.Convert(SelectedValuteDest, AmountSrc);
        }
    }
}
