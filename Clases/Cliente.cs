namespace Reparacion_Automotriz.Clases
{
    public class Cliente
    {
        //Atributos
        private string nombre;
        private string apellido;
        private long telefono;
        private string email;
        private string fechaRegistro;

        //Constructor
        public Cliente(){

        }

        public Cliente(string Nombre, string Apellido, long Telefono, string Email, string FechaRegistro)
        {
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.telefono = Telefono;
            this.email = Email;
            this.fechaRegistro = FechaRegistro;
        }

        //Propiedades
        public string Nombre
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public string Apellido
        {
            get{return this.apellido;}
            set{this.apellido = value;}
        }
        public string FechaRegistro
        {
            get{return this.fechaRegistro;}
            set{this.fechaRegistro = value;}
        }
        public long Telefono
        {
            get{return this.telefono;}
            set{this.telefono = value;}
        }
        public string Email
        {
            get{return this.email;}
            set{this.email = value;}
        }

    }
}