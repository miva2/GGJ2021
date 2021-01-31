using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("sceneManager")] public AlleySceneManager alleySceneManager;
    
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

    private void CheckItemPickup(Collider2D itemCollider)
    {
        if (itemCollider.gameObject.CompareTag("Item"))
        {
            //pick up the item
            Debug.Log("Item detected");
            Item item = itemCollider.gameObject.GetComponent<KeyboardKeyItem>(); //TODO: will only work for keyboard items, search for Item if more items implemented 
            if (item is KeyboardKeyItem keyItem)
            {
                alleySceneManager.KeyboardKeyPickedUp(keyItem);
                //actually i could have put this in the item itself, whatever if it works
            }

            
            item.OnPickUp(gameObject);
        }
    }

    private void CheckMovement()
    { // maybe move to different class, or leave it... doesn't matter
        if (alleySceneManager.IsKeyObtained(KeyboardKey.W))
        {
            if (Input.GetKey(KeyCode.W))
            {
                //jump, apply gravity
                transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f); // really need a better jump
            }
        }

        if (alleySceneManager.IsKeyObtained(KeyboardKey.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //move left
                transform.Translate(-playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }

        if (alleySceneManager.IsKeyObtained(KeyboardKey.S))
        {
            if (Input.GetKey(KeyCode.S))
            {
                // go down if necessary
            }
        }

        if (alleySceneManager.IsKeyObtained(KeyboardKey.D))
        {
            if (Input.GetKey(KeyCode.D))
            {
                //move right
                transform.Translate(playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
