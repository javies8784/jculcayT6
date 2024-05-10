using System.Net;

namespace jculcayT6.Views;

public partial class Vagregar : ContentPage
{
	public Vagregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try

		{
            string url = "http://192.168.1.12/moviles/wsestudiantes.php";

            WebClient client = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			client.UploadValues(url,"POST", parametros);
			Navigation.PushAsync(new Vestudiante());
        }
		catch (Exception)
		{

			throw;
		}

    }
}