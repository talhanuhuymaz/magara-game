using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    public Key[] allKeys;
    [HideInInspector] public List<Key> haveKeys = new List<Key>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
