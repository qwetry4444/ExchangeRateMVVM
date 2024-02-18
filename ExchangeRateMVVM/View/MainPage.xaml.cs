using ExchangeRateMVVM.ViewModel;

namespace ExchangeRateMVVM;

public partial class MainPage : ContentPage
{
	public MainPage(ValutesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

