using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("triggerと接触" + other);

        // ルビーを定義
        RubyController rubyCon = other.GetComponent<RubyController>();

        // ルビー以外は無視する
        if (rubyCon != null)
        {
            // HPがmaxなら何もしない
            if (rubyCon.health == rubyCon.maxHealth) { return; }

            rubyCon.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
