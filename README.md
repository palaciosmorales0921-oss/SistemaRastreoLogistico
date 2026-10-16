# 📦 Sistema de Rastreo Logístico de Paquetes

Sistema que simula el rastreo de paquetes con códigos QR, enviando los datos a Google Sheets en tiempo real.

## 🚀 Características
- Generación de códigos QR únicos por paquete
- Simulación de 5 etapas de rastreo
- Envío automático de datos a Google Sheets
- Consulta de estado por ID de paquete

## 🛠️ Tecnologías
- C# (.NET 10)
- Aspose.BarCode
- Google Sheets API v4
- Google Cloud (Cuenta de Servicio)
- Git y GitHub

## 📋 Requisitos
- .NET 10 SDK
- Cuenta de Google Cloud
- Google Sheet con encabezados

## 🔧 Instalación
```bash
git clone https://github.com/palaciosmorales0921-oss/SistemaRastreoLogistico.git
cd SistemaRastreoLogistico
dotnet restore
dotnet run