using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public SpriteRenderer render;

    void OnDamage()
    {
        col1.enabled = false; // enabled: 기능 해제 
        col2.enabled = false;
        render.color = new Color(1, 1, 1, 0.5f); //투명도 변경
        GameManager.I.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            OnDamage();
        }
    }
}
