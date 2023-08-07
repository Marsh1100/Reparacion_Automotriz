
namespace Reparacion_Automotriz.Clases
{
    public class DiagnosticoE
    {
        public List<string> Diagnosticos { get; set; }
        public bool OrdenReparacion { get; set; }


        public DiagnosticoE(){}
        public DiagnosticoE(List<string> diagnosticos, bool ordenReparacion=false){
            this.Diagnosticos = diagnosticos;
            this.OrdenReparacion = ordenReparacion;
        }

        

    }
}