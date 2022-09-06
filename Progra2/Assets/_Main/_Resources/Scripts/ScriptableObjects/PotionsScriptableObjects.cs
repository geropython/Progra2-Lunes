using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Potions", order = 1)]
public class PotionsScriptableObjects : ScriptableObject
{
    public new string name;
    [SerializeField] private float healAmount;
    public string description;
    public Sprite image;

    public string type;


    //Methods
    private void HealPotion()
    {
        //
    }
}
