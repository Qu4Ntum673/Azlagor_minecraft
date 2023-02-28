using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float spd;
    bool canJump = true;
    public Animator anim;
    public SpriteRenderer sprite;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * spd, rb2d.velocity.y);
        if (Input.GetButtonUp("Jump") & canJump)
        {
            rb2d.AddRelativeForce(Vector2.up * 50, ForceMode2D.Impulse);
            canJump = false;
        }
        anim.SetFloat("mov", rb2d.velocity.sqrMagnitude);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ой!");
        canJump = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Не ой!!");
        canJump = false;
    }
}