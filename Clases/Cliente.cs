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


        public void MostrarOrdenes(Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, Cliente> DicClientes ){

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
        public void AprobarOrdenServicio(Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, Cliente> DicClientes, Dictionary<string, Vehiculo> DicVehiculos, Dictionary<string, OrdenExperto> DicDiagnosticos, Dictionary<string, Empleado> DicEmpleados, Dictionary<string, OrdenReparacion> DicOrdenesR,List<AprobarOrden> ListAprobaciones)
        {
            //Mostrar Clientes
            MostrarClientes(DicClientes);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************* Aprobar orden de reparación ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del cliente:");
            string idCliente = Convert.ToString(Console.ReadLine());

            if(DicClientes.ContainsKey(idCliente))
                {
                //Se almacenan las ordenes tienen orden de reparación
                List<AprobarOrden> filtrarO = new();
                int cont = 1;
                foreach(var orden in DicOrdenesS){
                    if(idCliente.Equals(orden.Value.IdCliente)){
                        
                        //ERROR AL EXISTIR DOS DIAGNOSTICOS POR PARTE DEL EXPERTO A UNA MISMA ORDENNN , MAYBE ARREGLAR CON ID DE EMPLEADO :D :'D :') :'| :'( :'c :'C

                        foreach(var ordenR in DicOrdenesR){
                            if (ordenR.Value.InfoReparacion.TryGetValue(orden.Key, out _)){

                                filtrarO.Add(new AprobarOrden(){
                                    IdOrden = orden.Key+"-"+cont, IdEmpleado=ordenR.Key 
                                });
                                cont +=1;

                            }
                        }
                        //filtrarO.Add(orden.Key, orden.Value);           
                    }
                }

                if(filtrarO.Count>0){

                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Ordenes de servicio:");                     Console.ResetColor();
                    Console.WriteLine("\nOrden\tPlaca\tFecha\tEmpleado a cargo");

                    foreach(var item in filtrarO){
                        string[] splitOrden = item.IdOrden.Split("-");
                        string placa = DicOrdenesS[splitOrden[0]].Idplaca;
                        string fecha = DicOrdenesS[splitOrden[0]].Fecha;
                        string idempleado =DicEmpleados[item.IdEmpleado].Nombre;

                        Console.WriteLine(item.IdOrden+"\t"+placa+"\t"+fecha+"\t"+idempleado);
                    }

                    Console.WriteLine("\nIngrese la orden que desea aprobar:");
                    string idorden = Convert.ToString(Console.ReadLine());

                    //Obtener ID de la orden y del empleado 
                    string idEmpleado = "0";
                    
                    foreach(var item in filtrarO){
                        if(idorden.Equals(item.IdOrden)){
                            idEmpleado = item.IdEmpleado;
                            break;
                        }
                    }
                    if(idEmpleado != "0"){
                        //Datos para la orden completa de servicio
                        string[] splitOrden = idorden.Split("-");
                        string idOrden = splitOrden[0];
                        string placa = DicOrdenesS[idOrden].Idplaca;
                        string fecha =DicOrdenesS[idOrden].Fecha;
                        string especialidades ="";
                        foreach(var esp in DicEmpleados[idEmpleado].Especialidad){
                            especialidades += "-"+esp+"\n\t";
                        }

                        string diagnosticoExp = "";

                        foreach(var diag in DicDiagnosticos[idEmpleado].OrdenExp[idOrden].Diagnosticos){
                            diagnosticoExp += "-"+diag+"\t";
                        }
                        //Mostrar orden completa
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n**************** DATOS DE LA ORDEN ****************");                     Console.ResetColor();
                        Console.WriteLine("Nro Orden: {0}\t\tFecha: {1}", idorden, fecha);
                        Console.WriteLine("Id Cliente: {0}\t\tNombre Cliente: {1}", idCliente, DicClientes[idCliente].Nombre);

                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("**************** DATOS DEL VEHÍCULO ****************");                     Console.ResetColor();
                        Console.WriteLine("Nro Placa: {0}\t\tKilometraje: {1}", placa, DicVehiculos[placa].Km );

                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("**************** DIAGNÓSTICO CLIENTE ****************");                     Console.ResetColor();
                        Console.WriteLine(DicOrdenesS[idOrden].DiagCliente);
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("**************** DATOS DEL PERSONAL ****************");                     Console.ResetColor();
                        Console.WriteLine("Id Empleado: {0}\t\tNombre: {1}\nEspecialidad:{2}", idEmpleado, DicEmpleados[idEmpleado].Nombre,especialidades);
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("**************** DIAGNÓSTICO EXPERTO ****************");                     Console.ResetColor();
                        Console.WriteLine(diagnosticoExp);
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("*********************************************");                     Console.ResetColor();

                        Console.ReadKey();

                        MostrarOrdenAprobacion(DicOrdenesR,idEmpleado,idorden,ListAprobaciones);


                        foreach(var r in DicOrdenesR[idEmpleado].InfoReparacion[idOrden].Repuestos)
                        {
                            bool continuar;
                            do
                            {
                            Console.WriteLine("¿Desea aprobar el respuesto {0}\n1.Sí\n2.No",r.Nombre);
                            string rta = Convert.ToString(Console.ReadLine());
                                    if(rta =="1")
                                    {
                                        r.Estado = true;
                                        continuar = false;
                                    }else if(rta !="2"){
                                        Console.WriteLine("El valor es inválido");
                                        r.Estado = false;
                                        continuar = true;

                                    }else{
                                        r.Estado = false;
                                        continuar = false;


                                    }
                            }while(continuar);
                        }

                        MostrarOrdenAprobacion(DicOrdenesR,idEmpleado,idorden,ListAprobaciones);

                        AprobarOrden mAprobacion = new();

                        mAprobacion.NuevaAprobacion(ListAprobaciones,idorden,idEmpleado );

                        Console.WriteLine("Su orden de aprobación ha sido generada. Ya puede consultar su factura!");

                        


                    }else{
                        Console.WriteLine("No se encuentra la orden ingresada");
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

        public void MostrarOrdenAprobacion(Dictionary<string, OrdenReparacion> DicOrdenesR, string idEmpleado, string idorden,List<AprobarOrden> ListAprobaciones)
        {
            string[] splitOrden = idorden.Split("-");
            string idOrden = splitOrden[0];

            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n******************** ORDEN DE APROBACIÓN ***************");                     Console.ResetColor(); 
            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n---------------------------------------------------------");Console.ResetColor(); 
            Console.WriteLine("Nro Orden: {0}\tFecha:{1}",idOrden,DicOrdenesR[idEmpleado].InfoReparacion[idOrden].Fecha);
            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n******************** DETALLE DE APROBACIÓN ***************");                     Console.ResetColor(); 
            Console.WriteLine("Item\tRepuesto\tValorU\tCant\tTotal\tEstado");

            int cont = 1;
            foreach(var r in DicOrdenesR[idEmpleado].InfoReparacion[idOrden].Repuestos)
            {
                double total = r.Cantidad *r.ValorU;
                string estado = r.Estado ? "A":"R" ;
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}", cont,r.Nombre, r.ValorU, r.Cantidad,total,estado);
                cont +=1;
            }



            Console.ReadKey();
        }


        public void Facturacion(Dictionary<string, OrdenServicio> DicOrdenesS, Dictionary<string, Cliente> DicClientes,Dictionary<string, Empleado> DicEmpleados,Dictionary<string, OrdenReparacion> DicOrdenesR,List<AprobarOrden> ListAprobaciones, Dictionary<string,Factura> DicFacturas)
        {
            MostrarClientes(DicClientes);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("**************** Facturación ***************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del cliente:");
            string idCliente = Convert.ToString(Console.ReadLine());

            if(DicClientes.ContainsKey(idCliente))
            {
                List<string> filtrarO = new(); //Filtramos las ordenes aprobadas que tenga el cliente.
                foreach(var item in ListAprobaciones)
                {
                    string[] splitOrden = item.IdOrden.Split("-");
                    string idcliente = DicOrdenesS[splitOrden[0]].IdCliente;


                    if(idcliente.Equals(idCliente) && item.Aprobada)
                    {
                        filtrarO.Add(item.IdOrden+"-"+item.IdEmpleado);
                    }
                }

                if(filtrarO.Count > 0){
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Ordenes de servicio apropadas:");                     Console.ResetColor();
                    Console.WriteLine("\nOrden\tPlaca\tFecha\tEmpleado a cargo");

                    foreach(var item in filtrarO){
                        string[] splitOrden = item.Split("-");
                        string placa = DicOrdenesS[splitOrden[0]].Idplaca;
                        string fecha = DicOrdenesS[splitOrden[0]].Fecha;
                        string idempleado =DicEmpleados[splitOrden[2]].Nombre;

                        Console.WriteLine(splitOrden[0]+"-"+splitOrden[1]+"\t"+placa+"\t"+fecha+"\t"+idempleado);
                    }

                    Console.WriteLine("Digite el número de orden para facturación:");
                    string idorden = Convert.ToString(Console.ReadLine());
                    string[] split = idorden.Split("-");
                    string IdOrden = split[0];

                    bool existe = false;
                    string IdEmpleado="";
                    foreach(var item in filtrarO){
                        string[] splitOrden = item.Split("-");
                        string idOrdenE = splitOrden[0]+"-"+splitOrden[1];
                         if(idOrdenE.Equals(idorden)){
                            existe = true;
                            IdEmpleado = splitOrden[2];
                            break;
                         }
                    }

                    if(existe){
                        //facturacion
                        List<Repuesto> repuestosA = DicOrdenesR[IdEmpleado].InfoReparacion[IdOrden].Repuestos;

                        Factura mFactura = new ();
                        string idFactura =  Guid.NewGuid().ToString();//Nro de Factura
                        mFactura.NuevaFactura(DicFacturas, repuestosA, idorden,idFactura);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("*************************** FACTURA ****************************");
                        Console.ResetColor();
                        Console.WriteLine("Nro Orden: {0}\tNro Factura: {1}", idorden, idFactura[..5]); //idFactura.Substring(0,5)
                        Console.WriteLine("Id Cliente: {0}", idCliente);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("*********************** DETALLE FACTURA ************************");
                        Console.ResetColor();

                        Console.WriteLine("Item\tRepuesto\tValorU\tCant\tSubtotal");
                        int cont = 1;
                        double totalRepuestos = 0;
                        foreach(var r in DicOrdenesR[IdEmpleado].InfoReparacion[IdOrden].Repuestos){
                            double subtotal = r.Cantidad *r.ValorU;
                            Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t", cont,r.Nombre, r.ValorU, r.Cantidad,subtotal);
                            cont +=1;
                            totalRepuestos += subtotal;
                        }
                        double iva = totalRepuestos*0.19;
                        double manoObra = totalRepuestos*0.1;
                        double total = totalRepuestos+iva+manoObra;

                        Console.WriteLine("Subtotal:{0}\nIVA:{1}\nMano de Obra: {2}",totalRepuestos, iva, manoObra);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("TOTAL:{0}", total);
                        Console.ResetColor();





                    }else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay factura para ese número de orden");
                        Console.ResetColor();
                    }


                }else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha encontrado niguna orden en estado apropada por parte del cliente :c");
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


        


        
    
