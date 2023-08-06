namespace Reparacion_Automotriz.Clases
{
    public class OrdenReparacion
    {
        //Atributos
        private string idOrden;
        private string fecha;
        private List<Object> repuestos;

        //Constructor
        public OrdenReparacion()
        {

        }
        public OrdenReparacion(string IdOrden, string Fecha, List<Object> Repuestos)
        {
            this.idOrden = IdOrden;
            this.fecha = Fecha;
            this.repuestos = Repuestos;
        }
        //Propiedades
        public string IdOrden
        {
            get { return this.idOrden; }
        }
        public string Fecha
        {
            get { return this.fecha;}
        }
        public List<Object> Repuestos
        {
            get { return this.repuestos;}
            set { this.repuestos.Add(value);}
        }
        //Métodos
    }
}