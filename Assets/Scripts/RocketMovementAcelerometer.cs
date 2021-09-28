using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementAcelerometer : MonoBehaviour
{
    Rigidbody rb;
    float directionX;
    float directionY;
    public float moveSpeedX;
    public float moveSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        directionX = Input.acceleration.x * moveSpeedX;
        directionY = Input.acceleration.y * moveSpeedY;
        transform.position = new Vector2(transform.position.x,transform.position.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX, directionY);
    }
}
