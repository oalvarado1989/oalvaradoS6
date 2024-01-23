
using oalvaradoS6.Modelos;
using System.Net;

namespace oalvaradoS6.Vistas;

public partial class ActualizarEliminar : ContentPage
{
	public ActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
		txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
		try
		{
			string codigo = txtCodigo.Text;
			string nombre = txtNombre.Text;
			string apellido = txtApellido.Text;
			string edad = txtEdad.Text;

			string url = "http://localhost/moviles/post.php?codigo=" + codigo + "8&nombre="
				+ nombre + "&apellido=" + apellido + "&edad=" + edad;
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			cliente.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new Inicio());

        }
		catch (Exception ex)
		{

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
		try
		{
			string codigo = txtCodigo.Text;

			string url = "http://localhost/moviles/post.php?codigo=" + codigo;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "DELETE", parametros);
            Navigation.PushAsync(new Inicio());

        }
		catch (Exception ex)
		{

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}