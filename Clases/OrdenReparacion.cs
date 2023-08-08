namespace Reparacion_Automotriz.Clases
{
    public class OrdenReparacion
    {
        //Atributos
        private Dictionary<string,InfoRepuesto> infoReparacion;

        //Constructor
        public OrdenReparacion()
        {

        }
        public OrdenReparacion(Dictionary<string,InfoRepuesto> InfoReparacion)
        {
            this.infoReparacion = InfoReparacion;
        }
        //Propiedades
       
        public  Dictionary<string,InfoRepuesto> InfoReparacion
        {
            get { return this.infoReparacion;}
            set { this.infoReparacion = value;}
        }
        //Métodos

        public void NuevaOrdenReparacion(Dictionary<string, Empleado> DicEmpleados,Dictionary<string, OrdenServicio> DicOrdenesS,Dictionary<string, OrdenExperto> DicDiagnosticos, Dictionary<string, OrdenReparacion> DicOrdenesR){
            
            Empleado mEmpleados = new Empleado();
            OrdenExperto mDiagExpertos = new();

            mEmpleados.MostrarEmpleados(DicEmpleados);
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------- ORDEN DE REPARACIÓN ---------------");
            Console.ResetColor();

            Console.WriteLine("Ingresar número de cédula del empleado :");
            string idEmpleado = Convert.ToString(Console.ReadLine());

            if(DicDiagnosticos.ContainsKey(idEmpleado))
            {
                //Mostrar ordenes
                mDiagExpertos.MostrarOrdenes(DicEmpleados,DicDiagnosticos,idEmpleado);

                Console.WriteLine("Ingrese número de orden:");
                string idOrden = Convert.ToString(Console.ReadLine())+"-"+idEmpleado;

                if(DicOrdenesR.ContainsKey(idEmpleado)){
                   
                   if(DicOrdenesR[idEmpleado].InfoReparacion.ContainsKey(idOrden)){
                    Console.WriteLine("Esta orden ya esta en estado de aprobación para el cliente");
                   }else{

                     //validar fecha
                    Console.WriteLine("Ingrese fecha de orden de reparación en formato (YYYY-MM-DD):");
                    string fecha = Convert.ToString(Console.ReadLine());

                    bool continuar = true;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Repuestos para aprobación:");
                    Console.ResetColor();
                    do{
                        Console.WriteLine("Ingrese nombre de repuesto:");
                        string nombre = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Ingrese valor unitario del repuesto {0}:",nombre);
                        float valorUnitario = float.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese cantidad del repuesto {0}:",nombre);
                        int cantidad = int.Parse(Console.ReadLine());

                         //Lista de repuestos
                        List<Repuesto> listaRepuestos = new();
                        Repuesto newRepuesto = new(nombre,valorUnitario,cantidad);

                        listaRepuestos.Add(newRepuesto);

                        Console.WriteLine("Repuesto agregado!");

                        Console.WriteLine("¿Desea ingresar otro respuesto?\n1.Sí\n2.No");
                        string rta = Convert.ToString(Console.ReadLine());
                        if(rta =="1")
                        {
                            continuar = true;
                        }else if(rta !="2"){
                            Console.WriteLine("El valor es inválido");
                            continuar = false;
                        }else{
                            InfoRepuesto newInfoRepuesto = new(fecha,listaRepuestos);

                        
                            DicOrdenesR[idEmpleado].InfoReparacion.Add(idOrden,newInfoRepuesto);
                            
                           
                            DicDiagnosticos[idEmpleado].OrdenExp[idOrden].OrdenReparacion = true;

                            continuar = false;
                        }


                    }while(continuar);


                    
                   }
                    

                }else if(DicDiagnosticos.ContainsKey(idEmpleado)){

                     //validar fecha
                    Console.WriteLine("Ingrese fecha de orden de reparación en formato (YYYY-MM-DD):");
                    string fecha = Convert.ToString(Console.ReadLine());

                    bool continuar = true;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Repuestos para aprobación:");
                    Console.ResetColor();
                    do{
                        Console.WriteLine("Ingrese nombre de repuesto:");
                        string nombre = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Ingrese valor unitario del repuesto {0}:",nombre);
                        float valorUnitario = float.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese cantidad del repuesto {0}:",nombre);
                        int cantidad = int.Parse(Console.ReadLine());


                       /* 
                        bool invalido = true;

                       do
                        {
                            Console.WriteLine("Ingrese valor unitario del repuesto {0}:",nombre);
                            if(!float.TryParse(Console.ReadLine(), out float valorUnitario))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Digite un valor válido.");
                                Console.ResetColor();
                            }else
                            {
                                invalido = false;
                            }  
                        }while(invalido);
                        
                        invalido = true;
                        do
                        {
                            Console.WriteLine("Ingrese cantidad del repuesto {0}:",nombre);
                            if(!int.TryParse(Console.ReadLine(), out int cantidad))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Digite un valor válido.");
                                Console.ResetColor();
                            }else
                            {
                                invalido = false;
                            }  
                        }while(invalido);*/

                        //Lista de repuestos
                        List<Repuesto> listaRepuestos = new();
                        Repuesto newRepuesto = new(nombre,valorUnitario,cantidad);

                        listaRepuestos.Add(newRepuesto);

                        Console.WriteLine("Repuesto agregado!");

                        Console.WriteLine("¿Desea ingresar otro respuesto?\n1.Sí\n2.No");
                        string rta = Convert.ToString(Console.ReadLine());
                        if(rta =="1")
                        {
                            continuar = true;
                        }else if(rta !="2"){
                            Console.WriteLine("El valor es inválido");
                            continuar = false;
                        }else{
                            InfoRepuesto newInfoRepuesto = new(fecha,listaRepuestos);

                            Dictionary<string, InfoRepuesto> newOrdenRepuesto = new()
                            {
                                { idOrden, newInfoRepuesto }
                            };

                            OrdenReparacion newOrdenReparacion = new(newOrdenRepuesto);
                            string[] words = idOrden.Split('-');

                            DicOrdenesR.Add(idEmpleado,newOrdenReparacion);
                            DicDiagnosticos[idEmpleado].OrdenExp[words[0]].OrdenReparacion = true;

                            continuar = false;
                        }


                    }while(continuar);

                }else{
                    Console.WriteLine("El número de orden ingresado no esta asociado al empleado. por favor verificar");
                }

            }else{
                Console.WriteLine("El número de cédula ingresado no esta asociado a ninguna orden de servicio");

                
            }
        }


        
    }
}