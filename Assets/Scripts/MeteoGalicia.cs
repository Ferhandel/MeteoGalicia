using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MeteoGalicia
{
    public List<listaPredicions> listaPredicions;
    public string urlBase;
}

[Serializable]
public class listaPredicions
{
    public string comentario;
    public string comentarioEsp;
    public string dataActualizacion;
    public string dataPredicion;
    public int dia;

    public List<listaMapas> listaMapas;

    public int tendMax;
    public int tendMin;
    public string titulo;

}

[Serializable]
public class listaMapas
{
   public int dia;
   public int franxa;
   public string urlMapa;
}


