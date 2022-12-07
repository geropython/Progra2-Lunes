using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABB_TEST : MonoBehaviour
{
    [SerializeField] ItemData _normalCrystal;
    [SerializeField] ItemData _blueCrystal;
    [SerializeField] ItemData _redCrystal;
    [SerializeField] ItemData _purpleCrystal;
    [SerializeField] ItemData _greenCrystal;
    [SerializeField] ItemData _orangeCrystal;
    [SerializeField] ItemData _pinkCrystal;

    private static int _normalCrystalScore;
    private static int _blueCrystalScore;
    private static int _redCrystalScore;
    private static int _purpleCrystalScore;
    private static int _greenCrystalScore;
    private static int _orangeCrystalScore;
    private static int _pinkCrystalScore;

    private ABB _arbol = new ABB();

    private int[] crystals = new int[] { _normalCrystalScore, _blueCrystalScore, _redCrystalScore, _purpleCrystalScore, _greenCrystalScore, _orangeCrystalScore, _pinkCrystalScore };
    

    

    void Start()
    {
        _normalCrystalScore = _normalCrystal.score;
        _blueCrystalScore = _blueCrystal.score; 
        _redCrystalScore = _redCrystal.score;
        _purpleCrystalScore = _purpleCrystal.score;
        _greenCrystalScore = _greenCrystal.score;
        _orangeCrystalScore = _orangeCrystal.score;
        _pinkCrystalScore = _pinkCrystal.score;

        _arbol.InicializarArbol();

        for(int i = 0; i < crystals.Length; i++)
        {
            _arbol.AgregarElem(ref _arbol.raiz, crystals[i]);
        }

        int aTotal = altura(_arbol.raiz);
        Debug.Log("\nAltura total del arbol: " + aTotal.ToString());

        //// Pre-Order
        //preOrder(_arbol.raiz);
        //Debug.Log("\nImpresión en Pre-Order");

        //// In-Order
        //Debug.Log("\nImpresión en In-Order");
        //inOrder(_arbol.raiz);

        //// Post-Order
        //Debug.Log("\nImpresión en Post-Order");
        //postOrder(_arbol.raiz);

        //// Level-Order
        //Debug.Log("\nImpresión en Level-Order");
        //levelOrder(_arbol.raiz);

        //// Alturas con Pre-Order
        //Debug.Log("\nAlturas recorriendo con Pre-Order");
        //preOrder_FE(_arbol.raiz);
    }


    // Update is called once per frame
    void Update()
    {
        // Post-Order
        Debug.Log("\nImpresión en Post-Order");
        postOrder(_arbol.raiz);
    }

    static int altura(NodoABB ab)
    {
        if (ab == null)
        {
            return -1;
        }
        else
        {
            return (1 + Math.Max(altura(ab.hijoIzq), altura(ab.hijoDer)));
        }
    }

    static void preOrder_FE(NodoABB a)
    {
        if (a != null)
        {
            //accion mientras recorro //
            Debug.Log("Nodo Padre: " + a.score.ToString());
            Debug.Log("Altura Izquierda: " + altura(a.hijoDer));
            Debug.Log("Altura Derecha: " + altura(a.hijoIzq));
            Console.WriteLine();


            preOrder_FE(a.hijoIzq);
            preOrder_FE(a.hijoDer);
        }
    }

    static void preOrder(NodoABB a)
    {
        if (a != null)
        {
            Debug.Log(a.score.ToString());
            preOrder(a.hijoIzq);
            preOrder(a.hijoDer);
        }
    }

    static void inOrder(NodoABB a)
    {
        if (a != null)
        {

            inOrder(a.hijoIzq);
            Debug.Log(a.score.ToString());
            inOrder(a.hijoDer);
        }
    }

    static void postOrder(NodoABB a)
    {
        if (a != null)
        {
            postOrder(a.hijoIzq);
            postOrder(a.hijoDer);
            Debug.Log(a.score.ToString());
        }
    }

    static void level_Order(NodoABB nodo)
    {
        Queue<NodoABB> q = new Queue<NodoABB>();

        q.Enqueue(nodo);

        while (q.Count > 0)
        {
            nodo = q.Dequeue();

            Debug.Log(nodo.score.ToString());

            if (nodo.hijoIzq != null) { q.Enqueue(nodo.hijoIzq); }

            if (nodo.hijoDer != null) { q.Enqueue(nodo.hijoDer); }
        }
    }

    static void levelOrder(NodoABB nodo)
    {
        Queue<NodoABB> q = new Queue<NodoABB>();

        q.Enqueue(nodo);

        while (q.Count > 0)
        {
            nodo = q.Dequeue();

            Debug.Log("Padre: " + nodo.score.ToString());

            if (nodo.hijoIzq != null)
            {
                q.Enqueue(nodo.hijoIzq);
                Debug.Log("Hijo Izq: " + nodo.hijoIzq.score.ToString());
            }
            else
            {
                Debug.Log("Hijo Izq: null");
            }

            if (nodo.hijoDer != null)
            {
                q.Enqueue(nodo.hijoDer);
                Debug.Log("Hijo Der: " + nodo.hijoDer.score.ToString());
            }
            else
            {
                Debug.Log("Hijo Der: null");
            }
        }
    }
}

