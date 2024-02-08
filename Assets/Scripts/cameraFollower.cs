using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour {

    public GameObject target;
    public float z;

    void Start()
    {

    }
    
    void Update()
    {
        float x = target.transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector3(x, y, z);
    }
}
