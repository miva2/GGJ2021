using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Toast toast;
    
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
    }
    
    public bool IsKeyObtained(KeyboardKey key)
    {
        return collectedKeys.ContainsKey(key);
    }
}

