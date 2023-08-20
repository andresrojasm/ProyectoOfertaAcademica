namespace From;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void UsuarioBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Usuario());
    }

    private void PlanCursoBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PlanCurso());
    }

    private void CursoBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Curso());
    }

    private void OfertaAcademicaBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OfertaAcademica());
    }

    private void CarreraBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Carrera());
    }

    private void AcercaBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Acerca());
    }
}