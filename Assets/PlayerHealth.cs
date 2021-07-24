using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;

    [Header("Colliders")]
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public SpriteRenderer render;

    private Transform trans;
    private Vector3 initialPos;
    private int revivalCount = 1;

    public void Awake()
    {
        this.trans = GetComponent<Transform>();
        initialPos = this.trans.position;
    }

    private void OnDamage()
    {
        health--;
        if (health > 0)
        {
            return;
        }

        OnDead();
    }

    private void OnDead()
    {
        if (revivalCount > 0)
        {
            ShowRevival();
            revivalCount--;
            return;
        }

        //
        col1.enabled = false;
        col2.enabled = false;
        render.color = new Color(1, 1, 1, 0.5f);
    }

    private void ShowRevival()
    {
        // 광고 표기
        Debug.Log("광고1");
        UnityAdsManager.Instance.ShowAd();
        //Debug.Log("광고");
    }

    // 부활시 출력될 함수
    public void OnRevival()
    {
        col1.enabled = true;
        col2.enabled = true;
        render.color = new Color(1, 1, 1, 1f);

        health = 1;
        this.trans.position = initialPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            OnDamage();
        }
    }
}