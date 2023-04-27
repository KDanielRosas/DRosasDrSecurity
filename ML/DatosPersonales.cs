namespace ML
{
    public class DatosPersonales
    {
        public int IdDatosPersonales { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public Estado EstadoNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public Direccion Direccion { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public List<ML.DatosPersonales> List { get; set; }
    }
}