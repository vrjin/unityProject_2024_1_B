using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Color color = new Color(Random.value, Random.value, Random.value);      //랜덤 컬러 설정

            renderer.material.DOColor(color, 1f)                                    //랜덤 설정된 컬러로 트위닝
                .SetEase(Ease.InOutQuad)                                            //옵션 값 설정
                .SetAutoKill(false)
                .Pause() 
                .OnComplete(() => Debug.Log("Color 변환 완료"));                   //익명함수에서 로그 활성화 [() =>]

            renderer.material.DOPlay();                                           //설정된 트윈을 실행

        }
    }
}
