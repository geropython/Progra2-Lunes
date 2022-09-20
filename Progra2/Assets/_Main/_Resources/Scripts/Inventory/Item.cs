using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject KeyIcon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KeyIcon.SetActive(true);
            Debug.Log("Collected");
            Destroy(this.gameObject);
        }
    }
}
