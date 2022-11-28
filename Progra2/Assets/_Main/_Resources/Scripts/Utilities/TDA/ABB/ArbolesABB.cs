using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolesABB : MonoBehaviour
{
   // //REEMPLAZAR EL PUBLIC INT INFO POR ALGUN GAMEOBJECT DE COLLECTABLES.
   //  public interface ABBTDA
   //  {
   //      GameObject Raiz();
   //      ABBTDA HijoIzq();
   //      ABBTDA HijoDer();
   //      bool ArbolVacio();
   //      void InicializarArbol();
   //      void AgregarElem(GameObject x);
   //      void EliminarElem(GameObject x);                           
   //  }
   //
   //  public class NodoABB
   //  {
   //      // datos a almacenar, en este caso un entero
   //      
   //
   //      public ItemData data;
   //      // referencia los nodos izquiero y derecho
   //      public ABBTDA hijoIzq;
   //      public ABBTDA hijoDer;
   //  }
   //
   //  public class ABB : ABBTDA
   //  {
   //      NodoABB raiz;
   //
   //      public GameObject Raiz()
   //      {
   //          return raiz.crystal;
   //      }
   //
   //      public bool ArbolVacio()
   //      {
   //          return (raiz == null);
   //      }
   //
   //      public void InicializarArbol()
   //      {
   //          raiz = null;
   //      }
   //
   //      public ABBTDA HijoDer()
   //      {
   //          return raiz.hijoDer;
   //      }
   //
   //      public ABBTDA HijoIzq()
   //      {
   //          return raiz.hijoIzq;
   //      }
   //
   //      public void AgregarElem(GameObject x)
   //      {
   //          if(raiz == null)
   //          {
   //              raiz = new NodoABB();
   //              raiz.crystal = x;
   //              raiz.hijoIzq = new ABB();
   //              raiz.hijoIzq.InicializarArbol();
   //              raiz.hijoDer = new ABB();
   //              raiz.hijoDer.InicializarArbol();
   //          }
   //          else if (raiz.crystal > x)
   //          {
   //              raiz.hijoIzq.AgregarElem(x);
   //          }
   //          else if (raiz.crystal < x)
   //          {
   //              raiz.hijoDer.AgregarElem(x);
   //          }
   //      }
   //
   //      public void EliminarElem(GameObject x)
   //      {
   //          if (raiz != null)
   //          {
   //              if (raiz.crystal == x && raiz.hijoIzq.ArbolVacio() && raiz.hijoDer.ArbolVacio())
   //              {
   //                  raiz = null;
   //              }
   //              else if (raiz.crystal == x && !raiz.hijoIzq.ArbolVacio())
   //              {
   //                  raiz.crystal= this.mayor(raiz.hijoIzq);
   //                  raiz.hijoIzq.EliminarElem(raiz.crystal);
   //              }
   //              else if (raiz.crystal == x && raiz.hijoIzq.ArbolVacio())
   //              {
   //                  raiz.crystal = this.menor(raiz.hijoDer);
   //                  raiz.hijoDer.EliminarElem(raiz.crystal);
   //              }
   //              else if(raiz.crystal < x)
   //              {
   //                  raiz.hijoDer.EliminarElem(x);
   //              }
   //              else
   //              {
   //                  raiz.hijoIzq.EliminarElem(x);
   //              }
   //          }
   //      }
   //
   //      public GameObject mayor(ABBTDA a)
   //      {
   //          if (a.HijoDer().ArbolVacio())
   //          {
   //              return a.Raiz();
   //          }
   //          else
   //          {
   //              return mayor(a.HijoDer());
   //          }
   //      }
   //
   //      public GameObject menor(ABBTDA a)
   //      {
   //          if (a.HijoIzq(). ArbolVacio())
   //          {
   //              return a.Raiz();
   //          }
   //          else
   //          {
   //              return menor(a.HijoIzq());
   //          }
   //      }
   //  }
    
    
    
}
