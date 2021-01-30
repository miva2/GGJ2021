
using System;
using UnityEngine;

public class KeyboardKeyItem : MonoBehaviour, Item
{
    public KeyboardKey keyboardKey = KeyboardKey.UNSET;

    public void OnPickUp(GameObject player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            //TODO: determine which item is picked up
            Debug.Log("Item picked up");
            Destroy(gameObject);
        }
    }
}
