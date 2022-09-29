using System;
using UnityEngine;

namespace _Main._Resources.Scripts.Inventory
{
    [Serializable]
    public class InventoryItem : MonoBehaviour
    {
        public ItemData itemData;
        public int stackSize;

        public InventoryItem(ItemData item)
        {
            itemData = item;
            AddToStack();
        }
        public void AddToStack()
        {
            stackSize++;
        }
        public void RemoveFromStack()
        {
            stackSize--;
        }
    }
}
