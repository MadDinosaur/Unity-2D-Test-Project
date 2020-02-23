using UnityEngine;
using System.Collections;
 
public class LaunchProjectile : MonoBehaviour {
    public Rigidbody2D projectile;
 
    public Transform Launcher;
 
    public float projectileSpeed = 5000f;
 
    // Use this for initialization
    void Start () {
     
    }
 
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown ("Fire1")) {  
            Rigidbody2D projectileInstance;  
            projectileInstance = Instantiate(projectile, Launcher.position, Launcher.rotation) as Rigidbody2D;
 
            projectileInstance.AddForce(Launcher.right * projectileSpeed);
        }      
    }      
}