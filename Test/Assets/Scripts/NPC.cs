using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public UnityEvent ThingsToDo;
    public Key thisKeyWillBeGiven;

    private void OnTriggerEnter(Collider other)
    {
        //Play Talking Sound
        //giving the key
        KeyManager.instance.haveKeys.Add(thisKeyWillBeGiven);
        ThingsToDo.Invoke();
    }
}
