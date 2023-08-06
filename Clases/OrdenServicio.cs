namespace Reparacion_Automotriz.Clases
{
    public class OrdenServicio
    {
        //Atributos
        private string idCliente;
        private string fecha;
        private string idplaca;
        private string diagCliente;
        public bool finalizada {get; set;}

        //Constructor
        public OrdenServicio()
        {

        }
        public OrdenServicio(string IdCliente, string Fecha,string Idplaca,string DiagCliente, bool Finalizada=false)
        {
            this.idCliente = IdCliente;
            this.fecha = Fecha;
            this.idplaca = Idplaca;
            this.diagCliente = DiagCliente;
            this.finalizada = Finalizada;
        }
        //Propiedades
        public string IdCliente
        {
            get { return this.idCliente; }
        }
        public string Fecha
        {
            get { return this.fecha;}
        }

        public string Idplaca{
            get { return this.idplaca;}
        }

        public string DiagCliente
        {
            get { return this.diagCliente;}
        }
        //Métodos

        public void RegistrarOrden(Dictionary<string, Vehiculo> DicVehiculos,Dictionary<string, OrdenServicio> DicOrdenesS )
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********* NUEVA ORDEN DE SERVICIO ************");
            Console.ResetColor();
            
            Console.WriteLine("Digite la placa para asignar orden de servicio:");
            string idVehiculo = Convert.ToString(Console.ReadLine());

            if(DicVehiculos.ContainsKey(idVehiculo))
            {
                
                Console.WriteLine("Ingrese N° de orden de servicio:");    
                string NumeroOrden = Convert.ToString(Console.ReadLine());

                if(!DicOrdenesS.ContainsKey(NumeroOrden))
                {
                    Console.WriteLine("Ingrese fecha de registro formato (YYYY-MM-DD):");
                    string fecha = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Ingrese fecha de registro formato (YYYY-MM-DD):");
                    string diagnosticoCliente = Convert.ToString(Console.ReadLine());

                    string idCliente = DicVehiculos[idVehiculo].IdCliente;

                    OrdenServicio newOrdenS = new (fecha,idCliente,idVehiculo,diagnosticoCliente);

                    DicOrdenesS.Add(NumeroOrden,newOrdenS);
                }else{
                    Console.WriteLine("El número de orden ya existe");
                }
 
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La placa del vehículo no se encuentra registrada");
                Console.ResetColor();
            }
        }

        public void MostrarOrdenes(Dictionary<string, Cliente> DicClientes,Dictionary<string, Vehiculo> DicVehiculos,Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, DiagExperto> DicDiagnosticos)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------ ORDENES DE SERVICIO ------------");
            Console.ResetColor();

            
        }
    }
}