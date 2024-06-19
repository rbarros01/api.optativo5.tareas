# API de Clientes y Facturas

## Descripción

Esta API proporciona funcionalidades para validar datos de clientes y facturas, asegurando que la información proporcionada cumpla con ciertos criterios de formato y obligatoriedad.

## Tabla de Contenidos

- [Uso](#uso)
- [Rutas](#rutas)
  - [Clientes](#clientes)
    - [Eliminar Cliente](#eliminar-cliente)
    - [Obtener Cliente](#obtener-cliente)
    - [Listar Clientes](#listar-clientes)
  - [Facturas](#facturas)
    - [Agregar Factura](#agregar-factura)
    - [Actualizar Factura](#actualizar-factura)
    - [Eliminar Factura](#eliminar-factura)
    - [Obtener Factura](#obtener-factura)
    - [Listar Facturas](#listar-facturas)
- [Capturas de Pantalla](#capturas-de-pantalla)
  - [Cliente](#cliente)
    - [Respuesta 200](#respuesta-200)
    - [Respuesta 400](#respuesta-400)
  - [Factura](#factura)
    - [Respuesta 200](#respuesta-200)
    - [Respuesta 400](#respuesta-400)
- [Manejo de Errores](#manejo-de-errores)
- [Contribución](#contribución)

## Uso

La API cuenta con varias rutas para la validación de datos de clientes y facturas. A continuación, se detallan las rutas disponibles y cómo utilizarlas.

## Rutas

### Clientes

#### Agregar Cliente

- `POST /Cliente/AgregarCliente`
  - **Descripción**: Inserta el registro de un cliente.
  - **Parámetros**: 
    - `id`: Integer.
    - `idBanco`: Integer.
    - `nombre`: String, mínimo 3 caracteres.
    - `apellido`: String, mínimo 3 caracteres.
    - `celular`: String, exactamente 10 caracteres numéricos.
    - `documento`: String, mínimo 7 caracteres, único.
    - `email`: String, formato de correo electrónico.
    - `estado`: String.
  - **Respuestas**:
    - **200**: Inserción exitosa. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.
      
#### Actualizar Cliente
- `PUT /Cliente/ActualizarCliente`
  - **Descripción**: Actualiza el registro de un cliente.
  - **Parámetros**: 
    - `id`: Integer.
    - `idBanco`: Integer.
    - `nombre`: String, mínimo 3 caracteres.
    - `apellido`: String, mínimo 3 caracteres.
    - `celular`: String, exactamente 10 caracteres numéricos.
    - `documento`: String, mínimo 7 caracteres, único.
    - `email`: String, formato de correo electrónico.
    - `estado`: String.
  - **Respuestas**:
    - **200**: Actualización exitosa. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.
      
   ### Eliminar Cliente

- `DELETE /Cliente/EliminarCliente/{id}`
  - **Descripción**: Elimina un cliente existente por su ID.
  - **Parámetros**: 
    - `id`: ID del cliente a eliminar.
  - **Respuestas**:
    - **200**: Cliente eliminado exitosamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Obtener Cliente

- `GET /Cliente/ObtenerCliente/{id}`
  - **Descripción**: Obtiene la información de un cliente por su ID.
  - **Parámetros**: 
    - `id`: ID del cliente a obtener.
  - **Respuestas**:
    - **200**: Cliente obtenido exitosamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación. Se muestra un ejemplo de cómo se vería un error de validación.
    - **404**: Cliente no encontrado. Se muestra un ejemplo de cómo se vería un error cuando el cliente no es encontrado.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Listar Clientes

- `GET /Cliente/ListarClientes`
  - **Descripción**: Obtiene una lista de todos los clientes.
  - **Parámetros**: Ninguno.
  - **Respuestas**:
    - **200**: Lista de clientes obtenida exitosamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

### Facturas

#### Agregar Factura

- `POST /Factura/AgregarFactura`
  - **Descripción**: Agrega una nueva factura.
  - **Parámetros**: 
    - `id`: Integer. Identificador unico.
    - `idCliente`: Integer. Id del cliente relacionado.
    - `nroFactura`: String. Numero de la factura.
    - `fechaHora`: DateTime. Fecha y hora de la factura.
    - `total`: Double. Monto total de la factura.
    - `totalIvaCinco`: Double. Total IVA 5%.
    - `totalIvaDiez`: Double. Total IVA 10%.
    - `totalIva`: Double. Total IVA
    - `totalLetras`: String. Total en letras.
    - `sucursal`: Integer. Sucursal relacionado.
  - **Respuestas**:
    - **200**: Factura agregada correctamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación o el cliente no existe. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Actualizar Factura

- `PUT /Factura/ActualizarFactura`
  - **Descripción**: Actualiza una factura existente.
  - **Parámetros**: 
    - `id`: Integer. Identificador unico.
    - `idCliente`: Integer. Id del cliente relacionado.
    - `nroFactura`: String. Numero de la factura.
    - `fechaHora`: DateTime. Fecha y hora de la factura.
    - `total`: Double. Monto total de la factura.
    - `totalIvaCinco`: Double. Total IVA 5%.
    - `totalIvaDiez`: Double. Total IVA 10%.
    - `totalIva`: Double. Total IVA
    - `totalLetras`: String. Total en letras.
    - `sucursal`: Integer. Sucursal relacionado.
  - **Respuestas**:
    - **200**: Factura actualizada correctamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error de validación o el cliente no existe. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Eliminar Factura

- `DELETE /Factura/EliminarFactura/{id}`
  - **Descripción**: Elimina una factura existente por su ID.
  - **Parámetros**: 
    - `id`: ID de la factura a eliminar.
  - **Respuestas**:
    - **200**: Factura eliminada correctamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **400**: Error al eliminar la factura. Se muestra un ejemplo de cómo se vería un error de validación.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Obtener Factura

- `GET /Factura/ObtenerFactura/{id}`
  - **Descripción**: Obtiene la información de una factura por su ID.
  - **Parámetros**: 
    - `id`: ID de la factura a obtener.
  - **Respuestas**:
    - **200**: Factura obtenida exitosamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **404**: Factura no encontrada. Se muestra un ejemplo de cómo se vería un error cuando la factura no es encontrada.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

#### Listar Facturas

- `GET /Factura/ListarFactura`
  - **Descripción**: Obtiene una lista de todas las facturas.
  - **Parámetros**: Ninguno.
  - **Respuestas**:
    - **200**: Lista de facturas obtenida exitosamente. Se muestra un ejemplo de cómo se vería una respuesta exitosa.
    - **204**: No hay contenido para mostrar. Se muestra un ejemplo de cómo se vería una respuesta cuando no hay facturas disponibles.
    - **500**: Error del servidor. Se muestra un ejemplo de cómo se vería un error del servidor.

## Capturas de Pantalla

### Cliente

#### Respuesta 200

Aquí se muestra una captura de pantalla de una respuesta exitosa.

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/727a3a0d-ca58-4ed1-adca-2c11e906489d)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/90e53524-faf6-4438-893d-b5890e0a837d)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/e636f78b-9b81-4806-a02e-d625654376cf)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/dfd96f17-0483-46a9-852f-44a3911e3909)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/00806dba-31aa-4659-a251-05216cf18a3e)

### Respuesta 400

Aquí se muestra una captura de pantalla de un error de validación.

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/518a45e2-b73a-422d-b4c9-cb77d2dd36d9)
![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/53476139-c8e2-45c5-b445-a4e87c142c9e)
![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/8d778ca7-7bdf-4140-b41b-009673a70a84)


### Factura

#### Respuesta 200

Aquí se muestra una captura de pantalla de una respuesta exitosa.

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/d870c255-0934-4332-bff3-1258eaf71b1e)


### Respuesta 400

Aquí se muestra una captura de pantalla de un error de validación.

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/119b7cf7-114a-4a11-9b02-dde075882077)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/7fb5264a-a1a9-481f-b720-2a608f35aa85)

![image](https://github.com/rbarros01/api.optativo5.tareas/assets/146038996/4438ee9d-a1c2-4735-86d6-383ab2b22552)


## Manejo de Errores

La API maneja diferentes tipos de errores y proporciona respuestas claras para cada uno:

- **200 OK**: La solicitud se procesó correctamente.
- **204 No Content**: La solicitud se procesó pero no retornó ningun resultado.
- **400 Bad Request**: Hubo un error en la validación de los datos proporcionados.
- **404 Not Found**: El cliente o la factura no fueron encontrados.

## Contribución

Si deseas contribuir a este proyecto, por favor realiza un fork del repositorio y envía un pull request con tus mejoras.

Este proyecto es mantenido y elaborado por Rolando Barros.

