
namespace Reparacion_Automotriz.Clases
{
    public class Factura
    {
    public  List<Repuesto> Repuestos { get; set;}
    public string IdOrden {get; set;}
     public Factura(){

     }

     public Factura( string idOrden,List<Repuesto> repuestos) 
     {
        this.Repuestos = repuestos;
        this.IdOrden = idOrden;
     }


     public void NuevaFactura(Dictionary<string,Factura> DicFacturas, List<Repuesto> repuestos, string idOrden, string idFactura){
        
        Factura newFactura = new(){
            IdOrden = idOrden, Repuestos = repuestos
        };
        DicFacturas.Add(idFactura,newFactura );

     }

    /* public void verFactura(){
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("**************** FACTURA ***************");
        Console.ResetColor();
     }*/

    }
}