using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI;           //UI를 상용하기위해서 추가

public class ExMousbutton : MonoBehaviour
{
    public int Hp = 100;
    public Text textui;

    void Update()
    {
        //Debug.Log("체력 : " + Hp);     //체력확인을 위한 Debug.Log 함수
        textui.text = "체력 : " + Hp.ToString();  

        if (Input.GetMouseButtonDown(0))  //마우스 입력이 들어왔을 떄
        {
            Hp-= 10;
            Debug.Log("체력 : " + Hp); //체력확인을 위한 Debug.Log 함수
            if (Hp < 10)         //HP가 0이하로 내려가면
            {
                textui.text = "체력 : " + Hp.ToString();
                Destroy(gameObject);     //이 오브젝트를 파괴한다는 함수
            }
        }
    }
}
