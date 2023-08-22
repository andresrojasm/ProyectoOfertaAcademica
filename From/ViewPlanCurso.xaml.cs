namespace From;

public partial class ViewPlanCurso : ContentPage
{
	public ViewPlanCurso()
	{
		InitializeComponent();
	}
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}