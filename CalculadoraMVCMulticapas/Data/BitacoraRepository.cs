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
                File.AppendAllText(_path, registro + Environment.NewLine);
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
    }
}