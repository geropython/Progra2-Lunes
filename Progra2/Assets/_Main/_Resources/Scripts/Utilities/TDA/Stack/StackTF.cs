using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTF : IStackTDA
{
    int indice;
    int[] a;

    //Ejemplo de la clase del PROFESOR
    public void Apilar(int x)
    {
        a[indice] = x;
        indice++;

    }

    public void Desapilar()
    {
        indice--;
    }

    public void ImprimoPila()
    {
        
    }

    public void InicializarPila()
    {
        a = new int[100];
        indice = 0;
    }

    public void InicializarPila(int c)
    {
        
    }

    public bool PilaVacia()
    {
        return (indice == 0);
    }

    public int Tope()
    {
        return a[indice - 1];
    }

    internal void imprimoPila()
    {
        
    }
}



