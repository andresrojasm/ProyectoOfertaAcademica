using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Text;
using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace From;

public partial class ViewUsuario : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Usuario";

    public List<Entities.Usuario> usuarios;

    public ViewUsuario()
    {
        InitializeComponent();
        this.consulta();
    }

    private async Task consulta()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqObtenerListaNuevoUsuario request = new ReqObtenerListaNuevoUsuario();

            var jsonContent = new HttpCompletionOption();

            var response = await client.GetAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResObtenerListaNuevoUsuario res = new ResObtenerListaNuevoUsuario();
                res = JsonConvert.DeserializeObject<ResObtenerListaNuevoUsuario>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "Se mostraron los datos del usuario !!!", "Aceptar");
                    usuarios = res.listaUsuario;
                    DatosViewUsuario.ItemsSource = usuarios;
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