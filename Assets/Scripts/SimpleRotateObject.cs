using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotateObject : MonoBehaviour
{
    public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
