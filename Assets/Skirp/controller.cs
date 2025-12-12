using UnityEngine;
using UnityEngine.InputSystem;

public enum facedir
{
    down,
    left,
    right,
    up
}
public class controller : MonoBehaviour
{
    public InputActionReference input;
    public Vector2 move;
    public float spd;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isforce;
    private facedir dir = facedir.down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(move);
        if (!isforce)
        {    
        move = input.action.ReadValue<Vector2>();
        }
        faceorient1();
        rb.linearVelocity = move * spd;
        if (move != Vector2.zero)
        {
            anim.SetTrigger("walk");
        }
        else
        {
            anim.SetTrigger("idle");
        }

        if (dir == facedir.down)
        {
            anim.SetTrigger("facedown");
            anim.ResetTrigger("faceup");
            anim.ResetTrigger("faceright");
        }
        else if (dir == facedir.up)
        {
            anim.SetTrigger("faceup");
            anim.ResetTrigger("facedown");
            anim.ResetTrigger("faceright");
        }
        else if (dir == facedir.right)
        {
            anim.SetTrigger("faceright");
            anim.ResetTrigger("faceup");
            anim.ResetTrigger("facedown");
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir == facedir.left)
        {
            anim.SetTrigger("faceright");
            anim.ResetTrigger("faceup");
            anim.ResetTrigger("facedown");
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void faceorient()
    {
        if (move.x < 0 && move.y == 0)
        {
            dir = facedir.left;
        }
        else if (move.x > 0 && move.y == 0)
        {
            dir = facedir.right;
        }
        else if (move.x == 0 && move.y < 0)
        {
            dir = facedir.down;
        }
        else if (move.x == 0 && move.y > 0)
        {
            dir = facedir.up;
        }
        else if (move.x != 0 && move.y > 0)
        {
            dir = facedir.up;
        }
        else if (move.x != 0 && move.y < 0)
        {
            dir = facedir.down;
        }
    }
    void faceorient1()
    {
        if (move.x < 0) dir = facedir.left;
        else if (move.x > 0) dir = facedir.right;
        else if (move.y < 0) dir = facedir.down;
        else if (move.y > 0) dir = facedir.up;
    }
}
