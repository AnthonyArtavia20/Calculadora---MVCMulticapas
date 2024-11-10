namespace CalculadoraMVCMulticapas.Data
{
    public class BitacoraRepository
    {
        private readonly string _path;

        public BitacoraRepository()
        {
            // Obtener el directorio de la solución
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = currentDirectory;

            // Navegar hacia arriba hasta encontrar la carpeta del proyecto
            while (!File.Exists(Path.Combine(solutionDirectory, "CalculadoraMVCMulticapas.csproj")) &&
                   Directory.GetParent(solutionDirectory) != null)
            {
                solutionDirectory = Directory.GetParent(solutionDirectory).FullName;
            }

            // Combinar con la carpeta Data
            _path = Path.Combine(solutionDirectory, "Data", "Bitácora.txt");

            // Verificar si el directorio existe, si no, crearlo
            string directory = Path.GetDirectoryName(_path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public void GuardarOperacion(string registro)
        {
            try
            {
                List<string> registros = new List<string>();

                //Leer registros existentes para poder añadir o eliminar registros
                if (File.Exists(_path))
                {
                    registros = File.ReadAllLines(_path).ToList();
                }

                //Agregar el nuevo registro
                registros.Add(registro);

                //Si hay más de 10 registros, se elimina el más antiguo:
                if (registros.Count > 10)
                {
                    registros.RemoveAt(0); //Posición 1 de la lista, osea 0.
                }

                //Sobreescribir el archivo con los registros actualizados
                File.WriteAllLines(_path, registros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al escribir en la bitácora: {ex.Message}");
            }
        }

        public string LeerBitacora()
        {
            return File.Exists(_path) ? File.ReadAllText(_path) : "No hay registros...";
        }

        public void GuardarOperacionBasica(double operador1, string operacion, double operador2, double resultado)
        {
            string registro = $"{operador1} {operacion} {operador2} = {resultado}";
            GuardarOperacion(registro);
        }

        public void GuardarOperacionPrimo(double numero, bool esPrimo)
        {
            string registro = $"Primo {numero} {esPrimo}";
            GuardarOperacion(registro);
        }

        public void GuardarOperacionBinario(double numero, string binario)
        {
            string registro = $"Binario {numero} {binario}";
            GuardarOperacion(registro);
        }

        public void GuardarOperacionMemoria(string memoria)
        {
            string registro = $"M+ {memoria}";
            GuardarOperacion(registro);
        }

        public void GuardarOperacionPromedio(string numerosMemoria, double promedio)
        {
            string registro = $"Avg {numerosMemoria} = {promedio}";
            GuardarOperacion(registro);
        }
    }
}