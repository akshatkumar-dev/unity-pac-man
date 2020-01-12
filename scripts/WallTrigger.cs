using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (gameObject.name == "Left Wall")
        {
            collision.gameObject.transform.position = new Vector2(4.6f, -0.07f);
        }
        else if (gameObject.name == "Right Wall")
        {
            collision.gameObject.transform.position = new Vector2(-4.6f, -0.07f);

        }
    }
    
}
