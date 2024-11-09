using System.IO;

namespace CalculadoraMVCMulticapas.Data
{
    public class BitacoraRepository
    {
        private readonly string _path = "Bitacora.txt";

        public void GuardarOperacion(string operacion)
        {
            File.AppendAllText(_path, operacion + Environment.NewLine);
        }

        public string LeerBitacora()
        {
            return File.Exists(_path) ? File.ReadAllText(_path) : "No hay registros..."; 
        }
    }
}
