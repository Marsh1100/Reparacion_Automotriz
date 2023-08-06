namespace Reparacion_Automotriz.Clases
{
    public class Empleado
    {
        //Atributos
        private string nombre;
        private long telefono;
        private List<string> especialidad;

        //Constructor
        public Empleado()
        {

        }
        public Empleado(string Nombre, long Telefono, List<string> Especialidad)
        {
            this.nombre = Nombre;
            this.telefono = Telefono;
            this.especialidad = Especialidad;
        }

        //Propiedades
        public string Nombre
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public List<string> Especialidad
        {
            get{return this.especialidad;}
            set{this.especialidad.AddRange(value);}
        }
        public long Telefono
        {
            get{return this.telefono;}
            set{this.telefono = value;}
        }


    }
}