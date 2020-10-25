using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
    SarahController controller = other.GetComponent<SarahController>();
    if (controller != null)
    {
         if(controller.health < controller.maxHealth)
          {
	       controller.ChangeHealth(1); // Add Health on eating berry
	       Destroy(gameObject);
          }
    }
    }

}
