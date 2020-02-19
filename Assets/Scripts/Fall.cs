using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject player;
    private Vector2 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("He ded x_x");
        player.transform.position = respawnPoint;

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}