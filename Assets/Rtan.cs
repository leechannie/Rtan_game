using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{

    int Push(int a)
    {
        return a + 1;
    }
   
    // Start is called before the first frame update
    void Start() // ������ �� �� �� ȣ�� 
    {
        int A = 0;
        A = Push(A);
        Debug.Log(A.ToString());
    }

    // Update is called once per frame
    void Update() // �Ź� ȣ��
    {
        
    }
}
