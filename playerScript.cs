using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    float timer;
    GameObject bottomTrunk;
    SpriteRenderer sr;
    bool isOnTheLeft = true;
    int score;
    public Text text;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        text.text = "score: " + score.ToString();
        Timer();
        ChangeSide();
        Attack();
        Win();
    }
    
    void Win()
    {
        if(score == 50)
        {
            print("you win");
        }
    }

    void ChangeSide()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && isOnTheLeft)
        {
            transform.position = new Vector3(transform.position.x + 3.2f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            isOnTheLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isOnTheLeft)
        {
            transform.position = new Vector3(transform.position.x - 3.2f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            isOnTheLeft = true;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q) && timer >= 0.7f)
        {
            timer = 0;
            Destroy(bottomTrunk);
            score++;
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("trunk"))
        {
            bottomTrunk = col.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("galho"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }
    }
}
