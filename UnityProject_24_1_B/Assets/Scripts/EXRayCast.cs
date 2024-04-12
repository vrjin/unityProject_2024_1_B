using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                   //
using UnityEngine.SceneManagement;

public class EXRayCast : MonoBehaviour
{
    public int Point = 0;                                               //����Ʈ ��� ����
    public GameObject TargetObject;                                     //Ÿ�� ������
    public float CheckTime = 0;                                         //Ÿ�� Gen �ð� ����
    public float GameTime = 30.0f;

    public Text pointUI;
    public Text timeUI;

    void Update()
    {
        CheckTime += Time.deltaTime;                                  //�������� �����Ǿ�ð��� ����ϰ� �Ѵ�.
        GameTime -= Time.deltaTime;                                   //������ �ð��� �����Ͽ� 30�� -> 0�ʷ� ���� �Ѵ�.

        if (GameTime <= 0)                                           // 0�ʰ� �Ǹ�
        { 
            PlayerPrefs.SetInt("Point", Point);                     //����Ƽ���� �����ϴ� ���� �Լ�
            SceneManager.LoadScene("MainScene");                    //MainScene���� �̵��Ѵ�
        }                     


        pointUI.text = "���� : " + Point.ToString();                        //UI ���� ǥ��
        timeUI.text = "���� �ð� : " + GameTime.ToString() + "s";           //UI ���� �ð� ǥ��

        if (CheckTime >= 0.5f)                                        //0.5�� ���� �ൿ�� �Ѵ�/
        {
            int RandomX = Random.Range(0, 12);                        //0~11������ �������� �̾Ƴٴ�.
            int RandomY = Random.Range(0, 12);                       //0~11������ �������� �̾Ƴٴ�.
            GameObject temp = Instantiate(TargetObject);
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);
            Destroy(temp, 1.0f);
            CheckTime = 0;
        }




        if (Input.GetMouseButtonDown(1))
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //ī�޶� ȸ�� �������� ���콺 �����ǿ��� Ray�� ���

            RaycastHit hit;                 

            if (Physics.Raycast(cast, out hit))                          //�� Ray�� �޾ƿ��� ����
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
