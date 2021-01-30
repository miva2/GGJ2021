using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour // TODO: rename to PlayerController instead of PlayerMovement
{
    public SceneManager sceneManager;
    
    public float playerMovementSpeed = 5f;
    public float jumpSpeed = 8f;

    void Update()
    {
        CheckMovement();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        CheckItemPickup(other);
    }

    private void CheckItemPickup(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            //pick up the item
            Debug.Log("Item detected");
            Item item = collider.gameObject.GetComponent<KeyboardKeyItem>(); //TODO: will only work for keyboard items, search for Item if more items implemented 
            item.OnPickUp(gameObject);
        }
    }

    private void CheckMovement()
    { // maybe move to different class, or leave it... doesn't matter
        if (sceneManager.KeyObtained(KeyboardKey.W))
        {
            if (Input.GetKey(KeyCode.W))
            {
                //jump, apply gravity
                transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);
            }
        }

        if (sceneManager.KeyObtained(KeyboardKey.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //move left
                transform.Translate(-playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }

        if (sceneManager.KeyObtained(KeyboardKey.S))
        {
            if (Input.GetKey(KeyCode.S))
            {
                // go down if necessary
            }
        }

        if (sceneManager.KeyObtained(KeyboardKey.D))
        {
            if (Input.GetKey(KeyCode.D))
            {
                //move right
                transform.Translate(playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
