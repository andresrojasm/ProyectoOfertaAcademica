namespace From;

public partial class OfertaAcademica : ContentPage
{
	public OfertaAcademica()
	{
		InitializeComponent();
	}
    private void GuardarClicked(object sender, EventArgs e)
    {
        int idOferta = int.Parse(IdOfertaEntry.Text);
        string idCurso = IdCursoEntry.Text;
        int idSede = int.Parse(IdSedeEntry.Text);
        int idCuatrimestre = int.Parse(IdCuatrimestreEntry.Text);
        int cedulaDocente = int.Parse(CedulaDocenteEntry.Text);
        DateTime anio = Anio.Date;
        int idHorario = int.Parse(IdHorarioEntry.Text);
        int grupo = int.Parse(GrupoEntry.Text);
        bool estado = Estado.IsToggled;
        int idUsuario = int.Parse(UsuarioEntry.Text);
        // Aquí puedes realizar el procesamiento o almacenamiento de los datos de la oferta académica

        // Por ejemplo, mostrar un mensaje
        DisplayAlert("Guardado", "Los datos de la oferta académica han sido guardados.", "Aceptar");
    }
}