using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ColaPrioridad 
{

    // inicializa la estructura
    void InicializarCola();



    // ingresa un elemento a la estructura, ordenandolo por prioridad
    void AcolarPrioridad(Jugador jugador);



    // elimina el "primer" valor de la estructura (el proximo a salir, el de mayor prioridad)
    void Desacolar();



    // indica si hay elementos en la estructura
    bool ColaVacia();


    // devuelve la prioridad del "primer" valor de la estructura (el proximo a salir, el de mayor prioridad)
    int Prioridad();


    Jugador Primero();


}
