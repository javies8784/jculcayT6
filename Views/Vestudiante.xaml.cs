using jculcayT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace jculcayT6.Views;

public partial class Vestudiante : ContentPage
{
	private const string url = "http://192.168.1.12/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;

    public Vestudiante()
	{
		InitializeComponent();
		
		ObtenerDatos();
	}

	public async void ObtenerDatos() {
		var content = await cliente.GetStringAsync(url);
		

		List<Estudiante>  mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostrar);

        //est.Add(new Estudiante() { codigo = "CODIGO", nombre = "NOMBRE",apellido="APELLIDO",edad="EDAD" });
       

        //groupedAnimal.Add(dogs);
        //groupedAnimal.Add(cats);

        listEstudiantes.ItemsSource = est;
	
	}

}