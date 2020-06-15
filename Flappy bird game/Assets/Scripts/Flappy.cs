using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Flappy : MonoBehaviour
{
    public GameObject ReplayButton,unfreeze;
    public bool isDead;
    Rigidbody2D rb2d;
    int score = 0;
    //public variables are editable from the Inspector
    public float speed = 5f;
    [SerializeField]
    private float flapForce = 20f;
    public Text ScoreScreen;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        ReplayButton.SetActive(false);
        GetComponent<Animator>().SetBool("isDead", true);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2d.velocity = Vector2.right * speed;
            rb2d.AddForce(Vector2.up * flapForce);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        ReplayButton.SetActive(true);
        GetComponent<Animator>().SetBool("dead", true);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            score++;
            Debug.Log(score);
            //update text
            ScoreScreen.text = score.ToString();
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void UnFreeze()
    {
        Time.timeScale = 1;
        unfreeze.SetActive(false);
    }
        
}

