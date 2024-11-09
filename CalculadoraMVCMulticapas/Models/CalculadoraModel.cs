namespace CalculadoraMVCMulticapas.Models
{
    //Lógica principal del programa, es decir, la lógica de negocios.

    public class CalculadoraModelClass
    {
        public double Operador1 = 0;
        public double Operador2 = 0;
        public double resultado { get; private set; }

        public double Sumar() => resultado = Operador1 + Operador2;
        public double Restar() => resultado = Operador1 - Operador2;
        public double Multiplicar() => resultado = Operador1 * Operador2;
        public double Dividir()
        {
            if (Operador2 == 0) //En caso de que se haga una forma indeterminada C/0, C= constante.
            {
                throw new DivideByZeroException("Cero en el denominador, no se puede dividir por 0");
            }
            return resultado = Operador1 / Operador2;
        }

        //Se hizo estática para poder acceder a los datos de la instancia
        public static bool EsPrimoONo(int Numero)
        {
            if (Numero < 2)
            {
                return false; //Pues no hay manera de que sea par
            }

            for (int i = 2; i <= Math.Sqrt(Numero); i++)
            {
                if (Numero % i == 0) return false;
            }
            return true;
        }

        public string ConvertirABinario(int Numero) => Convert.ToString(Numero, 2); //Permite hacer conversiones entre bases, en este caso base 2, osea, binario.
    }
}