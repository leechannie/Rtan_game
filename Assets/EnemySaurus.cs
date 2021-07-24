using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaurus : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer reneder;
    public float moveSpeed;
    bool isLeft = true;
    bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        { // 죽었으면 함수 실행 다 끄기 
            return;
        }
        if (isLeft)
        {
            rigid.velocity = Vector2.left * moveSpeed;
            reneder.flipX = false;

        }
        else
        {
            rigid.velocity = Vector2.right * moveSpeed;
            reneder.flipX = true;
        }
    }

    public void OnDamage()
    {
        BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;
        reneder.color = new Color(1, 1, 1, 0.5f);
        rigid.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            isLeft = !isLeft;
        }
    }
}
