using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
   [SerializeField] float xSpeed = 0f;
   [SerializeField] float ySpeed = 0f;
    [SerializeField] Text displayScore;
   public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StopCoroutine("startDeath");
        displayScore.text = ("Score: 0");
        animator = GetComponent<Animator>();
        resetAndSet(5);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        checkWin();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            resetAndSet(0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            resetAndSet(3);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            resetAndSet(1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            resetAndSet(2);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            resetAndSet(4);
        }
    }

    private void resetAndSet(int value)
    {
        animator.SetBool("isLeft", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isRight", false);
        animator.SetBool("isDown", false);

        switch (value)
        {
            case 0:
                animator.SetBool("isLeft", true);
                break;
            case 1:
                animator.SetBool("isUp", true);
                break;
            case 2:
                animator.SetBool("isRight", true);
                break;
            case 3:
                animator.SetBool("isDown", true);
                break;
            case 4:
                animator.SetBool("isDead", true);
                break;
            default:
                break;
        }
    }
    private void movePlayer()
    {
        if (!isDead)
        {
            if (animator.GetBool("isLeft"))
            {
                xSpeed = -3f;
                ySpeed = 0f;
            }
            else if (animator.GetBool("isRight"))
            {
                xSpeed = 3f;
                ySpeed = 0f;
            }
            else if (animator.GetBool("isUp"))
            {
                xSpeed = 0f;
                ySpeed = 3f;
            }
            else if (animator.GetBool("isDown"))
            {
                xSpeed = 0f;
                ySpeed = -3f;
            }
            xSpeed *= Time.deltaTime;
            ySpeed *= Time.deltaTime;
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y + ySpeed);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isDead = true;
    //}
    private void checkWin()
    {
        if(isDead == true)
        {
            //animator.SetBool("isDead", true);
            //new WaitForSeconds(3);
            StartCoroutine(startDeath());
        }
        if(CollectibleScript.numOfCollectibles == 0)
        {
            animator.SetBool("isDead", true);
            isDead = true;

            new WaitForSeconds(3);
            SceneManager.LoadScene("SampleScene");

        }
        else
        {
            displayScore.text = ("Score: " + CollectibleScript.score);
        }
    }
    IEnumerator startDeath()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");

    }

    
}
