
namespace tareaClass
{
    public class Tarea
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public void mostrarTarea()
        {
            Console.WriteLine($"Usuario nro: {userId}");
            Console.WriteLine($"Tarea nro: {id}");
            Console.WriteLine($"Título: {title}");
            Console.WriteLine($"Completada: {(completed ? "Sí" : "No")}");
            Console.WriteLine();
        }
    }
}
