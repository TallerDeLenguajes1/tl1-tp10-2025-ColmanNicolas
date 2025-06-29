using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using tareaClass;
class Program
{
    static async Task Main()
    {
        // Crear instancia de HttpClient
        HttpClient client = new HttpClient();

        try
        {
            Console.WriteLine("Consultando API...");
            string url = "https://jsonplaceholder.typicode.com/todos/";
            string json = await client.GetStringAsync(url);

            List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(json);

            if (tareas == null)
            {
                Console.WriteLine("No se pudieron recuperar las tareas...");
                return;
            }

            Console.WriteLine("\nTAREAS PENDIENTES:");
            foreach (var unaTarea in tareas.FindAll(t => !t.completed))
            {
                unaTarea.mostrarTarea();
            }

            Console.WriteLine("\nTAREAS REALIZADAS");
            foreach (var unaTarea in tareas.FindAll(t => t.completed))
            {
                unaTarea.mostrarTarea();
            }

            // serializo de nuevo a json
            string jsonSerializado = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "tareas.json");
            await File.WriteAllTextAsync(ruta, jsonSerializado);

            Console.WriteLine($"Tareas guardadas en la ruta: {ruta}");

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
    }
}
