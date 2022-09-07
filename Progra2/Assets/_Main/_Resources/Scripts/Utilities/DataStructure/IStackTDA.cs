using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackTDA 
{
    //Ejemplo de la clase del PROFESOR
    void InicializarPila();
    // siempre que la pila est´e inicializada
    void Apilar(int x);
    // siempre que la pila est´e inicializada y no est´e vac´ıa
    void Desapilar();
    // siempre que la pila est´e inicializada
    bool PilaVacia();
    // siempre que la pila est´e inicializada y no est´e vac´ıa
    int Tope();
    void ImprimoPila();


}
