using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer render;
    public Transform trans;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(InputManager.Instance.Movement.x, 0).normalized; // �޿��� ��ǥ�� �������� 

        if (direction.x < 0f) //����: ����
        {
            // ���� Ű�� ���� ��쿣 ���� �� Vector2.left �� �̵��մϴ�
            // Vector2.left �� Vector2(-1f, 0f) �� �����ϴ�
            direction = Vector2.left * moveSpeed;
            render.flipX = true;
        }
        else if (direction.x > 0f)
        {
            direction = Vector2.right * moveSpeed;
            render.flipX = false;
        }
        direction.y = rigid.velocity.y;
        rigid.velocity = direction;
    }
}