namespace Reparacion_Automotriz.Clases
{
    public class OrdenServicio
    {
        //Atributos
        private string idCliente;
        private string fecha;
        private string idplaca;
        private string diagCliente;

        //Constructor
        public OrdenServicio()
        {

        }
        public OrdenServicio(string IdCliente, string Fecha,string Idplaca,string DiagCliente)
        {
            this.idCliente = IdCliente;
            this.fecha = Fecha;
            this.idplaca = Idplaca;
            this.diagCliente = DiagCliente;
        }
        //Propiedades
        public string IdCliente
        {
            get { return this.idCliente; }
        }
        public string Fecha
        {
            get { return this.fecha;}
        }

        public string Idplaca{
            get { return this.idplaca;}
        }

        public string DiagCliente
        {
            get { return this.diagCliente;}
        }
        //Métodos
    }
}