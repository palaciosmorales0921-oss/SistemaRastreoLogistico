# Panel de Consulta de Paquetes

Este módulo permitirá al cliente consultar el estado de su paquete
ingresando el ID que aparece en su código QR.

## Endpoints planeados
- GET /track/{id} → Devuelve el estado actual del paquete
- GET /track/{id}/historial → Devuelve todas las etapas

## Estado
- [x] Diseño de la interfaz
- [ ] Implementación del backend
- [ ] Integración con Google Sheets