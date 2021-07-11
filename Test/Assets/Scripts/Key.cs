using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects",order = 0)]
public class Key : ScriptableObject
{
    public GameObject[] connectedDoors;
    public GameObject keyImage;
}
