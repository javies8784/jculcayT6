using jculcayT6.Models;
using Newtonsoft.Json;
using Steeltoe.Common.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace jculcayT6.Views;

public partial class VactualizarEliminar : ContentPage
{
    private HttpClient client;
    public VactualizarEliminar()
	{
		InitializeComponent();
        client = new HttpClient();
    }

    public VactualizarEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();

        
    }


    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
                
        var url = "http://192.168.1.12/moviles/wsestudiantes.php";
        string parametros = $"codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";         

        using (var client = new WebClient())
        {
            
            var urlCompleta = $"{url}?{parametros}";
            byte[] parametrosBytes = Encoding.ASCII.GetBytes(parametros);
            byte[] responseBytes = client.UploadData(urlCompleta, "PUT", parametrosBytes);
            string responseData = Encoding.ASCII.GetString(responseBytes);
            // Manejar la respuesta
            Console.WriteLine(responseData);
            DisplayAlert("Alerta", "Item Actualizado Correctamente"+ responseData, "OK");
            
        }
        Navigation.PushAsync(new Vestudiante());
    }

    
    private void btnEliminar_Clicked(object sender, EventArgs e)
    {        
        var url = "http://192.168.1.12/moviles/wsestudiantes.php";
        string parametros = $"codigo={txtCodigo.Text}"; 
        using (var client = new WebClient())
        {            
            var urlCompleta = $"{url}?{parametros}";
            var respuesta = client.UploadData(urlCompleta, "DELETE", new byte[0]);
            
            DisplayAlert("Alerta", "Item eliminado Correctamente", "OK");
            
        }
        Navigation.PushAsync(new Vestudiante());


    }


}