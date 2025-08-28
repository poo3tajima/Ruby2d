using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public bool isVertical;
    public float changeTime = 2.0f;

    Rigidbody2D rb;
    float timer;
    int direction = 1;

    Animator anim;
    bool broken = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (!broken) { return; }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 pos = rb.position;

        if (isVertical)
        {
            pos.y = pos.y + Time.deltaTime * speed * direction;
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", direction);
        }
        else
        {
            pos.x = pos.x + Time.deltaTime * speed * direction;
            anim.SetFloat("MoveX", direction);
            anim.SetFloat("MoveY", 0);
        }

        rb.MovePosition(pos);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController rubyCon = other.gameObject.GetComponent<RubyController>();

        if (rubyCon != null)
        {
            rubyCon.ChangeHealth(-1);
        }
    }


    public void Fix()
    {
        broken = false;
        // リジッドボディ2Dから物理シュミレーションを外すと動けなくなる
        rb.simulated = false;
        anim.SetTrigger("Fixed");
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
    }
}
