namespace Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Latidud { get; set; }
        public double Longitud { get; set; }
        public string Comuna { get; set; }
        public int Numero { get; set; }
        public string Correo { get; set; }
        public ApplicationUser Email { get; set; }

    }
}