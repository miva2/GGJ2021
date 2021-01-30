using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovementSpeed = 5f;
    public float jumpSpeed = 8f;

    void Update()
    {
        if (KeyCollection.KeyW)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //jump, apply gravity
                Debug.Log("JUMP!");
                transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);
            }
        }
        if (KeyCollection.KeyA)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //move left
                Debug.Log("Moving left");
                transform.Translate(-playerMovementSpeed * Time.deltaTime, 0f, 0f);    
            }
        }
        if (KeyCollection.KeyS)
        {
            if (Input.GetKey(KeyCode.S))
            {
                // go down if necessary
            }
        }
        if (KeyCollection.KeyD)
        {
            if (Input.GetKey(KeyCode.D))
            {
                //move right
                Debug.Log("Moving right");
                transform.Translate(playerMovementSpeed * Time.deltaTime, 0f, 0f);    
            }
        }
    }
    
}
