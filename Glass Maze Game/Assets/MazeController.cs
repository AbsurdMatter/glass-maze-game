using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeedModifier = 0.5f;
    float dirX, dirY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dirX = Input.acceleration.x * moveSpeedModifier;
        dirY = Input.acceleration.y * moveSpeedModifier;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y + dirY);
    }
}
