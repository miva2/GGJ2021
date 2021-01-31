using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follows along x-axis
        transform.position = new Vector3(center.transform.position.x, transform.position.y, transform.position.z);
    }
}
