using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private Dictionary<KeyboardKey, KeyboardAction> collectedKeys = new Dictionary<KeyboardKey, KeyboardAction>();
    
    private void Start()
    {
        collectedKeys.Add(KeyboardKey.W, KeyboardAction.Jump);
        collectedKeys.Add(KeyboardKey.A, KeyboardAction.MoveLeft);
        collectedKeys.Add(KeyboardKey.S, KeyboardAction.MoveDown);
        collectedKeys.Add(KeyboardKey.D, KeyboardAction.MoveRight);

    }
    
    public void ItemPickedUp()
    {
        
    }
    
    public bool IsKeyObtained(KeyboardKey key)
    {
        return collectedKeys.ContainsKey(key);
    }
}

