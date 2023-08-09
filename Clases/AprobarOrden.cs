namespace Reparacion_Automotriz.Clases
{
    public class AprobarOrden
    {
        public string IdOrden { get; set; }
        public string IdEmpleado { get; set; }

        public bool Aprobada {get; set; }

        public AprobarOrden(){}

        public AprobarOrden(string idOrden, string idEmpleado, bool aprobada = false)
        {
            this.IdOrden = idOrden;
            this.IdEmpleado = idEmpleado;
            this.Aprobada= aprobada;
        }

        public void NuevaAprobacion(List<AprobarOrden>ListAprobaciones, string idorden, string idEmpleado)
        {
            AprobarOrden newAprobarOrden = new (idorden,idEmpleado,true);

            ListAprobaciones.Add(newAprobarOrden);
        }
    }
}