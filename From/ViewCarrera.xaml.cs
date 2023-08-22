namespace From;

public partial class ViewCarrera : ContentPage
{
	public ViewCarrera()
	{
		InitializeComponent();
	}
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}