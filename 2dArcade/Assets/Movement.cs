using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    // public GameObject TheBall;
    Rigidbody2D rb;
    void Update()
    {
       if (Input.GetKey(KeyCode.LeftArrow))
         transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        //transform.Rotate(-Vector3.up, turnSpeed * Time.deltaTime);
    }
}
