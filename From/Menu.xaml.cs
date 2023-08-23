using From.Entities;

namespace From
{

    public partial class Menu : ContentPage
    {
        public Menu(Entities.Usuario u)
        {
            InitializeComponent();
            
            switch (u.rol)
            {
                case 1:
                    OfertaAcademicaBtn.IsVisible = false;
                    ViewOfertaAcademicaBtn.IsVisible = false;
                    break;
                case 2:
                    UsuarioBtn.IsVisible = false;
                    PlanCursoBtn.IsVisible = false;
                    CursoBtn.IsVisible = false;
                    CarreraBtn.IsVisible = false;
                    ViewUsuarioBtn.IsVisible = false;
                    ViewPlanCursoBtn.IsVisible = false;
                    ViewCursoBtn.IsVisible = false;
                    ViewCarreraBtn.IsVisible = false;
                    break;
                default:
                    OfertaAcademicaBtn.IsVisible = false;
                    ViewOfertaAcademicaBtn.IsVisible = false;
                    UsuarioBtn.IsVisible = false;
                    PlanCursoBtn.IsVisible = false;
                    CursoBtn.IsVisible = false;
                    CarreraBtn.IsVisible = false;
                    ViewUsuarioBtn.IsVisible = false;
                    ViewPlanCursoBtn.IsVisible = false;
                    ViewCursoBtn.IsVisible = false;
                    ViewCarreraBtn.IsVisible = false;
                    break;
            }

            DisplayAlert(""
                ,"Bienvenido/a "
                    + u.nombre + " "
                    + u.apellidos + "\n"
                ,"Aceptar");
        }

        private void UsuarioBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Usuario());
        }

        private void PlanCursoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlanCurso());
        }

        private void CursoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Curso());
        }

        private void OfertaAcademicaBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OfertaAcademica());
        }

        private void CarreraBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Carrera());
        }

        private void AcercaBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Acerca());
        }
        private void AtrasBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void ViewUsuarioBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewUsuario());
        }

        private void ViewPlanCursoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewPlanCurso());
        }

        private void ViewCursoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewCurso());
        }

        private void ViewOfertaAcademicaBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewOfertaAcademica());
        }

        private void ViewCarreraBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewCarrera());
        }
    }
}