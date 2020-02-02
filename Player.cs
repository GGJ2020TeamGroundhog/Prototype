using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 5;
    private float jumpForce = 5;
    public bool isGrounded = true;
    public string tool;
    public Collider2D collider;
    public List<Collider2D> interactables;
    public ContactFilter2D contactFilter;
    public string equippedTool;
    public GameManager gameManager;
    private Animator anim;
    private bool flipped=false;
    public bool inDialogue;
    public bool waitingForNextBubble;
    public DialogueTrigger dt;


    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }
    public void SetDefault()
    {
        anim.SetTrigger("Respawn");
        this.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        flipped = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = this.transform.position + this.transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = this.transform.position - this.transform.right * speed * Time.deltaTime;
        }

        collider.OverlapCollider(contactFilter, interactables);

        if (interactables.Count >= 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactables[0].gameObject.GetComponent<Interactables>().Interact(tool);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (waitingForNextBubble)
            {
                dt.PlayNext();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (waitingForNextBubble) {
                dt.PlayNext();
            }
        }


        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.P)){
            Pause();
        }
        WalkingInput(Input.GetAxis("Horizontal"));
    }
    void Pause()
    {
        gameManager.isPaused = !gameManager.isPaused;
        Debug.Log("Game is paused: "+gameManager.isPaused);
    }
    void fixedUpdate()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void WalkingInput(float movement)
    {
        //For the purposes of this animator, left direction = -1.0 and right direction = 1.0
        //These bool and float values were defined within the animator as assets
        //If you need the animations, I'll just send the .unity file.
        if (movement!= 0)
        {
            anim.SetBool("walking", true);
            if (movement < 0 && !flipped)
            {
                flipped = true;
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (movement > 0 && flipped)
            {
                flipped = false;
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }


}
