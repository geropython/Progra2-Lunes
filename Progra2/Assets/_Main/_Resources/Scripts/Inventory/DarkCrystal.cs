using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main._Resources.Scripts.Inventory
{
    public class DarkCrystal : MonoBehaviour, ICollectable
    {
        public static event HandleCristalCollected OnCristalCollected;
        public delegate void HandleCristalCollected(ItemData itemData);
        public ItemData darkCrystalData;

        [HideInInspector]
        public bool isCollected = false;
        

        public void Collect()
        {
            isCollected = true;
            Destroy(gameObject);
            OnCristalCollected?.Invoke(darkCrystalData);
        }
    }
}
