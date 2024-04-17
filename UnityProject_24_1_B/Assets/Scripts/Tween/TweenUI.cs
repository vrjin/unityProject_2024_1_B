using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;
    public  Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        image.DOFade(0f, duration)
            .SetEase(Ease.InOutQuad)
            .SetAutoKill(false)
            .Pause()
            .OnComplete(() => Debug.Log("UI �Ϸ�"));

        image.DOPlay();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
