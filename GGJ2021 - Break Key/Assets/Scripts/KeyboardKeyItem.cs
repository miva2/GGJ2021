
using UnityEngine;

public class KeyboardKeyItem : MonoBehaviour, Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
