namespace From;

public partial class SingInPage : ContentPage
{
	public SingInPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped_For_SignUP(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignUp");
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}