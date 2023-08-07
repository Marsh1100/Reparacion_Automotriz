namespace Reparacion_Automotriz.Clases
{
    public class Repuesto
    {
        //Atributos
        public string Nombre { get; set; }
        public float ValorU { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; } 
        //Constructor
        public Repuesto(string nombre, float valorU, int cantidad, bool estado =false)
        {
            this.Nombre = nombre;
            this.ValorU = valorU;
            this.Cantidad = cantidad;
            this.Estado = estado;
        }
        
    }
}