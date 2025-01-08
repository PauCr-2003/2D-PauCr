using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables en inspector
    public float speed = 5f;
    public float jumpForce = 3f;
    public float gravity = -9.8f;

    public  Animator cAnimator;
    public  Rigidbody2D cRigidbody2D;
    public  SpriteRenderer cRender;

    // Variable no inspector
    private Vector2 move;
    private bool grounded;
    private float magY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        magY = grounded ? 1 : gravity; // if(grounded){ magY = -1} else { magY = grvity;}

        bool jump = Input.GetKeyDown(KeyCode.W);
        bool crouch = Input.GetKey(KeyCode.S);
    
        // I´m jumping
        if (jump && grounded)
        {
            cRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Vector2.up == new Vector2(0,1)

            cAnimator.SetBool("Jump", true);
            Debug.Log("Jump");
        }

        cAnimator.SetFloat("Speed", Mathf.Abs(cRigidbody2D.velocity.x));

        cAnimator.SetBool("Crouch", crouch);
        Debug.Log(KeyCode.S);

        PlayerOrientation();

        //Debug.Log(anim.GetBool("Jump") + " -- " + grounded);
    }

    void FixedUpdate()
    {
        PlayerGrounded();

        // Accedo al componente rigidbody 2d
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector2(move.x * speed, rBody.velocity.y);
        //Debug.Log(rBody.velocity.x + " // " + rBody.velocity.y);
    }

    void PlayerOrientation()
    {
        // Accedo al componente Sprite Renderer
        if (move.x < 0)
            cRender.flipX = true;
        else if (move.x > 0)
            cRender.flipX = false;
    }

    void PlayerGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, LayerMask.GetMask("Environment"));

        if (hit && !grounded) // Check if we have a hit, if not, hit is null and will not enter
        {
            grounded = true;
            cAnimator.SetBool("Jump", false);
            Debug.Log("Grounded " + hit.collider.name);
        }
        else if (!hit)
        {
            grounded = false;
            Debug.Log("Not Grounded ");
        }
    }
}