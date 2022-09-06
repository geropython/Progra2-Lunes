using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{

    //Very primitive Script NEED CHANGES.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Item Collected!");
            Destroy(gameObject);
        }
    }
}
