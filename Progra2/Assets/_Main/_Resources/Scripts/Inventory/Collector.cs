using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

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
            crystals++; 
        }
    }
}
