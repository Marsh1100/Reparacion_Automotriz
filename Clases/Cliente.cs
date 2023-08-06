namespace Reparacion_Automotriz.Clases
{
    public class Cliente
    {
        //Atributos
        private string nombre;
        private string apellido;
        private long telefono;
        private string email;
        private string fechaRegistro;

        //Constructor
        public Cliente(){

        }

        public Cliente(string Nombre, string Apellido, long Telefono, string Email, string FechaRegistro)
        {
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.telefono = Telefono;
            this.email = Email;
            this.fechaRegistro = FechaRegistro;
        }

        //Propiedades
        public string Nombre
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public string Apellido
        {
            get{return this.apellido;}
            set{this.apellido = value;}
        }
        public string FechaRegistro
        {
            get{return this.fechaRegistro;}
            set{this.fechaRegistro = value;}
        }
        public long Telefono
        {
            get{return this.telefono;}
            set{this.telefono = value;}
        }
        public string Email
        {
            get{return this.email;}
            set{this.email = value;}
        }

        //Metodos 

        public void RegistrarCliente(Dictionary<string, Cliente> DicClientes)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********* REGISTRO DE CLIENTE ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del cliente:");
            string id = Convert.ToString(Console.ReadLine());

            if(!DicClientes.ContainsKey(id))
            {
                Console.WriteLine("Ingrese nombre del cliente:");
                string nombre = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Ingrese apellido del cliente:");
                string apellido = Convert.ToString(Console.ReadLine());
                bool invalido = true;
                do
                {
                    Console.WriteLine("Ingrese número móvil del cliente:");
                    if(!long.TryParse(Console.ReadLine(), out long telefono) || Convert.ToString(telefono).Length !=10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Digite un número de teléfono válido.");
                        Console.ResetColor();
                    }else
                    {
                        invalido = false;
                    }
                    
                }while(invalido);

                Console.WriteLine("Ingrese email del cliente:");
                string email = Convert.ToString(Console.ReadLine());

                //validar fecha
                Console.WriteLine("Ingrese fecha de registro formato (YYYY-MM-DD):");
                string fecha = Convert.ToString(Console.ReadLine());

                Cliente newCliente = new(nombre,apellido,telefono,email,fecha);
                DicClientes.Add(id,newCliente);

                Console.WriteLine("Cliente registrado con exito!");
            }
        }

        public void MostrarClientes(Dictionary<string, Cliente> DicClientes)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------- CLIENTES ---------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("ID\tNombre\tApellido");
            Console.ResetColor();

            foreach(var cliente in DicClientes)
            {
                Console.WriteLine(cliente.Key+"\t"+cliente.Value.Nombre+"\t"+cliente.Value.Apellido);
            }

        }

    }
}