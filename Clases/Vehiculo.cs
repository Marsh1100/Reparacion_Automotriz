

namespace Reparacion_Automotriz.Clases
{
    public class Vehiculo
    {
        //Atributos
        private string idCliente;
        private string modelo;
        private string marca;
        private string color;
        private long km;
        //Constructor
        public Vehiculo()
        {

        }

        public Vehiculo(string IdCliente, string Modelo,string Marca,string Color,long Km) 
        {
            this.idCliente = IdCliente;
            this.modelo = Modelo;
            this.marca = Marca;
            this.color = Color;
            this.km = Km;
        }

        //Propiedades
        public string IdCliente
        {
            get { return this.idCliente; }
        }
        public string Modelo
        {
            get{return this.modelo; }
        }
        public string Marca{
            get{return this.marca;}
        }
        public string Color
        {
            get{return this.color;}
        }
        public long  Km
        {
            get{return this.km;}
        }
        //Métodos

        public void RegistrarVehiculo(Dictionary<string, Cliente> DicClientes,Dictionary<string, Vehiculo> DicVehiculos)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********* REGISTRO DE VEHÍCULO ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese ID del cliente:");
            string idCliente = Convert.ToString(Console.ReadLine());

            if(DicClientes.ContainsKey(idCliente)){
                Console.WriteLine("Ingrese placa del vehículo:");
                string id = Convert.ToString(Console.ReadLine());

                if(!DicVehiculos.ContainsKey(id))
                {
                    Console.WriteLine("Ingrese modelo del vehículo:");
                    string modelo = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Ingrese marca del vehículo:");
                    string marca = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Ingrese color del vehículo:");
                    string color = Convert.ToString(Console.ReadLine());

                    bool invalido = true;
                    do
                    {
                        Console.WriteLine("Ingrese kilometraje del vehículo:");
                        if(!long.TryParse(Console.ReadLine(), out long km) || km <0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Digite un número de kilometraje válido.");
                            Console.ResetColor();
                        }else
                        {
                            invalido = false;
                        }
                        
                    }while(invalido);

                    Vehiculo newVehiculo = new(idCliente,modelo,marca,color,km);
                    DicVehiculos.Add(id, newVehiculo);
                    
                    Console.WriteLine("Vehiculo registrado de forma exitosa!");
                    Console.WriteLine(DicVehiculos[id].IdCliente, "Pruebita");
                }else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La placa del vehículo ya existe");
                    Console.ResetColor();
                }
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El ID no se encuentra registrado");
                Console.ResetColor();
            } 

        }

        public void MostrarVehiculos(Dictionary<string, Cliente> DicClientes, Dictionary<string, Vehiculo> DicVehiculos )
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------- VEHÍCULOS ---------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dueño\t\tPlaca\tModelo\tMarca\tKilometraje");
            Console.ResetColor();

            foreach(var vehiculo in DicVehiculos)
            {
                string idCliente = vehiculo.Value.IdCliente;
                string dueño = DicClientes[idCliente].Nombre+" "+DicClientes[idCliente].Apellido;

                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", dueño,vehiculo.Key,vehiculo.Value.Modelo, vehiculo.Value.Marca, vehiculo.Value.Km);
                
            }
           
        }


    }
}