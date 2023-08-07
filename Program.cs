using Reparacion_Automotriz.Clases;
internal class Program
{
    //Diccionario clientes
    static Dictionary<string, Cliente> DicClientes = new();
    //Diccionario empleados
    static Dictionary<string, Empleado> DicEmpleados = new();
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
    static Empleado mEmpleados = new();
    static Vehiculo mVehiculos = new();
    static OrdenServicio mOrdenServicios = new();
    static DiagExperto mDiagExpertos = new();
    static OrdenReparacion mOrdenReparacions = new();
    
    private static void Main()
    {
        //mClientes.RegistrarCliente(DicClientes);
        
        /* Registrar Vehiculo
        Cliente falsoCliente = new ("Jaime","Lopez",3004785262,"jaime@gmail.com","2023-08-06");
        DicClientes.Add("111",falsoCliente);
        if(DicClientes.Count != 0)
        {
            mClientes.MostrarClientes(DicClientes);
            mVehiculos.RegistrarVehiculo(DicClientes,DicVehiculos);

        }else{
            Console.WriteLine("No existen clientes en la base de datos, por lo tanto no puede hacer un registro de un vehículo. ");
        }*/

        //mEmpleados.RegistrarEmpleado(DicEmpleados);


        //Registrar Orden de servicio: Datos de la orden 1.1
        /*if(DicClientes.Count != 0)
        {
            if(DicVehiculos.Count != 0)
            {
                mVehiculos.MostrarVehiculos(DicClientes,DicVehiculos);

                mOrdenServicios.RegistrarOrden(DicVehiculos,DicOrdenesS);
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No vehículos en la base de datos, por lo tanto no puede hacer ninguna orden de servicio");
                Console.ResetColor();
            }

        }else{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existen clientes en la base de datos, por lo tanto no puede hacer ninguna orden de servicio");
            Console.ResetColor();
        }*/

        //Registrar Orden de servicio :diagnostico experto 1.2
        Cliente falsoCliente = new ("Jaime","Lopez",3004785262,"jaime@gmail.com","2023-08-06");
        DicClientes.Add("111",falsoCliente);

        Vehiculo falsoVehiculo = new ("111","2021","Audi","Azul",1500);
        DicVehiculos.Add("KTR477",falsoVehiculo);
        DicVehiculos.Add("UUU000",falsoVehiculo);
        
        List<string> especialidad = new(){"Bailar","Cocinar"};
        Empleado falsoEmpleado = new("Lucas",3004789625,especialidad);
        List<string> especialidad2 = new(){"Cocinar"};
        Empleado falsoEmpleado2 = new("Martin",3004789625,especialidad2);
        DicEmpleados.Add("999",falsoEmpleado);
        DicEmpleados.Add("888",falsoEmpleado2);

        OrdenServicio falsaordenServicio= new("111","2023-08-06","UUU000","Motor quemado :c");
        
        OrdenServicio falsaordenServicio2= new("111","2023-08-06","KTR477","Motor quemado :c");
        DicOrdenesS.Add("001", falsaordenServicio);
        DicOrdenesS.Add("002", falsaordenServicio2);
        DicOrdenesS.Add("003", falsaordenServicio);



        mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);
        mDiagExpertos.NuevoDiganostico(DicEmpleados,DicOrdenesS,DicDiagnosticos);
        mDiagExpertos.NuevoDiganostico(DicEmpleados,DicOrdenesS,DicDiagnosticos);

        mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);


        
    }
}