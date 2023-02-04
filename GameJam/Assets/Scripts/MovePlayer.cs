using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            rb.velocity = new Vector2(0, Input.GetAxisRaw("Vertical")*speed);
        }

    }
}
