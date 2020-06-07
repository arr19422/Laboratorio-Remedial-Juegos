using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyController : MonoBehaviour
{
    private bool isDead = false;
    private Animator animator;
    private Rigidbody2D rbFlappy;
    public GameObject lose;
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;       
        animator = GetComponent<Animator>();
        rbFlappy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 2.0f;
            Invoke("StartGame", 0f);
        }
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

    void StartGame()
    {
        start.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameControl.instance.gameOver = true;
        rbFlappy.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Dead");
        GameControl.instance.BirdLose();
        lose.SetActive(true);
    }
}
