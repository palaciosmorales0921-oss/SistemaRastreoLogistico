using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaRastreoLogistico.Services
{
    public class GoogleSheetsService
    {
        private SheetsService _servicio = null!;  // ← Se corrige con "= null!"
        private readonly string _spreadsheetId;
        private readonly string _nombreHoja;

        public GoogleSheetsService(string spreadsheetId, string nombreHoja)
        {
            _spreadsheetId = spreadsheetId;
            _nombreHoja = nombreHoja;
            InicializarServicio();
        }

        private void InicializarServicio()
        {
            string[] scopes = { SheetsService.Scope.Spreadsheets };
            string rutaCredenciales = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secret.json");

            using (var stream = new FileStream(rutaCredenciales, FileMode.Open, FileAccess.Read))
            {
                // Se suprime la advertencia de obsolescencia solo para esta línea
                #pragma warning disable CS0618
                var credencial = GoogleCredential.FromStream(stream).CreateScoped(scopes);
                #pragma warning restore CS0618

                _servicio = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credencial,
                    ApplicationName = "SistemaRastreoLogistico"
                });
            }
        }

        public void AgregarEvento(string idPaquete, string estado, string ubicacion, string fechaHora, string responsable)
        {
            var valores = new List<object> { idPaquete, estado, ubicacion, fechaHora, responsable };
            var rango = $"{_nombreHoja}!A:E";
            var cuerpo = new ValueRange { Values = new List<IList<object>> { valores } };

            var peticion = _servicio.Spreadsheets.Values.Append(cuerpo, _spreadsheetId, rango);
            peticion.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            peticion.Execute();
        }
    }
}