using System.Collections.Generic;

namespace Reparacion_Automotriz.Clases
{
    public class DiagExperto
    {
        //Atributos
        private string idOrden;
        private List<string> diagnosticos;
        //Constructor
        public DiagExperto()
        {

        }
        public DiagExperto(string IdOrden,List<string> Diagnosticos)
        {
            this.idOrden = IdOrden;
            this.diagnosticos = Diagnosticos;
        }
        //Propiedades
        public string IdOrden
        {
            get { return this.idOrden; }
        }
        public List<string> Diagnosticos
        {
            get { return this.diagnosticos; }
            set {this.diagnosticos.AddRange(value);}
        }
        //Métodos
    }
}