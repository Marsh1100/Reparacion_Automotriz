

namespace Reparacion_Automotriz.Clases
{
    public class InfoRepuesto
    {
        public string Fecha { get; set; }
        public List<Repuesto> Repuestos{ get; set; }
        

        public InfoRepuesto(){}
        public InfoRepuesto(string fecha, List<Repuesto> repuestos){
            this.Fecha = fecha;
            this.Repuestos = repuestos;
        }

        
    }
}   