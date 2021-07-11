using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Key key;

    private void OnTriggerEnter(Collider other)
    {
        KeyManager.instance.AddKey(key);
        Destroy(gameObject);
    }
}
