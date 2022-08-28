using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    [CreateAssetMenu]
//    public class InventorySO : ScriptableObject
//    {
//        [SerializeField]
//        private List<InventoryItem> inventoryItems;

//        [field: SerializeField]
//        public int Size { get; private set; } = 10;

//        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

//        public void Initialize()
//        {
//            inventoryItems = new List<InventoryItem>();
//            for (int i = 0; i < Size; i++)
//            {
//                inventoryItems.Add(InventoryItem.GetEmptyItem());
//            }
//        }

//        public int AddItem(ItemSO item, int quantity, List<ItemParameter> itemState = null)
//        {
//            if (item.IsStackable == false)
//            {
//                for (int i = 0; i < inventoryItems.Count; i++)
//                {
//                    while (quantity > 0 && IsInventoryFull() == false)
//                    {
//                        quantity -= AddItemToFirstFreeSlot(item, 1, itemState);
//                    }
//                    InformAboutChange();
//                    return quantity;
//                }
//            }
//            quantity = AddStackableItem(item, quantity);
//            InformAboutChange();
//            return quantity;
//        }

//        private int AddItemToFirstFreeSlot(ItemSO item, int quantity
//            , List<ItemParameter> itemState = null)
//        {
//            InventoryItem newItem = new InventoryItem
//            {
//                item = item,
//                quantity = quantity,
//                itemState =
//                new List<ItemParameter>(itemState == null ? item.DefaultParametersList : itemState)
//            };

//            for (int i = 0; i < inventoryItems.Count; i++)
//            {
//                if (inventoryItems[i].IsEmpty)
//                {
//                    inventoryItems[i] = newItem;
//                    return quantity;
//                }
//            }
//            return 0;
//        }

//        private bool IsInventoryFull()
//            => inventoryItems.Where(item => item.IsEmpty).Any() == false;

//        private int AddStackableItem(ItemSO item, int quantity)
//        {
//            for (int i = 0; i < inventoryItems.Count; i++)
//            {
//                if (inventoryItems[i].IsEmpty)
//                    continue;
//                if (inventoryItems[i].item.ID == item.ID)
//                {
//                    int amountPossibleToTake =
//                        inventoryItems[i].item.MaxStackSize - inventoryItems[i].quantity;

//                    if (quantity > amountPossibleToTake)
//                    {
//                        inventoryItems[i] = inventoryItems[i]
//                            .ChangeQuantity(inventoryItems[i].item.MaxStackSize);
//                        quantity -= amountPossibleToTake;
//                    }
//                    else
//                    {
//                        inventoryItems[i] = inventoryItems[i]
//                            .ChangeQuantity(inventoryItems[i].quantity + quantity);
//                        InformAboutChange();
//                        return 0;
//                    }
//                }
//            }
//            while (quantity > 0 && IsInventoryFull() == false)
//            {
//                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
//                quantity -= newQuantity;
//                AddItemToFirstFreeSlot(item, newQuantity);
//            }
//            return quantity;
//        }
//    }
//}