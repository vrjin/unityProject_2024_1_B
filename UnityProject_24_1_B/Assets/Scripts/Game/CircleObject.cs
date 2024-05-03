using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;      
    
    void Start()
    {
        isUsed = false;                                         // 사용 완료가 되지 않음 (처음 사용)
        rigidbody2D = GetComponent<Rigidbody2D>();              //강체를 불러온다
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed) return;                       //사용완료된 물체를 어디상 업데이트 하지 않기 위해서 return 로 돌려 준다.

        if (isDrag)
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4.5f + transform.localScale.x / 2f;
            float rightBorder = 4.5f - transform.localScale.x / 2f;

            if (mousPos.x < leftBorder) mousPos.x = leftBorder;
            if (mousPos.x > rightBorder) mousPos.x = rightBorder;

            mousPos.y = 8;
            mousPos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousPos, 0.2f);
        }
            
        if (Input.GetMouseButtonDown(0)) Drag();                                  //마우스 버튼이 눌렸을 떄 Drag 함수 호출
        if (Input.GetMouseButtonUp(0)) Drop();                                 //마우스 버튼이 올라갈 떄 Drag 함수 호출
    }

    void Drag()
    {
        isDrag = true;                           //드래그 시작 (true)
        rigidbody2D.simulated = false;           //드래그 중에는 물리 현상이 일어나는것을 막기 위해서 (false)
    }
    void Drop()
    {
        isDrag = false;                   // 드래그가 종료
        isUsed = true;                   //사용이 완료
        rigidbody2D.simulated = true;   //물리현상 시작

        GameObject Temp = GameObject.FindWithTag("GameManager");

        if (Temp != null)
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }
}