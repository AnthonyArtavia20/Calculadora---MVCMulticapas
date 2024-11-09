namespace CalculadoraMVCMulticapas.Utils
{
    //Esta clase se usa para verificar que los datos ingresados sean correctos.S

    public static class Validations
    {
        public static bool EsNumero(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}