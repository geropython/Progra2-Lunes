using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crystal : MonoBehaviour, ICollectable
{
    public static event HandleCristalCollected OnCristalCollected;
    public delegate void HandleCristalCollected(ItemData itemData);
    public ItemData cristalData;
    public void Collect()
    {
        Destroy(gameObject);
        OnCristalCollected?.Invoke(cristalData);
    }
}
