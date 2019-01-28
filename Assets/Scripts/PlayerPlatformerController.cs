using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public static PlayerPlatformerController Instance;

    public bool hasMoved = false;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void WakeIp()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        animator.SetTrigger("wakeUp");
        Destroy(GameObject.Find("Asleep"));
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        
        move.x = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            GumptionMeter.Instance.gumption -= 0.06f;
            GumptionMeter.Instance.transform.localScale = Vector2.one * 1.1f;

            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(Mathf.Abs(move.x) > 0.01f)
        {
            spriteRenderer.flipX = move.x > 0;
            if (!hasMoved)
            {
                hasMoved = true;
                WakeIp();
            }
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}