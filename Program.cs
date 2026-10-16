using SistemaRastreoLogistico.Models;
using SistemaRastreoLogistico.Services;
using SistemaRastreoLogistico.Utils;
using System;
using System.Threading;

namespace SistemaRastreoLogistico
{
    class Program
    {
        static void Main(string[] args)
        {
            // ⚠️ REEMPLAZA ESTO con el ID real de tu Google Sheet
            string spreadsheetId = "1UanOAdFT18VCqHFQy5LdPRkFpZwYElGnaOmZa2Xp_Fc";
            string nombreHoja = "Hoja 1";

            var sheetsService = new GoogleSheetsService(spreadsheetId, nombreHoja);

            Console.WriteLine("=== SIMULADOR DE RASTREO LOGÍSTICO ===");
            Console.Write("Ingresa el ID del paquete (ej: PKG-001): ");
            string idPaquete = Console.ReadLine() ?? "PKG-DEFAULT";  // ← Se corrige con "?? valor por defecto"

            // Generar el QR
            string rutaQR = GeneradorQR.GenerarQR(idPaquete, AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine($"✅ QR generado en: {rutaQR}");

            // Simular etapas
            string[] etapas = { "En almacén", "En tránsito", "En centro de distribución", "En reparto", "Entregado" };
            string[] ubicaciones = { "Almacén Central", "Ruta Norte", "CD Lima", "Zona Sur", "Domicilio del cliente" };

            for (int i = 0; i < etapas.Length; i++)
            {
                Thread.Sleep(2000);
                var paquete = new Paquete(idPaquete, etapas[i], ubicaciones[i], "Sistema Automático");

                try
                {
                    sheetsService.AgregarEvento(
                        paquete.Id,
                        paquete.EstadoActual,
                        paquete.UbicacionActual,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        paquete.Responsable
                    );
                    Console.WriteLine($"📦 {idPaquete}: {paquete.EstadoActual} - {paquete.UbicacionActual}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error al enviar a Sheets: {ex.Message}");
                }
            }

            Console.WriteLine("\n✅ Simulación completada.");
            Console.ReadLine();
        }
    }
}