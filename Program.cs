using Reparacion_Automotriz.Clases;
internal class Program
{
    //Diccionario clientes
    static Dictionary<string, Cliente> DicClientes = new();
    //Diccionario empleados
    static Dictionary<string, Empleado> DicEmpleado = new();
    //Diccionario vehiculos
    static Dictionary<string, Vehiculo> DicVehiculos = new();
    //Diccionario  Ordenes de servicios
    static Dictionary<string, OrdenServicio> DicOrdenesS = new();
    //Diccionario Diagnósticos de expertos
    static Dictionary<string, DiagExperto> DicDiagnosticos = new();
    //Diccionario Ordenes de reparacion
    static Dictionary<string, OrdenReparacion> DicOrdenesR = new();


    //Metodos de las clases
    static Cliente mClientes = new();
    static Empleado mEmpleado = new();
    static Vehiculo mVehiculo = new();
    static OrdenServicio mOrdenServicio = new();
    static DiagExperto mDiagExperto = new();
    static OrdenReparacion mOrdenReparacion = new();
    
    private static void Main()
    {
        //mClientes.RegistrarCliente(DicClientes);
        
        Cliente falsoCliente = new ("Jaime","Lopez",3004785262,"jaime@gmail.com","2023-08-06");
        DicClientes.Add("111",falsoCliente);
        if(DicClientes.Count != 0)
        {
            mClientes.MostrarClientes(DicClientes);
            mVehiculo.RegistrarVehiculo(DicClientes,DicVehiculos);

        }else{
            Console.WriteLine("No existen clientes en la base de datos, por lo tanto no puede hacer un registro de un vehículo. ");
        }
    }
}