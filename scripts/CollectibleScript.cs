using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] public static int numOfCollectibles = 172;
    //[SerializeField] Text displayScore;
    public static int score;
    private void Start()
    {
        score = 0;
        //displayScore.text = ("Score: " + score);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            numOfCollectibles--;
            score += 100;
            //displayScore.text = ("Score: " + score);
            Destroy(gameObject);
        }
    }
}
