using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace From;

public partial class SingInPage : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/Help/Api/POST-api-Usuario";
    public SingInPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped_For_SignUP(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignUp");
    }

    private async Task enviarSingIn()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqSingIn request = new ReqSingIn();
            request.singIn = new Entities.SingIn();

            request.singIn.correo = CorreoEntry.Text;
            request.singIn.clave = ClaveEntry.Text;
            //request.singIn.rol = int.Parse(RolEntry.Text);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "singIn/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResNuevoUsuario res = new ResNuevoUsuario();
                res = JsonConvert.DeserializeObject<ResNuevoUsuario>(responseContent);

                if (res.result)
                {
                    Navigation.PushAsync(new Menu());
                }
                else
                {
                    DisplayAlert("Error en backend", res.listaDeErrores.ToString(), "Acepto");
                }

            }
            else
            {
                //El API esta caido
                DisplayAlert("Error de conexion", "Intente mas tarde", "Aceptar");
            }
        }
        catch (Exception ex) { }
        {
            DisplayAlert("Error", "Llore", "Aceptar");
        }
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(CorreoEntry.Text) && !string.IsNullOrEmpty(ClaveEntry.Text))
        { 
            this.enviarSingIn();
        }
        else 
        {
            await DisplayAlert("Error","Datos faltantes","Aceptar");
        }
    }
}