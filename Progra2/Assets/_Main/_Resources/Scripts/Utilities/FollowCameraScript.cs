using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{

    [SerializeField] private Transform player;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        //Follow Player with a transform. position:
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
