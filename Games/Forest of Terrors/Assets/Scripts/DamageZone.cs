using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        SarahController controller = other.GetComponent<SarahController >();
        if (controller != null)
        {
            controller.ChangeHealth(-1); // Damage on stepping on spikes
        }
    }
}
