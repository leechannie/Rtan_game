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
    void Start() // 시작할 때 한 번 호출 
    {
        int A = 0;
        A = Push(A);
        Debug.Log(A.ToString());
    }

    // Update is called once per frame
    void Update() // 매번 호출
    {
        
    }
}
