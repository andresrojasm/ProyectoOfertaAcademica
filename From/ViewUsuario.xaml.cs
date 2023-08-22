namespace From;

public partial class ViewUsuario : ContentPage
{
	public ViewUsuario()
	{
		InitializeComponent();
	}
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}