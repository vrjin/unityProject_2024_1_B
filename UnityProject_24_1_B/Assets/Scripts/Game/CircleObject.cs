using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    public int index;

    public float EndTime = 0.0f;
    public SpriteRenderer spriteRenderer;

    public GameManager gameManager;

    private void Awake()
    { 
        isUsed = false;                //�����ϱ��� �ҽ� �ܰ迡������ ����
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed) return;                       //���Ϸ�� ��ü�� ���� ������Ʈ ���� �ʱ� ���ؼ� return �� ���� �ش�.

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
            
        if (Input.GetMouseButtonDown(0)) Drag();                                  //���콺 ��ư�� ������ �� Drag �Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();                                 //���콺 ��ư�� �ö� �� Drag �Լ� ȣ��
    }

    void Drag()
    {
        isDrag = true;                           //�巡�� ���� (true)
        rigidbody2D.simulated = false;           //�巡�� �߿��� ���� ������ �Ͼ�°��� ���� ���ؼ� (false)
    }
    void Drop()
    {
        isDrag = false;                   // �巡�װ� ����
        isUsed = true;                   //����� �Ϸ�
        rigidbody2D.simulated = true;   //�������� ����

        GameObject Temp = GameObject.FindWithTag("GameManager");

        if (Temp != null)
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }

    public void Used()
    {
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;
    }

    public void OnTriggerStay(Collider2D collision)
    {
        if (collision.tag == "EndLine")
        {
            EndTime += Time.deltaTime;

            if (EndTime > 1)
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);
            }
            if (EndTime > 3)
            {
                Debug.Log("��������");
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndLine")
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;

        }
    }
}