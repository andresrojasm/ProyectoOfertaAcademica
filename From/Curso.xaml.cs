using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace From;

public partial class Curso : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/Curso";

    public Curso()
    {
        InitializeComponent();
    }

    private void GuardarClicked(object sender, EventArgs e)
    {
        this.enviarCurso();
    }

    private async Task enviarCurso()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqCurso request = new ReqCurso();
            request.curso = new Entities.Curso();

            request.curso.idCurso = IdCursoEntry.Text;
            request.curso.nombreCurso = NombreCursoEntry.Text;
            request.curso.credito = int.Parse(CreditoEntry.Text);
            request.curso.bloque = int.Parse(BloqueEntry.Text);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResCurso res = new ResCurso();
                res = JsonConvert.DeserializeObject<ResCurso>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "El curso se ingresó con exito!!!", "Aceptar");
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