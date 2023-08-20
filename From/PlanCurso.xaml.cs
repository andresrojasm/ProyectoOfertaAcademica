namespace From;

public partial class PlanCurso : ContentPage
{
	public PlanCurso()
	{
		InitializeComponent();
	}
    private void GuardarClicked(object sender, EventArgs e)
    {
        string codigoPlan = IdPlanCursoEntry.Text;
        string nombrePlan = NombrePlanEntry.Text;
        string idCarrera = IdCarreraEntry.Text;

        // Aquí puedes realizar el procesamiento o almacenamiento de los datos del plan de curso

        // Por ejemplo, mostrar un mensaje
        DisplayAlert("Guardado", "Los datos del plan de curso han sido guardados.", "Aceptar");
    }
}