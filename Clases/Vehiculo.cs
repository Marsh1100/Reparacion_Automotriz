

namespace Reparacion_Automotriz.Clases
{
    public class Vehiculo
    {
        //Atributos
        private string idCliente;
        private string modelo;
        private string marca;
        private string color;
        private long km;
        //Constructor
        public Vehiculo()
        {

        }

        public Vehiculo(string IdCliente, string Modelo,string Marca,string Color,long Km) 
        {
            this.idCliente = IdCliente;
            this.modelo = Modelo;
            this.marca = Marca;
            this.color = Color;
            this.km = Km;
        }

        //Propiedades
        public string IdCliente
        {
            get { return this.idCliente; }
        }
        public string Modelo
        {
            get{return this.modelo; }
        }
        public string Marca{
            get{return this.marca;}
        }
        public string Color
        {
            get{return this.color;}
        }
        public long  Km
        {
            get{return this.km;}
        }
        //Métodos
    }
}