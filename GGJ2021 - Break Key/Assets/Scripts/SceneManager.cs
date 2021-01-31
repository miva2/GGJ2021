using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Toast toast;
    public KeyboardKeyUI[] keyCollection; 

    private Dictionary<KeyboardKey, KeyboardAction> collectedKeys = new Dictionary<KeyboardKey, KeyboardAction>();
    
    private void Start()
    {
        // collectedKeys.Add(KeyboardKey.W, KeyboardAction.UNDEFINED);
        // collectedKeys.Add(KeyboardKey.A, KeyboardAction.UNDEFINED);
        // collectedKeys.Add(KeyboardKey.S, KeyboardAction.UNDEFINED);
        collectedKeys.Add(KeyboardKey.D, KeyboardAction.UNDEFINED);

    }
    
    public void KeyboardKeyPickedUp(KeyboardKeyItem item)
    {
        Debug.Log($"item {item} added to collection!");
        collectedKeys.Add(item.keyboardKey, KeyboardAction.UNDEFINED); // KeyboardActions are not supported yet
        toast.ShowToast($"KEY {item.keyboardKey} picked up!");
        foreach (KeyboardKeyUI key in keyCollection)
        {
            if (key.key.Equals(item.keyboardKey))
            {
                Debug.Log($"enabling the UI for {item.keyboardKey}, UI element: {key}");
                key.gameObject.GetComponent<Image>().enabled = true;
            }
        } // This can probably shorter and cleaner but don't know it in C#. Check it later :D 
    }
    
    public bool IsKeyObtained(KeyboardKey key)
    {
        return collectedKeys.ContainsKey(key);
    }
}

