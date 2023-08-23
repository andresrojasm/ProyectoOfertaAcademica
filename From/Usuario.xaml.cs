using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;


namespace From;

public partial class Usuario : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Usuario";
    public Usuario()
    {
        InitializeComponent();
    }

    private void GuardarClicked(object sender, EventArgs e)
    {
        this.enviarUsuario();
    }

    private async Task enviarUsuario()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqNuevoUsuario request = new ReqNuevoUsuario();
            request.usuario = new Entities.Usuario();

            request.usuario.cedula = int.Parse(CedulaEntry.Text);
            request.usuario.nombre = NombreEntry.Text;
            request.usuario.apellidos = ApellidosEntry.Text;
            request.usuario.edad = int.Parse(EdadEntry.Text);
            request.usuario.correo = CorreoEntry.Text;
            request.usuario.clave = ClaveEntry.Text;
            request.usuario.fechaCreacion = Anio.Date;
            request.usuario.codigoDocente = CodigoDocenteEntry.Text;
            request.usuario.rol = int.Parse(RolEntry.Text);
            request.usuario.activo = Estado.IsToggled;


            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResNuevoUsuario res = new ResNuevoUsuario();
                res = JsonConvert.DeserializeObject<ResNuevoUsuario>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "El usuario se ingresó con exito!!!", "Aceptar");
                }
                else
                {
                    string error = "";
                    foreach (string e in res.errorList)
                    {
                        error += e + "\n";
                    }
                    DisplayAlert("Error", error, "Acepto");
                }

            }
            else
            {
                //El API esta caido
                DisplayAlert("Error de conexion", "Intente mas tarde", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "Contactar a soporte", "Aceptar");
        }
    }
    private void AtrasBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}