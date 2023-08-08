using System.Collections.Generic;

namespace Reparacion_Automotriz.Clases
{
    public class OrdenExperto
    {
        //Atributos
        //private string idOrden;
        private Dictionary<string,DiagnosticoE> ordenEpx;
        
        //Constructor
        public OrdenExperto()
        {

        }
        public OrdenExperto( Dictionary<string,DiagnosticoE> OrdenExp )
        {
            this.ordenEpx = OrdenExp;
        }

        //Propiedades
        /*public string IdOrden
        {
            get { return this.idOrden; }
        }*/
        public Dictionary<string,DiagnosticoE> OrdenExp
        {
            get { return this.ordenEpx; }
            set {this.ordenEpx=value;}
        }
        //Métodos

       public void NuevoDiganostico(Dictionary<string, Empleado> DicEmpleados,Dictionary<string, OrdenServicio> DicOrdenesS,Dictionary<string, OrdenExperto> DicDiagnosticos)
       {
            Empleado mEmpleados = new(); //Para usar el método de ver empleados

            Console.WriteLine("Digite número de orden para agregar diagnóstico:");
            string idOrden = Convert.ToString(Console.ReadLine());
            foreach(var item in DicOrdenesS.Keys){Console.WriteLine(item);}
            if(DicOrdenesS.ContainsKey(idOrden))
            {
                if(!DicOrdenesS[idOrden].finalizada){
                    mEmpleados.MostrarEmpleados(DicEmpleados);
                    Console.WriteLine("Digite número de identificación del empleado enacargado de dar el diagnóstico:");
                    string idEmpleado = Convert.ToString(Console.ReadLine());

                    if(DicDiagnosticos.ContainsKey(idEmpleado) )
                    {

                        //Caso en donde ya el experto tiene ordenes en su cola y haya dado un diagnóstico a la orden ingresada
                        if(DicDiagnosticos[idEmpleado].OrdenExp.TryGetValue(idOrden, out DiagnosticoE diagnosticosO)){

                            Console.WriteLine("El empleado ya ha registrado un diágnostico a la orden {0} ", idOrden);
                            Console.WriteLine("Diagnóstico:");
                            foreach(var item in diagnosticosO.Diagnosticos){
                                Console.WriteLine("-"+item);
                            }

                            bool continuar;

                            do{
                                Console.WriteLine("¿Desea agregar nuevo diágnostico?:\n1.Sí\n2.No");

                                int rta = Int32.Parse(Console.ReadLine());
                                if(rta ==1)
                                {   
                                    Console.WriteLine("Ingrese diagnostico:");
                                    DicDiagnosticos[idEmpleado].OrdenExp[idOrden].Diagnosticos.Add( Convert.ToString(Console.ReadLine()));
                                    continuar = true;
                                }else if(rta !=2){
                                    Console.WriteLine("No es un valor válido");
                                    continuar = false;
                                }else{
                                    continuar = false;
                                }

                            }while(continuar);
                            Console.WriteLine("Diagnóstico agregado a la orden {0} de forma correcta", idOrden);
                            MostrarDiagnosticos(DicDiagnosticos,idEmpleado,idOrden);
                        //Caso en donde el experto ya tenga ordenes bajo su cola, pero no haya dado un diagnóstico a la orden ingresada
                        }else{
                            bool continuar;
                            List<string> diagnosticos = new ();
                            do
                            {
                                Console.WriteLine("Ingrese diagnostico del especialista:");
                                diagnosticos.Add(Convert.ToString(Console.ReadLine()));

                                Console.WriteLine("¿Desea ingresar otro diagnóstico?\n1.Sí\n2.No");
                                int rta = Int32.Parse(Console.ReadLine());
                                if(rta ==1)
                                {
                                    continuar = true;
                                }else if(rta !=2){
                                    Console.WriteLine("No es un valor válido");
                                    continuar = false;
                                }else{
                                    continuar = false;
                                }
                            }while(continuar);

                            DiagnosticoE newDiagnostico = new(diagnosticos);
                            DicDiagnosticos[idEmpleado].OrdenExp.Add(idOrden,newDiagnostico);

                            Console.WriteLine("Diagnóstico de experto registrado correctamente!.");

                            MostrarDiagnosticos(DicDiagnosticos,idEmpleado,idOrden);
                        }
                        
                    //Caso en el que el experto no tenga cola de ordenes a su lista.
                    }else if(DicEmpleados.ContainsKey(idEmpleado)){

                        bool continuar;
                        List<string> diagnosticos = new ();
                        do
                        {
                            Console.WriteLine("Ingrese diagnostico del especialista:");
                            diagnosticos.Add(Convert.ToString(Console.ReadLine()));

                            Console.WriteLine("¿Desea ingresar otro diagnóstico?\n1.Sí\n2.No");
                            string rta = Convert.ToString(Console.ReadLine());
                            if(rta =="1")
                            {
                                continuar = true;
                            }else if(rta !="2"){
                                Console.WriteLine("No es un valor válido");
                                continuar = false;
                            }else{
                                continuar = false;
                            }
                        }while(continuar);

                        //Crear diagnostico experto

                        DiagnosticoE newDiagnosticoE = new(diagnosticos);

                        Dictionary<string, DiagnosticoE> dicOrdenE = new();
                        
                        dicOrdenE.Add(idOrden,newDiagnosticoE);
                        
                        OrdenExperto newDiagnostico = new (dicOrdenE);
                        DicDiagnosticos.Add(idEmpleado, newDiagnostico);

                        Console.WriteLine("Diagnóstico de experto registrado correctamente!.");
                    MostrarDiagnosticos(DicDiagnosticos,idEmpleado,idOrden);
                    }else{
                        Console.WriteLine("El número de identificación del empleado no se encuentra registrado.");

                    }

                    
                }else{
                    Console.WriteLine("La orden ya se encuentra finalizada");
                }

                
            }else{
                Console.WriteLine("El n° de orden ingresado no existe en la base de datos. Por favor verificar.");
            }
        }


        public void MostrarDiagnosticos(Dictionary<string, OrdenExperto> DicDiagnosticos, string idEmpleado, string idOrden){
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Diagnósticos de la orden {0}:",idOrden);
            Console.ResetColor();
            foreach(var item in DicDiagnosticos[idEmpleado].OrdenExp[idOrden].Diagnosticos){
                Console.WriteLine("-"+item);
            }
            if(DicDiagnosticos[idEmpleado].OrdenExp[idOrden].OrdenReparacion){
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Estado: ");
                Console.ResetColor();

                Console.WriteLine("Con orden de reparación");
            }else{
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Estado: ");
                Console.ResetColor();

                Console.WriteLine("Sin orden de reparación");
            }
        }

        public void MostrarOrdenes(Dictionary<string, Empleado> DicEmpleados,Dictionary<string, OrdenExperto> DicDiagnosticos, string idEmpleado)
        {
            Console.WriteLine("Ordenes del empleado {0} con ID {1} ",DicEmpleados[idEmpleado].Nombre,idEmpleado);
            Console.WriteLine("Orden\tEstado");
            foreach(var orden in  DicDiagnosticos[idEmpleado].OrdenExp)
            {
                Console.WriteLine("- {0}\t{1}", orden.Key,DicDiagnosticos[idEmpleado].OrdenExp[orden.Key].OrdenReparacion ? "Finalizado":"Sin finalizar");
            }
        }
    }
}