namespace Reparacion_Automotriz.Clases
{
    public class Empleado
    {
        //Atributos
        private string nombre;
        private long telefono;
        private List<string> especialidad;

        //Constructor
        public Empleado()
        {

        }
        public Empleado(string Nombre, long Telefono, List<string> Especialidad)
        {
            this.nombre = Nombre;
            this.telefono = Telefono;
            this.especialidad = Especialidad;
        }

        //Propiedades
        public string Nombre
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public List<string> Especialidad
        {
            get{return this.especialidad;}
            set{this.especialidad = value;}
        }
        public long Telefono
        {
            get{return this.telefono;}
            set{this.telefono = value;}
        }

        //Metodos

        public void RegistrarEmpleado(Dictionary<string, Empleado> DicEmpleados)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********* REGISTRO DE EMPLEADO ************");
            Console.ResetColor();

            Console.WriteLine("Ingrese número de identificación del empleado:");
            string id = Convert.ToString(Console.ReadLine());

            if(!DicEmpleados.ContainsKey(id))
            {
                Console.WriteLine("Ingrese nombre del empleado:");
                string nombre = Convert.ToString(Console.ReadLine());

                bool invalido = true;
                do
                {
                    Console.WriteLine("Ingrese número móvil del empleado:");
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

                bool continuar;
                List<string> especialidades = new ();
                do
                {
                    Console.WriteLine("Ingrese especialidad del empleado:");
                    especialidades.Add(Convert.ToString(Console.ReadLine()));

                    Console.WriteLine("¿Desea ingresar otra especialidad?\n1.Sí\n2.No");
                    string rta = Convert.ToString(Console.ReadLine());
                    if(rta =="1")
                    {
                        continuar = true;
                    }else if(rta !="2"){
                        Console.WriteLine("El valor es inválido");
                        continuar = false;
                    }else{
                        continuar = false;
                    }
                
                }while(continuar);

                Empleado newEmpleado = new(nombre,telefono,especialidades);

                DicEmpleados.Add(id,newEmpleado);

                Console.WriteLine("Empleado registrado con exito!");

               /* Console.WriteLine(DicEmpleados[id].Especialidad[1]+"  "+DicEmpleados[id].especialidad[2]+"  "+DicEmpleados[id].Nombre+"  "+"Pruebita");*/

                
            }   

    }

    public void MostrarEmpleados(Dictionary<string, Empleado> DicEmpleados)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("----------------- EMPLEADOS ------------------");
        Console.ResetColor();

        Console.WriteLine("ID\tNombre\tEspecialidad");
        foreach(var empleado in DicEmpleados)
        {
            string especialidades="";
            foreach(var especialidad in empleado.Value.Especialidad)
            {
                especialidades += "-"+especialidad+" ";
            }

            Console.WriteLine(empleado.Key+"\t"+empleado.Value.Nombre+"\t"+especialidades);
        }
    }


    }
}