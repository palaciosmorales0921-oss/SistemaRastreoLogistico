namespace SistemaRastreoLogistico.Models
{
    public class Paquete
    {
        public string Id { get; set; }
        public string EstadoActual { get; set; }
        public string UbicacionActual { get; set; }
        public string Responsable { get; set; }

        public Paquete(string id, string estado, string ubicacion, string responsable)
        {
            Id = id;
            EstadoActual = estado;
            UbicacionActual = ubicacion;
            Responsable = responsable;
        }
    }
}