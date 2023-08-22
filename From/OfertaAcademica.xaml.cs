using From.Entities.Request;
using From.Entities.Response;
using From.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace From;

public partial class OfertaAcademica : ContentPage
{
    //CAMBIAR DIRECCION
    public String laURL = "https://sistema-oferta-academica.azurewebsites.net/api/OfertaAcademica";
    public OfertaAcademica()
    {
        InitializeComponent();
    }
    private void GuardarClicked(object sender, EventArgs e)
    {
        this.enviarOfertaAcademica();
    }

    private async Task enviarOfertaAcademica()
    {
        try
        {
            HttpClient client = new HttpClient();
            ReqOfertaAcademica request = new ReqOfertaAcademica();
            request.ofertaAcademica = new Entities.OfertaAcademica();

            request.ofertaAcademica.idOferta = int.Parse(IdOfertaEntry.Text);
            request.ofertaAcademica.idCurso = IdCursoEntry.Text;
            request.ofertaAcademica.idSede = int.Parse(IdSedeEntry.Text);
            request.ofertaAcademica.idCuatrimestre = int.Parse(IdCuatrimestreEntry.Text);
            request.ofertaAcademica.cedulaDocente = int.Parse(CedulaDocenteEntry.Text);
            request.ofertaAcademica.año = Anio.Date;
            request.ofertaAcademica.idHorario = int.Parse(IdHorarioEntry.Text);
            request.ofertaAcademica.grupo = int.Parse(GrupoEntry.Text);
            request.ofertaAcademica.estado = Estado.IsToggled;
            request.ofertaAcademica.usuario = int.Parse(UsuarioEntry.Text);

            //HAY QUE CAMBIAR LA DIRECCION DE LA API
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"); ;

            var response = await client.PostAsync(laURL, jsonContent); //Aqui se envía al API

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(); //aqui recibo del API
                ResOfertaAcademica res = new ResOfertaAcademica();
                res = JsonConvert.DeserializeObject<ResOfertaAcademica>(responseContent);

                if (res.result)
                {
                    DisplayAlert("Felicidades", "La oferta academica se ingresó con exito!!!", "Aceptar");
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