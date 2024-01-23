using Newtonsoft.Json;
using oalvaradoS6.Modelos;
using System.Collections.ObjectModel;

namespace oalvaradoS6.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://localhost/moviles/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public Inicio()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarEstudiante());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objetoestudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActualizarEliminar(objetoestudiante));
    }
}