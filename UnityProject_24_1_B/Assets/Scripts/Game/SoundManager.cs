using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;                //Audio 관련 기능을 사용하기 위해 추가

[System.Serializable]               //Serializable 직렬화 (클래스 데이터를 형식을 보여주게 함)
public class Sound
{
    public string name;                     //사운드의 이름
    public AudioClip clip;                  //사운드 클립

    [Range(0f, 1f)]                         //인스펙터에서 범위 설정
    public float volum = 1.0f;              //사운드 볼륨

    [Range(0.1f, 3f)]
    public float pitch = 1.0f;             //사운드 피치
    public bool loop;                      //반복 재생 여부
    public AudioMixerGroup mixerGroup;       //오디어 믹서 그룹

    [HideInInspector]
    public AudioSource source;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;                   //싱클톤 인스턴스 화 시킨다

    public List<Sound> sounds = new List<Sound>();
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;                                  //싱글톤 패턴 적용
            DontDestroyOnLoad(gameObject);                    //Scene이 변경되어도 이 오브젝트는 파괴 X
        }
        else
        {
            Destroy(gameObject);                           //이미 싱글톤 오브젝트가 있을경우 파괴한다

        }

        foreach (Sound sound in sounds)               //리스트 안에 있는 사운드들을 초기화한다.
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volum;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = sound.mixerGroup;
        }

    }

    public void PlaySound(string name)
    {
        Sound soundToPlay = sounds.Find(sound => sound.name == name);

        if (soundToPlay != null)
        {
            soundToPlay.source.Play();
        }

        else
        {
            Debug.LogWarning("사운드 :" + name + "없습니다.");
        }
    }




}
