using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;                                     //���� ������ ������Ʈ
    public Transform GenTransform;                                      //������ ������ ��ġ ������Ʈ
    public float TiemCheck;                                             //�ð��� üũ�ϱ� ����(float) ��
    public bool isGen;                                                 //���� �Ϸ� üũ (bool) ��

    public int point;
    public int BestScore;
    public static event Action<int> OnPointChanged;
    public static event Action<int> OnBestScoreChanged;

    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
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
                //GameObject Temp = Instantiate(CircleObject[RandomNumber]);        //
                //Temp.transform.position = GenTransform.position;
                isGen = true;
            }

        }
    }

    public void GenObject()
    {
        isGen = false;                                        //�ʱ�ȭ : isGen�� false (���� ���� �ʾҴ�)
        TiemCheck = 1.0f;                                     //1���� ���� ����é�� ���� ��Ű�� ���� �ʱ�ȭ
    }

    public void MergeObject(int index, Vector3 position)
    {
        GameObject Temp = Instantiate(CircleObject[index]);
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();

        point += (int)Mathf.Pow(index, 2) * 10;
        OnPointChanged?.Invoke(point);
    }

    public void EndGame()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");

        if (point > BestScore)
        {
            PlayerPrefs.SetInt("BestScore ", point);
        }
    }
}
