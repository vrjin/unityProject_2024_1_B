using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircleObject;                                     //���� ������ ������Ʈ
    public Transform GenTransform;                                      //������ ������ ��ġ ������Ʈ
    public float TiemCheck;                                             //�ð��� üũ�ϱ� ����(float) ��
    public bool isGen;                                                 //���� �Ϸ� üũ (bool) ��

    void Start()
    {
        GenObject();                                                  //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen)              //if(isGen == false)
        { 
            TiemCheck -= Time.deltaTime;                          //�� �����Ӹ��� ������ �ð��� ���ش�.
            if (TiemCheck <= 0)                                   //�ش� �� �ð��� ������ ���(1�� -> 0�ʰ� �Ǿ��� ���)
            {
                GameObject Temp = Instantiate(CircleObject);         //
                Temp.transform.position = GenTransform.position;
                isGen = true;
            }

        }
    }

    public void GenObject()
    {
        isGen = false;                                        //�ʱ�ȭ : isGen�� false (���� ���� �ʾҴ�)
        TiemCheck = 1.0f;                                     //1���� ���� ����é�� ���� ��Ű�� ���� �ʱ�ȭ
    }
}
