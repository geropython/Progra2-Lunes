using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SINGLETON TYPE
    // Enemies or other classes´s health should work apart from this script, this works exclusively for the Player

    public static GameManager gameManager { get; private set; }

    //Referencing the Player´s Health controller
    public HealthController _playerHealth = new HealthController(100, 200);

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

   
}
