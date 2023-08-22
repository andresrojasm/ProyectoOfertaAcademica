using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace From;

public partial class Carrera : ContentPage
{
    //CAMBIAR LA URL
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Carrera";
    public Carrera()
    {
        InitializeComponent();
    }
    private void GuardarClicked(object sender, EventArgs e)
    {
        this.enviarCarrera();
    }

    private async Task enviarCarrera()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqCarrera request = new ReqCarrera();
            request.carrera = new Entities.Carrera();

            request.carrera.idCarrera = IdCarreraEntry.Text;
            request.carrera.nombre = NombreEntry.Text;
            request.carrera.idFacultad = int.Parse(IdFacultadEntry.Text);
            request.carrera.idGrado = int.Parse(IdGradoEntry.Text);

            //CAMBIAR DIRECCION
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResCarrera res = new ResCarrera();
                res = JsonConvert.DeserializeObject<ResCarrera>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "La carrera se ingresó con exito!!!", "Aceptar");
                }
                else
                {
                    DisplayAlert("Error en backend", res.errorList.ToString(), "Acepto");
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