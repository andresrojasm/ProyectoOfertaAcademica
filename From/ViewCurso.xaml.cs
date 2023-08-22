namespace From;

public partial class ViewCurso : ContentPage
{
	public ViewCurso()
	{
		InitializeComponent();
	}
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}