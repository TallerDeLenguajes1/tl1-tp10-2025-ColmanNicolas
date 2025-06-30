using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using usuarioClass;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        try
        {
            Console.WriteLine("Consultando API de usuarios...");

            string url = "https://jsonplaceholder.typicode.com/users";
            string json = await client.GetStringAsync(url);

            List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("No se pudieron recuperar los usuarios...");
                return;
            }
            List<Usuario> cincoUsuarios = new List<Usuario>();
            Console.WriteLine("\nPRIMEROS 5 USUARIOS");
            for (int i = 0; i < 5; i++)
            {
                Usuario usu = usuarios[i];
                usu.MostrarUsuario();
                cincoUsuarios.Add(usu);
            }

            //guardo en un csv en el mismo directorio para practicar..

            string jsonSerializado = JsonSerializer.Serialize(cincoUsuarios, new JsonSerializerOptions { WriteIndented = true });

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.json");
            await File.WriteAllTextAsync(ruta, jsonSerializado);

            Console.WriteLine($"\nTareas guardadas correctamente en {ruta}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
    }
}
