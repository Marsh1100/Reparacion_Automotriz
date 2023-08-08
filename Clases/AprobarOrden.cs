namespace Reparacion_Automotriz.Clases
{
    public class AprobarOrden
    {
        public string IdOrden { get; set; }
        public string IdEmpleado { get; set; }

        public AprobarOrden(){}

        public AprobarOrden(string idOrden, string idEmpleado)
        {
            this.IdOrden = idOrden;
            this.IdEmpleado = idEmpleado;
        }

    }
}