using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;


    private void Awake()
    {
        //������ �����̴��� ���� ����ɋ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM �����̴��� ���� ����ɋ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX �����̴��� ���� ����ɋ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }


    public void SetMasterVolume(float voiume)                       //������ �ҷ� 
    {
        audioMixer.SetFloat("Master", Mathf.Log10(voiume) * 20);
    }

    public void SetBGMVolume(float voiume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(voiume) * 20);
    }
     public void SetSFXVolume(float voiume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(voiume) * 20);
    }
}
