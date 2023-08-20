namespace From;

public partial class Acerca : ContentPage
{
	public Acerca()
	{
		InitializeComponent();
	}

    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}