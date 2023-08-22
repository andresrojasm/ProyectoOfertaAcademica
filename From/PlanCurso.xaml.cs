using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;


namespace From;

public partial class PlanCurso : ContentPage
{
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/";
    public PlanCurso()
    {
        InitializeComponent();
    }

    private void GuardarClicked(object sender, EventArgs e)
    {
        this.enviarPlanCurso();
    }

    private async Task enviarPlanCurso()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqPlanCurso request = new ReqPlanCurso();
            request.planCurso = new Entities.PlanCurso();

            request.planCurso.codigoPlan = IdPlanCursoEntry.Text;
            request.planCurso.nombrePlan = NombrePlanEntry.Text;
            request.planCurso.idCarrera = IdCarreraEntry.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResPlanCurso res = new ResPlanCurso();
                res = JsonConvert.DeserializeObject<ResPlanCurso>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "El plan curso se ingresó con exito!!!", "Aceptar");
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