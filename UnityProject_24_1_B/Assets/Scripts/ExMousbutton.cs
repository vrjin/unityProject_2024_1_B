using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI;           //UI�� ����ϱ����ؼ� �߰�

public class ExMousbutton : MonoBehaviour
{
    public int Hp = 100;
    public Text textui;

    void Update()
    {
        //Debug.Log("ü�� : " + Hp);     //ü��Ȯ���� ���� Debug.Log �Լ�
        textui.text = "ü�� : " + Hp.ToString();  

        if (Input.GetMouseButtonDown(0))  //���콺 �Է��� ������ ��
        {
            Hp-= 10;
            Debug.Log("ü�� : " + Hp); //ü��Ȯ���� ���� Debug.Log �Լ�
            if (Hp < 10)         //HP�� 0���Ϸ� ��������
            {
                textui.text = "ü�� : " + Hp.ToString();
                Destroy(gameObject);     //�� ������Ʈ�� �ı��Ѵٴ� �Լ�
            }
        }
    }
}
