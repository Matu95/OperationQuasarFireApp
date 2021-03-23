# Operación fuego de Quasar
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Información

QuasarApp es un Api Rest que provee servicios para la interpretación de mensajes recibidos por los satélites (kenobi, skywalker y sato) y a partir de estos determinar la posición del emisor de estos mensajes.

## Features

Se encuentra desarrollado en .Net Core(C#) y como base de datos Sql Server. El servicio se encuentra alojado en AWS

https://dlnsw1e7lc.execute-api.us-west-2.amazonaws.com/Prod

La aplicacion cuenta con: 

- MiddlewareException y CustomExceptions
- EntityFramework 
- AmazonLamda

## Arquitectura
![ScreenShot](https://raw.githubusercontent.com/Matu95/OperationQuasarFireApp/main/Files/diagrama.png?token=AGK6OYYBHOMMYAVUY4H62SDALC4LU)

## Ejecución

Puede descargar el collection de postman desde este [ enlace](https://www.getpostman.com/collections/05efd7c963977732a7c3)

| url      | descripción                       |
|:--------------|:----------------------------------|
| `/topsecret`      | Devuelve la posición y mensaje a partir de la distancia y mensajes recibidos
| `/topsecret_split/{satelliteName}`    | Actualiza la posición y mensaje que recibe un satélite en particular
| `/topsecret_split` | Devuelve la posición y mensaje a partir de los datos enviados por el método `/topsecret_split/{satelliteName}`  |

`/topsecret`
***request***
```json
{
   "satellites": [
      {
         "name": "",
         "distance": ,
         "message": []
      }
   ]
}
```
***response***
```json
{
    "position": {
        "x": null,
        "y": null
    },
    "message": null
}
```
`/topsecret_split/{satelliteName}` 
***request***
```json
{
     "distance": null,
     "message": null
}
```
***response***
```json
{
     "distance": null,
     "message": null
}
```
`/topsecret_split/{satelliteName}`
***response***
```json
{
    "position": {
        "x": null,
        "y": null
    },
    "message": ""
}
```

***error***
```json
{
  "messageError": "Descripción del error"
}
```

