

namespace Reparacion_Automotriz.View
{
    public class Menu
    {
        public Menu(){}

        public string MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n********* CENTRO DE REPARACIÓN AUTOMOTRIZ ************");
            Console.ResetColor();
            
            Console.WriteLine("1.Sección clientes");
            Console.WriteLine("2.Sección empleados");
            Console.WriteLine("0.Salir\n");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Elegir opción:"); Console.ResetColor();            
            string opcion = Convert.ToString(Console.ReadLine());
            
            return opcion;
        }

        public string ClienteMenu(){
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n********* CENTRO DE REPARACIÓN AUTOMOTRIZ ************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************* CLIENTES ***********************");
            Console.ResetColor();

            Console.WriteLine("1.Registrar cliente");
            Console.WriteLine("2.Registrar vehículo");
            Console.WriteLine("3.Registrar Orden de servicio");
            Console.WriteLine("4.Aprobar orden de reparación");
            Console.WriteLine("5.Solicitar factura");
            Console.WriteLine("6.Estado de ordenes de servicio");
            Console.WriteLine("0.Salir");
            
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Elegir opción:"); Console.ResetColor();
            string opcion = Convert.ToString(Console.ReadLine());

            return opcion;
        }

        public string EmpleadoMenu(){
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n********* CENTRO DE REPARACIÓN AUTOMOTRIZ ************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************* EMPLEADOS **********************");
            Console.ResetColor();

            Console.WriteLine("1.Registrar Empleado");
            Console.WriteLine("2.Realizar diagnóstico de orden de servicio");
            Console.WriteLine("3.Realizar orden de reparación");
            Console.WriteLine("4.Ver ordenes de servicios");
            Console.WriteLine("0.Salir");

            
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Elegir opción:"); Console.ResetColor();
            string opcion = Convert.ToString(Console.ReadLine());

            return opcion;
        }
    }
}