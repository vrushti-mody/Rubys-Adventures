using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime; //Assign ChangeTiem
    }

    void Update()
    {
        //Check if bot is broken
        if(!broken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        if(!broken)
        {
            return;
        }
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; // Change the Y position     
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; // Change the X position
        }
        rigidbody2D.MovePosition(position);
    }
    
    void OnCollisionEnter2D(Collision2D other) // Check for collision
    {
        SarahController player = other.gameObject.GetComponent<SarahController >();
        if (player != null)
        {
            player.ChangeHealth(-1); //Change Player Health
        }
    }
    
    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        Destroy(gameObject); //Destroy object when shot
    
    }
}
