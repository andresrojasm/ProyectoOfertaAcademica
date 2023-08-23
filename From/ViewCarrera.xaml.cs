using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Text;
using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace From;

public partial class ViewCarrera : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Carrera";

    public List<Entities.Carrera> carrera;

    public ViewCarrera()
	{
		InitializeComponent();
        this.consulta();
    }

    private async Task consulta()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqObtenerListaCarrera request = new ReqObtenerListaCarrera();

            var jsonContent = new HttpCompletionOption();

            var response = await client.GetAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResObtenerListaCarrera res = new ResObtenerListaCarrera();
                res = JsonConvert.DeserializeObject<ResObtenerListaCarrera>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "Se mostraron los datos del usuario !!!", "Aceptar");
                    carrera = res.listaCarrera;
                    DatosViewCarrera.ItemsSource = carrera;
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