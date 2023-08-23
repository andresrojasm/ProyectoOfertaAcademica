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
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Login";
    public SingInPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        this.enviarSingIn();
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
            ReqLogin request = new ReqLogin();
            // request.Login = new Entities.Login();

            request.correoDelUsuario = CorreoEntry.Text;
            request.claveDelUsuario = ClaveEntry.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResLogic res = new ResLogic();
                res = JsonConvert.DeserializeObject<ResLogic>(responseContent);

                if (res.result)
                {
                    Navigation.PushAsync(new Menu(res.usuario));
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
}
