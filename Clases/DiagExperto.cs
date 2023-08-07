using System.Collections.Generic;

namespace Reparacion_Automotriz.Clases
{
    public class DiagExperto
    {
        //Atributos
        //private string idOrden;
        private Dictionary<string,List<string>> diagnosticos;
        //Constructor
        public DiagExperto()
        {

        }
        public DiagExperto( Dictionary<string,List<string>> Diagnosticos)
        {
            this.diagnosticos = Diagnosticos;
        }

        //Propiedades
        /*public string IdOrden
        {
            get { return this.idOrden; }
        }*/
        public Dictionary<string,List<string>> Diagnosticos
        {
            get { return this.diagnosticos; }
            set {this.diagnosticos=value;}
        }
        //Métodos

       public void NuevoDiganostico(Dictionary<string, Empleado> DicEmpleados,Dictionary<string, OrdenServicio> DicOrdenesS,Dictionary<string, DiagExperto> DicDiagnosticos)
       {
            Empleado mEmpleados = new(); //Para usar el método de ver empleados

            Console.WriteLine("Digite número de orden para agregar diagnóstico:");
            string idOrden = Convert.ToString(Console.ReadLine());

            if(DicOrdenesS.ContainsKey(idOrden))
            {
                mEmpleados.MostrarEmpleados(DicEmpleados);
                Console.WriteLine("Digite número de identificación del empleado enacargado de dar el diagnóstico:");
                string idEmpleado = Convert.ToString(Console.ReadLine());

                if(DicDiagnosticos.ContainsKey(idEmpleado) )
                {
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

                    //Crear diagnostico experto
                    Dictionary<string, List<string>> dicOrdenE = new();
                    dicOrdenE.Add(idOrden,diagnosticos);
                    
                    DiagExperto newDiagnostico = new (dicOrdenE);
                    DicDiagnosticos.Add(idEmpleado, newDiagnostico);

                    Console.WriteLine("Diagnóstico de experto registrado correctamente!.");

                }else{
                    Console.WriteLine("El número de identificación del empleado no se encuentra registrado.");

                }
            }else{
                Console.WriteLine("El n° de orden ingresado no existe en la base de datos. Por favor verificar.");
            }
       }
    }
}