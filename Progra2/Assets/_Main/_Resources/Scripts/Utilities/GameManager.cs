using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   //Score Variables
   
   //Reference to Dark Crystal Prefab?¿
    
    // Enemies or other classes´s health should work apart from this script, this works exclusively for the Player
  
    public static GameManager gameManager { get; private set; }
  
    //Referencing the Player´s Health controller
    public HealthController _playerHealth = new HealthController(100, 200);


    //SINGLETON TYPE
    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            
            DontDestroyOnLoad(this);
        }
        else
        {
            gameManager = this;
        }
    }

    public void WinGame()
    {
        //Winning Conditions
    }

    public void GameOver()
    {
        //Game over Conditions  
    }
   

}
