using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public bool lookingRight = true;
    public bool isJumping = false;
    // public GameObject TheBall;
    Rigidbody2D rb;
    Transform body;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rb.velocity = new Vector2(horizontalInput*moveSpeed, rb.velocity.y);

        if ((horizontalInput > 0 && !lookingRight) || (horizontalInput < 0 && lookingRight))
            Flip();

        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(Vector2.zero);
        }
        // else anim.enabled = false;

        if (Input.GetKey(KeyCode.Space))
        {
            //rb.velocity = new Vector2( rb.velocity.x, jumpSpeed);
            if (isJumping == false)
            {
                rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime);
                anim.SetBool("isJumping", true);
                isJumping = true;
            }
            else { anim.SetBool("isJumping", !isJumping); }
        }

    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "isGround")
        {
            isJumping = false;
            //anim.SetBool("isJumping", isJumping);
        }
    }

    public void Flip()
{
    lookingRight = !lookingRight;
    Vector3 myScale = transform.localScale;
    myScale.x *= -1;
    transform.localScale = myScale;
}
}
