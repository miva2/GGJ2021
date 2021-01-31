using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SceneManager sceneManager;
    
    public float playerMovementSpeed = 5f;
    public float jumpSpeed = 8f;

    private bool grounded;
    void Update()
    {
        CheckMovement();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"collision detected with tag:{other.gameObject.tag}");
        CheckGrounded(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("exiting collision");
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Collision detected!");
        CheckItemPickup(other);
    }

    private void CheckGrounded(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void CheckItemPickup(Collider2D itemCollider)
    {
        if (itemCollider.gameObject.CompareTag("Item"))
        {
            //pick up the item
            Debug.Log("Item detected");
            Item item = itemCollider.gameObject.GetComponent<KeyboardKeyItem>(); //TODO: will only work for keyboard items, search for Item if more items implemented 
            if (item is KeyboardKeyItem keyItem)
            {
                sceneManager.KeyboardKeyPickedUp(keyItem);
                //actually i could have put this in the item itself, whatever if it works
            }

            
            item.OnPickUp(gameObject);
        }
    }

    private void CheckMovement()
    { // maybe move to different class, or leave it... doesn't matter
        if (sceneManager.IsKeyObtained(KeyboardKey.W))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log($"Grounded value: {grounded}");
                if (grounded)
                {
                    //jump, apply gravity
                    transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);    
                }
                
            }
        }

        if (sceneManager.IsKeyObtained(KeyboardKey.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //move left
                transform.Translate(-playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }

        if (sceneManager.IsKeyObtained(KeyboardKey.S))
        {
            if (Input.GetKey(KeyCode.S))
            {
                // go down if necessary
            }
        }

        if (sceneManager.IsKeyObtained(KeyboardKey.D))
        {
            if (Input.GetKey(KeyCode.D))
            {
                //move right
                transform.Translate(playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
