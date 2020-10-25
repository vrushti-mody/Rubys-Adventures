using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //Get projectile when c is pressed
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); //Shoot projectile
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject); // Destroy if shot missed
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DamageController e = other.collider.GetComponent<DamageController>();
        if (e != null)
        {
            e.Fix(); //Destroy bot if shot hit
        }
    
        Destroy(gameObject); //Destroy projectile
    }

}
