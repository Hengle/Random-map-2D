using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    SpriteRenderer spriteRenderer;
    public float speed;
    private Vector2 mousePos;
    public GameObject Map;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        movement.y = Input.GetAxis("Vertical");
        
        ChangePlayerRotation();
        ControllerMap();
        SwitchAnim();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed*Time.fixedDeltaTime);
    }
    private void ChangePlayerRotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        //if (movement.x > 0)
        //{
        //    spriteRenderer.flipX = false;
        //}
        //else if (movement.x < 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
    }
    private void SwitchAnim()
    {
        animator.SetFloat("speed", movement.magnitude);
    }
    private void ControllerMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Map.SetActive(!Map.activeSelf);
        }
    }
}
