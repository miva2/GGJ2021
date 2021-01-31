using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlleySceneManager : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public Toast toast;
    public KeyboardKeyUI[] keyCollection;

    private bool startAnimationPerformed = false;
    private Dictionary<KeyboardKey, KeyboardAction> collectedKeys = new Dictionary<KeyboardKey, KeyboardAction>();
    
    private void Start()
    {
        // collectedKeys.Add(KeyboardKey.W, KeyboardAction.UNDEFINED);
        // collectedKeys.Add(KeyboardKey.A, KeyboardAction.UNDEFINED);
        // collectedKeys.Add(KeyboardKey.S, KeyboardAction.UNDEFINED);
        collectedKeys.Add(KeyboardKey.D, KeyboardAction.UNDEFINED);

        // StartCoroutine(LaunchKeyboard()); // looks stupid

    }

    private void Update()
    {
        if (!startAnimationPerformed)
        {
            player.transform.Translate(-4.2f, 0.5f, 0f);
            startAnimationPerformed = true;
        }
    }

    // looks stupid using the coroutine, just using earlier method for now
    // private IEnumerator LaunchKeyboard()
    // {
    //     yield return new WaitForSeconds(1f); //hardcoded wait, should wait until scene is loaded instead
    //     player.transform.Translate(-4.8f, 0.5f, 0f);
    //     //hardcoded camera but whatever
    //     // camera should start a bit higher and follow keyboard until on the floor and then follow normal code. no more time.
    // }

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

