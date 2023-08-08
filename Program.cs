
using Reparacion_Automotriz.Clases;
using Reparacion_Automotriz.View;
internal class Program
{
    //Otros diccionarios
    //Diccionario clientes
    static Dictionary<string, Cliente> DicClientes = new()
    {
        {"111",new Cliente { Nombre = "Pedro", Apellido = "Pérez", Telefono = 3004178956, Email = "pedro@gmail.com", FechaRegistro = "2023-07-15"}},
        {"222",new Cliente { Nombre = "Marta", Apellido = "Peña", Telefono = 3004178946, Email = "marta@gmail.com", FechaRegistro = "2023-07-15"}}
    };
    //Diccionario empleados
    static Dictionary<string, Empleado> DicEmpleados = new()
    {
        {"123", new Empleado{Nombre = "Jaime", Telefono = 3004178956, Especialidad = new List<string> { "Eléctrico", "Técnico de reparación de carrocerías"}}},
        {"456", new Empleado{Nombre = "Felipe", Telefono = 3214758596, Especialidad = new List<string> { "Técnico de neumáticos"}}}
    };
    //Diccionario vehiculos
    static Dictionary<string, Vehiculo> DicVehiculos = new()
    {
        {"KYT475", new Vehiculo{IdCliente="111",Modelo="2020",Marca="Renault",Color="Rojo",Km=10366}},
        {"UUU000", new Vehiculo{IdCliente="111",Modelo="2015",Marca="Toyota",Color="Blanco",Km=18560}},
        {"EEE000", new Vehiculo{IdCliente="222",Modelo="2023",Marca="Renault",Color="Rojo",Km=5000}},

    };
    //Diccionario  Ordenes de servicios
    static Dictionary<string, OrdenServicio> DicOrdenesS = new()
    {
        {"001", new OrdenServicio{IdCliente = "111", Fecha = "2023-08-06", Idplaca="KYT475", DiagCliente="El carro se apaga a cada rato", finalizada=false}},
        
        {"002", new OrdenServicio{IdCliente = "111", Fecha = "2023-08-07", Idplaca="KYT475", DiagCliente="El carro no arranca", finalizada=false}},
        
        {"003", new OrdenServicio{IdCliente = "222", Fecha = "2023-08-06", Idplaca="EEE000", DiagCliente="Tiene el freno largo", finalizada=false}}
    };
    //Diccionario Diagnósticos de expertos

    static Dictionary<string, OrdenExperto> DicDiagnosticos = new();
    //Diccionario Ordenes de reparacion
    static Dictionary<string, OrdenReparacion> DicOrdenesR = new();


    //Metodos de las clases
    static Cliente mClientes = new();
    static Empleado mEmpleados = new();
    static Vehiculo mVehiculos = new();
    static OrdenServicio mOrdenServicios = new();
    static OrdenExperto mDiagExpertos = new();
    static OrdenReparacion mOrdenReparaciones = new();

    static Menu menu = new();
    private static void Main()
    {


        string opcion;
        do{
            opcion = menu.MainMenu();

            switch(opcion){
                case "1": //Sección clientes
                    SeccionClientes();
                    break;
                case "2": //Sección empleado
                    SeccionEmpleados();

                    break;
                case "0": //Salir
                    break;
                default:
                    Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("No es un valor válido"); Console.ResetColor();
                    Console.ReadKey();
                    break;
            }


        }while(opcion != "0");
        //mClientes.RegistrarCliente(DicClientes);
       // mClientes.MostrarClientes(DicClientes);
        //mVehiculos.MostrarVehiculos(DicClientes,DicVehiculos);
        //mEmpleados.MostrarEmpleados(DicEmpleados);
       // mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos1);


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

        
        /*List<string> especialidad = new(){"Bailar","Cocinar"};
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

        
        List<string> diagnostico1 = new(){"Filtro de aire necesita cambio", "Cambio de refrigerante"};
        List<string> diagnostico2 = new(){"Cambio pastillas de freno"};
        
        //Crear diagnostico experto
        Dictionary<string, List<string>> dicOrdenE = new();
        dicOrdenE.Add("001",diagnostico1);
        Dictionary<string, List<string>> dicOrdenE2 = new();
        dicOrdenE2.Add("001",diagnostico2);

        
        OrdenExperto falsoDiag = new();
        OrdenExperto falsoDiag2 = new(dicOrdenE2);

        //DicDiagnosticos.Add("999",falsoDiag);
        //DicDiagnosticos.Add("888",falsoDiag2);
        //DicDiagnosticos["888"].Diagnosticos.Add("002",diagnostico1);

        mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);
        mDiagExpertos.NuevoDiganostico(DicEmpleados,DicOrdenesS,DicDiagnosticos);
        mDiagExpertos.NuevoDiganostico(DicEmpleados,DicOrdenesS,DicDiagnosticos);

        mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);

        //Asignar orden de reparacion 
        mOrdenReparacions.NuevaOrdenReparacion(DicEmpleados,DicOrdenesS,DicDiagnosticos,DicOrdenesR);
        mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);

        //generar facturas*/
        
    }

    public static void SeccionClientes(){
        string opcion;
        do{
            opcion = menu.ClienteMenu();

            switch(opcion){
                case "1": //Registrar cliente
                    mClientes.RegistrarCliente(DicClientes);
                    break;
                case "2": //Registrar vehículo
                    mVehiculos.RegistrarVehiculo(DicClientes,DicVehiculos);
                    break;
                case "3": //Registrar Orden de servicio
                    mOrdenServicios.RegistrarOrden(DicVehiculos,DicOrdenesS);
                    break;
                case "4": //Aprobar orden de reparación
                    //Mostrar ordenes
                    mClientes.AprobarOrdenServicio(DicOrdenesS,DicClientes,DicVehiculos,DicDiagnosticos, DicEmpleados);
                    break;
                case "5": //Solicitar factura
                    break;
                case "6": //Mostrar Ordenes de servicio
                        mClientes.MostrarOrdenes(DicOrdenesS, DicClientes,DicDiagnosticos);

                    break;
                case "0": //Salir
                    break;
                default:
                    Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("No es un valor válido"); Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

        }while(opcion != "0");
    }

     public static void SeccionEmpleados(){
        string opcion;
        do{
            opcion = menu.EmpleadoMenu();

            switch(opcion){
                case "1": //Registrar Empleado
                    mEmpleados.RegistrarEmpleado(DicEmpleados);
                    break;
                case "2": //Realizar diagnóstico de orden de servicio
                    mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);
                    mDiagExpertos.NuevoDiganostico(DicEmpleados,DicOrdenesS,DicDiagnosticos);
                    break;
                case "3": //Realizar orden de reparación
                    mOrdenReparaciones.NuevaOrdenReparacion(DicEmpleados,DicOrdenesS,DicDiagnosticos,DicOrdenesR);
                    break;
                case "4": //Ver ordenes de servicio
                    mOrdenServicios.MostrarOrdenes(DicOrdenesS,DicDiagnosticos);
                    break;
                case "0": //Salir
                    break;
                default:
                    Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("No es un valor válido"); Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

        }while(opcion != "0");
    }
}