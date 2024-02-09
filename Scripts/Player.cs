using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    private float ver;
    private float hor;
    // Start is called before the first frame update

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //hor = Input.GetAxisRaw("Horizontal");
        //ver = Input.GetAxisRaw("Vertical");
        direction = new Vector3(hor, 0,ver);

        transform.Translate(direction * speed * Time.deltaTime);


        // Walking
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", 1f);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", -1f);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
            // Reset jump to false after a delay or when landing logic is detected
        }

        // Check if the jump animation is done
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetBool("isJump", false);
        }


    }
}