public interface ABBTDA
{
    int Raiz();
    NodoABB HijoIzq();
    NodoABB HijoDer();
    bool ArbolVacio();
    void InicializarArbol();
    void AgregarElem(ref NodoABB n, int x);
    void EliminarElem(ref NodoABB n, int x);
}

public class NodoABB
{
    // datos a almacenar, en este caso un entero
    public int score;
    // referencia los nodos izquiero y derecho
    public NodoABB hijoIzq = null;
    public NodoABB hijoDer = null;
}

public class ABB : ABBTDA
{
    public NodoABB raiz;

    public int Raiz()
    {
        return raiz.score;
    }

    public bool ArbolVacio()
    {
        return (raiz == null);
    }

    public void InicializarArbol()
    {
        raiz = null;
    }

    public NodoABB HijoDer()
    {
        return raiz.hijoDer;
    }

    public NodoABB HijoIzq()
    {
        return raiz.hijoIzq;
    }

    public void AgregarElem(ref NodoABB raiz, int x)
    {
        if (raiz == null)
        {
            raiz = new NodoABB();
            raiz.score = x;
        }
        else if (raiz.score > x)
        {
            AgregarElem(ref raiz.hijoIzq, x);
        }
        else if (raiz.score < x)
        {
            AgregarElem(ref raiz.hijoDer, x);
        }
    }

    public void EliminarElem(ref NodoABB raiz, int x)
    {
        if (raiz != null)
        {
            if (raiz.score == x && (raiz.hijoIzq == null) && (raiz.hijoDer == null))
            {
                raiz = null;
            }
            else if (raiz.score == x && raiz.hijoIzq != null)
            {
                raiz.score = this.mayor(raiz.hijoIzq);
                EliminarElem(ref raiz.hijoIzq, raiz.score);
            }
            else if (raiz.score == x && raiz.hijoIzq == null)
            {
                raiz.score = this.menor(raiz.hijoDer);
                EliminarElem(ref raiz.hijoDer, raiz.score);
            }
            else if (raiz.score < x)
            {
                EliminarElem(ref raiz.hijoDer, x);
            }
            else
            {
                EliminarElem(ref raiz.hijoIzq, x);
            }
        }
    }

    public int mayor(NodoABB a)
    {
        if (a.hijoDer == null)
        {
            return a.score;
        }
        else
        {
            return mayor(a.hijoDer);
        }
    }

    public int menor(NodoABB a)
    {
        if (a.hijoIzq == null)
        {
            return a.score;
        }
        else
        {
            return menor(a.hijoIzq);
        }
    }

}

