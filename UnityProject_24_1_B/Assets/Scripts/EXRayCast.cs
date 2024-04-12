using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                   //
using UnityEngine.SceneManagement;

public class EXRayCast : MonoBehaviour
{
    public int Point = 0;                                               //포인트 계산 변수
    public GameObject TargetObject;                                     //타겟 프리팹
    public float CheckTime = 0;                                         //타겟 Gen 시간 변수
    public float GameTime = 30.0f;

    public Text pointUI;
    public Text timeUI;

    void Update()
    {
        CheckTime += Time.deltaTime;                                  //프레임이 누적되어시간을 계산하게 한다.
        GameTime -= Time.deltaTime;                                   //프레임 시간을 제거하여 30초 -> 0초로 가게 한다.

        if (GameTime <= 0)                                           // 0초가 되면
        { 
            PlayerPrefs.SetInt("Point", Point);                     //유니티에서 제공하는 저장 함수
            SceneManager.LoadScene("MainScene");                    //MainScene으로 이동한다
        }                     


        pointUI.text = "점수 : " + Point.ToString();                        //UI 점수 표시
        timeUI.text = "남은 시간 : " + GameTime.ToString() + "s";           //UI 남은 시간 표시

        if (CheckTime >= 0.5f)                                        //0.5초 마다 행동을 한다/
        {
            int RandomX = Random.Range(0, 12);                        //0~11사이의 랜덤값을 뽑아넨다.
            int RandomY = Random.Range(0, 12);                       //0~11사이의 랜덤값을 뽑아넨다.
            GameObject temp = Instantiate(TargetObject);
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);
            Destroy(temp, 1.0f);
            CheckTime = 0;
        }




        if (Input.GetMouseButtonDown(1))
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //카메라를 회면 시점에서 마우스 포지션에서 Ray를 쏜다

            RaycastHit hit;                 

            if (Physics.Raycast(cast, out hit))                          //쏜 Ray를 받아오는 변수
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);

                if (hit.collider.gameObject.tag == "Target")
                {
                    Point += 1;
                    Destroy(hit.collider.gameObject);
                }
            } 
        }
    }
}
