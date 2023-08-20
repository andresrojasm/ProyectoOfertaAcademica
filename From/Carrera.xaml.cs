namespace From;

public partial class Carrera : ContentPage
{
	public Carrera()
	{
		InitializeComponent();
	}
    private void GuardarClicked(object sender, EventArgs e)
    {
        string idCarrera = IdCarreraEntry.Text;
        string nombre = NombreEntry.Text;
        int idFacultad = int.Parse(IdFacultadEntry.Text);
        int idGrado = int.Parse(IdGradoEntry.Text);

        // Aquí puedes realizar el procesamiento de la base de datos

        DisplayAlert("Guardado", "Los datos de la carrera han sido guardados.", "Aceptar");
    }
}