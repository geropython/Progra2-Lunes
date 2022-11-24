using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaPrioridadTDA : ColaPrioridad
{
    Jugador[] jugadores; // arreglo en donde se guarda la informacion
    int indice; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados


    public void AcolarPrioridad(Jugador jugador)
    {
        int j;
        // al ingresar cada elemento se 
        for (j = indice; j > 0 && jugadores[j - 1].puntaje >= jugador.puntaje; j--)
        {
            jugadores[j] = jugadores[j - 1];
        }
        jugadores[j] = jugador;

        indice++;
    }

    public bool ColaVacia()
    {
        return (indice == 0);
    }

    public void Desacolar()
    {
        jugadores[indice - 1] = null;
        indice--;
    }

    public void InicializarCola()
    {
        jugadores = new Jugador[100];
        indice = 0;
    }


    public int Prioridad()
    {
        return jugadores[indice - 1].puntaje;
    }

    Jugador ColaPrioridad.Primero()
    {
        return jugadores[indice - 1];
    }



}
