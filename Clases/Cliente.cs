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
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El ID del cliente ya se encuentra registrado!");
                    Console.ResetColor();
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


        public void MostrarOrdenes(Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, Cliente> DicClientes,Dictionary<string, OrdenExperto> DicDiagnosticos){

            //Mostrar Clientes
            MostrarClientes(DicClientes);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************* Ordenes de servicio ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del cliente:");
            string id = Convert.ToString(Console.ReadLine());

            bool existe = false;
            foreach(var orden in DicOrdenesS){
                if(id.Equals(orden.Value.IdCliente)){
                    Console.WriteLine("-{0}\tEstado:{1}",orden.Key, orden.Value.finalizada ? "Finalizada":"Sin finalizar" );
                    
                    existe = true;
                }
            }

            if(!existe){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ordenes de servicio con ese número de cédula finalizadas.");
                Console.ResetColor();
            }

            Console.ReadKey();

            }
        public void AprobarOrdenServicio(Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, Cliente> DicClientes, Dictionary<string, Vehiculo> DicVehiculos, Dictionary<string, OrdenExperto> DicDiagnosticos, Dictionary<string, Empleado> DicEmpleados)
        {
            //Mostrar Clientes
            MostrarClientes(DicClientes);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************* DATOS DE LA ORDEN ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del cliente:");
            string idCliente = Convert.ToString(Console.ReadLine());

             if(DicClientes.ContainsKey(idCliente))
                {
                    //Se almacenan las ordenes que no estan finalizadas
                Dictionary<string,OrdenServicio> filtrarO = new();
                foreach(var orden in DicOrdenesS){
                    if(idCliente.Equals(orden.Value.IdCliente)){
                        
                        //ERROR AL EXISTIR DOS DIAGNOSTICOS POR PARTE DEL EXPERTO A UNA MISMA ORDENNN , MAYBE ARREGLAR CON ID DE EMPLEADO :D :'D :') :'| :'( :'c :'C
                        foreach(var item in DicDiagnosticos){
                            if(item.Value.OrdenExp.ContainsKey(orden.Key)){
                            if(item.Value.OrdenExp[orden.Key].OrdenReparacion){
                                filtrarO.Add(orden.Key, orden.Value);

                            }
                            }
                        }
                        
                    }
                }

                if(filtrarO.Count>0){
                    Console.WriteLine("\nOrden\tPlaca\tFecha");
                    foreach(var ordenF in filtrarO){
                        Console.WriteLine("{0}\t{1}\t{2}",ordenF.Key,ordenF.Value.Idplaca, ordenF.Value.Fecha);

                    }
                    Console.WriteLine("Ingrese la orden que desea aprobar:");
                    string idorden = Convert.ToString(Console.ReadLine());

                    if(filtrarO.ContainsKey(idorden)){
                        
                        string placa = DicOrdenesS[idorden].Idplaca;
                        foreach(var item in DicDiagnosticos){
                            
                            if(DicDiagnosticos.ContainsKey(item.Key)){
                                if(DicDiagnosticos[item.Key].OrdenExp.ContainsKey(idorden)){
                                    string idEmpleado = item.Key;
                                break;
                                }
                            }
                        }
                        //Mostrar orden completa
                        Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("**************** DATOS DE LA ORDEN ****************");                     Console.ResetColor();
                        Console.WriteLine("Nro Orden: {0}\t\tFecha: {1}", idorden, DicOrdenesS[idorden].Fecha);
                        Console.WriteLine("Id Cliente: {0}\t\tNombre Cliente: {1}", idCliente, DicClientes[idCliente].Nombre);

                        Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("**************** DATOS DEL VEHÍCULO ****************");                     Console.ResetColor();
                        Console.WriteLine("Nro Placa: {0}\t\tKilometraje: {1}", placa, DicVehiculos[placa].Km );

                        Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("**************** DIAGNÓSTICO CLIENTE ****************");                     Console.ResetColor();
                        Console.WriteLine(DicOrdenesS[idorden].DiagCliente);
                        Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("**************** DIAGNÓSTICO EXPERTO ****************");                     Console.ResetColor();
                        Console.WriteLine("Id Empleado: {0}\t\tNombre: {1}", "000", "Pepito");

                        Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("**************************** ****************");                     Console.ResetColor();

                        //Tabla de aprobación
                        Console.WriteLine("");




                        

                    }else{
                        Console.WriteLine("El número de orden no es correcto.");
                    }

                }else{
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aún no hay ordenes para aprobación.");
                    Console.ResetColor();
                }
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El ID del cliente no se encuentra registrado");
                Console.ResetColor();
            }
            
            

        }
        
    }

        
}


        


        
    
