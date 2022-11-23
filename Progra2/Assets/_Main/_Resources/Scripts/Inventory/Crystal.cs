using System;
using _Main._Resources.Scripts.Utilities;
using UnityEngine;

namespace _Main._Resources.Scripts.Inventory
{
    public class Crystal : MonoBehaviour, ICollectable
    {
        public static event HandleCristalCollected OnCristalCollected;
        public delegate void HandleCristalCollected(ItemData itemData);
        public ItemData cristalData;

       

        public void Collect()
        {
            Destroy(gameObject);
            AudioClip.Instantiate(cristalData);
            OnCristalCollected?.Invoke(cristalData);
           
            
        }
    }
}
