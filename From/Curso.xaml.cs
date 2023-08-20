namespace From;

public partial class Curso : ContentPage
{
	public Curso()
	{
		InitializeComponent();
	}

    private void GuardarClicked(object sender, EventArgs e)
    {
        string idCurso = IdCursoEntry.Text;
        string nombreCurso = NombreCursoEntry.Text;
        int credito = int.Parse(CreditoEntry.Text);
        int bloque = int.Parse(BloqueEntry.Text);
        // Aquí puedes realizar el procesamiento o almacenamiento de los datos del plan de curso

        // Por ejemplo, mostrar un mensaje
        DisplayAlert("Guardado", "Los datos del plan de curso han sido guardados.", "Aceptar");
    }
}