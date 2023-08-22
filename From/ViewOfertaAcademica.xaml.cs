namespace From;

public partial class ViewOfertaAcademica : ContentPage
{
	public ViewOfertaAcademica()
	{
		InitializeComponent();
	}
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}