using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                //UI를 사용하기 위해서

public class ExPlayer : MonoBehaviour
{
    public Rigidbody m_rigidbody;                      //리지드 바디를 소스로 사용해 받아온다.
    public int Force = 100;                          //int 정수로 힘들 100을 설정한다.
    public int point = 0;                             //점수 사용할 변수 추가
    public Text m_Text;                              //UI 텍스트 접근
    public float checkTime = 0;                       //시간 측정을 위한 변수 (소수점)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))  //마우스 입력이 들어왔을 떄
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(transform.up * Force);                       //transform.up(위쪽 방향)으로 리지드 바디에 Force 힘만큼 물리의 힘을 준다
        }

        checkTime += Time.deltaTime;            //프레임 시작을 더해서 시간을 측정
        if (checkTime >= 1.0f)                   //만약 1초가 지났을 경우
        {
            point += 1;                         //point = point + 1 축약 (1점씩 더해준다.)
            checkTime = 0.0f;                   //1초가 지날경우 초기화 (0초 -> 1초 -> 0초 -> 1초)

        }

        m_Text.text = point.ToString();       //UI 텍스트 접근
    }

    private void OnCollisionEnter(Collision collision)     //충돌이 시작되었을 때 
    {
        if (collision != null)                //충돌 물체가 존재할 경우
        {
            point = 0;                             //충돌이 일어났을떄 포인트를 0으로 해준다.
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);             //충돌했을떄 위치를 초기화 한다.
            Debug.Log(collision.gameObject.name);   //해당 오브젝트의 이름을 출력한다. 
        }

    }
}
