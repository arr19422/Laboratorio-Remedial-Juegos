using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyController : MonoBehaviour
{
    private bool isDead = false;
    private Animator animator;
    private Rigidbody2D rbFlappy;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2f;       
        animator = GetComponent<Animator>();
        rbFlappy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Up");
                rbFlappy.velocity = Vector2.zero;
                rbFlappy.AddForce(new Vector2(0, 200f));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rbFlappy.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Dead");
    }
}
