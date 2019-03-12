using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Input;

public class PlayerControl : MonoBehaviour
{
    [Header("Control")]
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Attack = KeyCode.J;
    public KeyCode Jump = KeyCode.Space;
    
    [Header("Attribute")]
    public float MovingSpeed;
    public float JumpingSpeed;
    public int ComboFrameRange;

    private Vector2 SpeedH = new Vector2(0, 0);
    private Vector2 SpeedV = new Vector2(0, 0);
    private Rigidbody2D rb;
    private bool landed;

    [Header("Game Stat")]
    public Animator animator;
    public bool LookRight = true;
    public int AttackStage;
    public int ComboBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpeedH.Set(MovingSpeed, 0);
        SpeedV.Set(0, JumpingSpeed);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        print("Landed");
        landed = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        print("Flowing");
        landed = false;
    }
    
    // Update is called once per frame
    void Update()
    {   
        
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MovingSpeed, rb.velocity.y);     
        //MoveMent
        /*if (Input.GetKeyDown(Left))
        {
            
        }
        
        if (Input.GetKeyUp(Left))
        {    
            rb.velocity += SpeedH;
        }

        if (Input.GetKeyDown(Right))
        {
            rb.velocity += SpeedH;
        }

        if (Input.GetKeyUp(Right))
        {
            rb.velocity -= SpeedH;
        }*/
        
        if (landed && Input.GetKeyDown(Jump))
        {
            rb.velocity += SpeedV;
        }
        
        //Flip
        if ((rb.velocity.x > 0 && LookRight) || (rb.velocity.x < 0 && !LookRight))
        {
            LookRight = !LookRight;
            Vector3 CharScale = transform.localScale;
            CharScale.x *= -1;
            transform.localScale = CharScale;
        }
        
        //Attack        
        if (ComboBar > 0)
        {
            ComboBar--;
            if (ComboBar == 0)
            {
                AttackStage = 0;
                animator.SetInteger("AttackStage", AttackStage);
            }
        }
        
        if (Input.GetKeyDown(Attack) && AttackStage == 2 && ComboBar < 30)
        {
            AttackStage++;
            animator.SetInteger("AttackStage", AttackStage);
            ComboBar += ComboFrameRange;
        }
        
        if (Input.GetKeyDown(Attack) && AttackStage == 1)
        {
            AttackStage++;
            animator.SetInteger("AttackStage", AttackStage);
            ComboBar += ComboFrameRange;
        }        
        
        if (Input.GetKeyDown(Attack) && AttackStage == 0)
        {
            AttackStage++;
            animator.SetInteger("AttackStage", AttackStage);
            ComboBar += ComboFrameRange;
        }
    }


}
