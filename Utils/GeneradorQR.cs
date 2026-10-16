using Aspose.BarCode.Generation;
using System.IO;

namespace SistemaRastreoLogistico.Utils
{
    public class GeneradorQR
    {
        public static string GenerarQR(string idPaquete, string carpetaDestino)
        {
            BarcodeGenerator generador = new BarcodeGenerator(EncodeTypes.QR);
            generador.CodeText = $"https://tusistema.com/track/{idPaquete}";
            
            string rutaArchivo = Path.Combine(carpetaDestino, $"QR_{idPaquete}.png");
            generador.Save(rutaArchivo, BarCodeImageFormat.Png);
            
            return rutaArchivo;
        }
    }
}