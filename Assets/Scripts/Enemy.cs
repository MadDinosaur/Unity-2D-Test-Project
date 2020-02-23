using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyBody;
    public float speed;
    private int direction;
    
    

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        direction = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyBody.velocity = new Vector2(direction * speed, enemyBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "barrier")
        {
            Debug.Log("Hit");
            enemyBody.transform.Rotate(0f, 180f, 0f);
            direction *= -1;
            //movement = new Vector2(direction*speed, enemyBody.velocity.y);
           
        }
    }
}
