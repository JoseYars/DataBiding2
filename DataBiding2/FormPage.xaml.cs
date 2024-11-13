using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBiding2
{
    public partial class FormPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public FormPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Validar entrada de id_rol como entero
            if (!int.TryParse(idRol.Text, out int idRolParsed))
            {
                await DisplayAlert("Error", "El campo de ID de rol debe ser un número", "OK");
                return;
            }

            var persona = new PersonaModel
            {
                nombre = nombre.Text,
                apellido = apellido.Text,
                sexo = sexo.Text,
                fh_nac = fh_nac.Date.ToString("yyyy-MM-dd"),
                id_rol = idRolParsed
            };

            var json = JsonSerializer.Serialize(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Éxito", "La persona se guardó correctamente", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la persona", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al conectar: {ex.Message}", "OK");
            }
        }
    }
}
