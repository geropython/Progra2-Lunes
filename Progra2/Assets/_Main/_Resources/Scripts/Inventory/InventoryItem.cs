using System;
using UnityEngine;

namespace _Main._Resources.Scripts.Inventory
{
    [Serializable]
    public class InventoryItem : MonoBehaviour
    {
        //utilizar Stack Custom para que el ultimo que entra sea el primero en salir
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
