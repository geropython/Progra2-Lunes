using System.Collections;
using System.Collections.Generic;
using _Main._Resources.Scripts.Utilities;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource pickUpSound;
    
    public int crystals;

    private void Start()
    {
        crystals = 0;
    }

    private void Update()
    {
        scoreText.text = " : " + crystals;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
           pickUpSound.Play();
            crystals++; 
        }
    }
}
