namespace usuarioClass
{
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }

        public override string ToString()
        {
            return $"{street}, {suite}, {city}, zipcode:({zipcode})";
        }
    }

    public class Usuario
    {
        public string name { get; set; }
        public string email { get; set; }
        public Address address { get; set; }

        public void MostrarUsuario()
        {
            Console.WriteLine($"\nUsuario: {name}, Email: {email} \nDomicilio: {address.ToString()}");
        }
    }
}

