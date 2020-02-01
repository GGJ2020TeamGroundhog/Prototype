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

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
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

        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
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
}
