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
        //마스터 스라이더의 값이 변결될떄 리스너를 통해서 함수에 값을 전달한다.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM 슬라이더의 값이 변경될떄 리스너를 통해서 함수에 값을 전달한다.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX 슬라이더의 값이 변결될떄 리스너를 통해서 함수에 값을 전달한다.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }


    public void SetMasterVolume(float voiume)                       //마스터 불륨 
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
