using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public AudioClip collectedSound;
    public int score;

    [field: SerializeField]
    public GameObject Prefab { get; private set; }
}
