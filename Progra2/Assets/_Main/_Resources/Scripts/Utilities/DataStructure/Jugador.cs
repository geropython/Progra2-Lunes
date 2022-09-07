using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public string alias;
    public int puntaje;
    public int nivel;



    public Jugador(string alias, int puntaje, int nivel)
    {
        this.alias = alias;
        this.puntaje = puntaje;
        this.nivel = nivel;
    }



    public Jugador()
    {



    }



}
