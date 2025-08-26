using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController rubyCon = other.GetComponent<RubyController>();

        if (rubyCon != null)
        {
            rubyCon.ChangeHealth(-1);
        }
    }
}
