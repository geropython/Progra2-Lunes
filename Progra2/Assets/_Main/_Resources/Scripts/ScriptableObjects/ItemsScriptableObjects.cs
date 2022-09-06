using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 0)]
public  class ItemsScriptableObjects : ScriptableObject
{
    //Scriptable Object Parameters ( general for ITEMS)
    public new string name;
    public int score;
    [TextArea]
    public string description;
    public Sprite image;



   
}
