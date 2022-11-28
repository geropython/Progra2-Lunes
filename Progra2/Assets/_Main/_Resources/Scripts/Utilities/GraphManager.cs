using System;
using System.Collections;
using System.Collections.Generic;
using _Main._Resources.Scripts.Utilities.TDA.Dijkstra;
using UnityEngine;
using _Main._Resources.Scripts.Utilities.TDA.Graphs;
using UnityEngine.UIElements;

public class GraphManager : MonoBehaviour
{
    private TDA_Grafos.GrafoMA grafoMa;
   [SerializeField] private Transform[] pathPoints;   //UBICAR EN OTRO LADO. deberia estar en un spawner de enemigos.
   public Transform spawn;
    private Queue<Transform> activePathing = new Queue<Transform>();
    public Transform pathCurrent;
    [SerializeField] private  int pathEnemyIndex;     //PUNTO FINAL DE LA RUTA  DEL ENEMY
    private Transform pathLast; // Quizas se usa para algo despues (si patrulla sobre una camino especifico)
    private bool isAtPoint; // Llegue al punto que me corresponde?
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento del objeto
    private Rigidbody2D rb;
   
    private float areaDistance = 0.5f; // Area alrededor del punto a donde tiene que llegar para que no tenga que ser tan preciso
    
    
    
    private void Awake()
    {
        // Guardo referencia al controlador del enemigo
        rb = GetComponent<Rigidbody2D>();
        SetSpawnPoint(spawn);
    }

    public void SetSpawnPoint(Transform transf)
    {
        // Guardo la posicion
        pathCurrent = transf;
        // Aplico la posicion
        transform.position = new Vector3(pathCurrent.position.x,pathCurrent.position.y,-10f);
        // Guarda la posicion anterior
        pathLast = pathCurrent;
        // Inicializa
        Startup();
    }

    private void Startup()
    {
        // Var aux para hacer el array en el que voy a copiar
        //var arrLength = SpawnController.Instance.dijkstraPathPoints.Length;
        // Genero el array con el tamaño 
      //  pathPoints = new Transform[arrLength];
        // Copio el array para poder realizar todas las funciones del script
        //Array.Copy(SpawnController.Instance.dijkstraPathPoints, pathPoints, arrLength);
        // Genera el grafo con sus aristas y pesos
        GraphCreation();
        // Usa el algoritmo de dijkstra sobre el grafo generado anteriormente
        RunDijkstra();
        // Actualiza la siguiente posicion a la que tiene que ir
        NodeUpdate();
    }

    private void LateUpdate()
    {
        // Comprueba si puede moverse por dijkstra
        // if (enemyController.DijkstraMove)
        // {
        //     // Movimiento utilizando el camino generado por dijkstra
        //     DijkstraMove();
        // }
        DijkstraMove();
    }

    
    private void GraphCreation()
    {
        // TamaÃ±o que va a tener la matriz de adyacencia
      TDA_Grafos.GrafoMA.n = pathPoints.Length;
        // Crea una nueva matriz
        grafoMa = new TDA_Grafos.GrafoMA();
        // Inicializa los valores iniciales de la matriz
        grafoMa.InicializarGrafo();
        // Agrega los vertices a la matriz
        for (int i = 0; i < pathPoints.Length; i++)
        {
            grafoMa.AgregarVertice(int.Parse(pathPoints[i].name));
        }

        // Declara el origen de las aristas
        int[] aristas_origen =
        {
           0, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 13, 14, 14, 15, 16, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 23, 24, 24, 25, 25, 25, 26, 27, 27, 28, 28, 29, 29, 30, 30, 31,
        };
        // Declara el destino de las aristas
        int[] aristas_destino =
        {
           1, 0, 2, 10, 1, 3, 2, 4, 11, 3, 5, 18, 4, 6, 5, 7, 6, 8, 17, 7, 9, 8, 10, 9, 1, 3, 12, 11, 13, 12, 14, 16, 13, 15, 14, 13, 7, 4, 19, 18, 20, 19, 21, 20, 22, 21, 23, 22, 24, 23, 25, 24, 26, 27, 25, 25, 28, 27, 29, 30, 28, 29, 31, 30,
        };
        // Declara el peso de las aristas
        int[] aristas_peso = new int[aristas_origen.Length];
        for (int i = 0; i < aristas_peso.Length; i++)
        {
            aristas_peso[i] = 1;
        }

        // Agrega las aristas a la matriz
        for (int i = 0; i < aristas_peso.Length; i++)
        {
            grafoMa.AgregarArista(aristas_origen[i], aristas_destino[i], aristas_peso[i]);
        }
    }
   
   
   private void UpdateCurrentRoute()
   {
       // Convierte el array de string que dice el camino a uno de int
     
       var path = Array.ConvertAll(AlgDijkstra.nodos[pathEnemyIndex].Split(','), Convert.ToInt32);
       // Limpia la ruta anterior 
       
       activePathing.Clear();
       // Agrega el array de int a la Queue de ruta despues de transformarlo a un Transform
       for (int i = 0; i < path.Length; i++)
       {
           activePathing.Enqueue(IndexToTransform(path[i]));
           print(path[i]);
       }
   }
   
   private Transform IndexToTransform(int index)
   {
       // Cambia el int sacado del Dijkstra a su Transform correspondiente
       return pathPoints[index];
   }

   private int TransformToIndex(Transform transf)
   {
       // Cambia el Transform a su int correspondiente usable por Dijkstra
       return Int32.Parse(transf.gameObject.name);
   }
   
   private void RunDijkstra()
   {
       // Corre el algoritmo de dijkstra sobre la matriz creada y tiene como inicio la posicion actual del objeto
       AlgDijkstra.Dijkstra(grafoMa, TransformToIndex(pathCurrent));
       // Guarda los datos del algoritmo como una lista de puntos a recorrer
       UpdateCurrentRoute();
   }

   private void DijkstraMove()
   {
       var dir = (pathCurrent.position - transform.position);
       // Se fija si no llego al punto actual de la ruta
       if (!isAtPoint)
       {
           // Cuando llega a la posicion cambia el bool
           if (dir.magnitude <= areaDistance)
           {
               // poner un offset para que no tenga que ser tan preciso
               isAtPoint = true;
           }
       }
       // Se fija si llego al punto de la ruta
       if (isAtPoint)
       {
           // Actualiza el siguiente punto de la ruta
           NodeUpdate();
       }
       // Como no llego, trata de ir hacia el punto
       rb.velocity = (dir.normalized * (moveSpeed * Time.deltaTime));
   }

   private void NodeUpdate()
   {
       // Si no queda mas ruta (llego al final)
       if (activePathing.Count <= 0)
       {
           // Guarda el ultimo como su posicion actual
           pathLast = transform;
           // Guarda el actual como su posicion actual
           pathCurrent = transform;
           return;
       }

       // Agarra el siguiente punto de la ruta
       pathCurrent = activePathing.Peek();
       // Saca el punto de la queue para no repetirlo
       activePathing.Dequeue();
       // Cambia el bool para que trate de llegar al punto devuelta
       isAtPoint = false;
   }
    
    
    
}
