namespace From;

public partial class Usuario : ContentPage
{
	public Usuario()
	{
		InitializeComponent();
	}

    private void GuardarClicked(object sender, EventArgs e)
    {
        string cedula = CedulaEntry.Text;
        string nombre = NombreEntry.Text;
        string apellidos = ApellidosEntry.Text;
        int edad = int.Parse(EdadEntry.Text);
        string correo = CorreoEntry.Text;
        string codigoDocente = CodigoDocenteEntry.Text;
        string rol = RolEntry.Text;
        string clave = ClaveEntry.Text;
        DateTime fechaCreacion = Anio.Date;
        bool activo = Estado.IsToggled;

        DisplayAlert("Guardado", "Los datos del usuario han sido guardados.", "Aceptar");
    }
}