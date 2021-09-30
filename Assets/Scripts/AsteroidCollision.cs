using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger(Collider other)
    {
        if (other.tag.Equals("Asteroid"))
        {
            Debug.Log("Colidi com um asteroid");
        }
    }
}
