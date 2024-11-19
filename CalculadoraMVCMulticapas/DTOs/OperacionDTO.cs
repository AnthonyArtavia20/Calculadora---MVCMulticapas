namespace CalculadoraMVCMulticapas.DTOs
{   
    public class OperacionDTO
    {
        public double Operador1 { get; set; }
        public double Operador2 { get; set; }
        public required string Operacion { get; set; }
        public double Resultado { get; set; }
    } 
}