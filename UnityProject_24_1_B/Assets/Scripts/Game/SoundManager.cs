using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;                //Audio ���� ����� ����ϱ� ���� �߰�

[System.Serializable]               //Serializable ����ȭ (Ŭ���� �����͸� ������ �����ְ� ��)
public class Sound
{
    public string name;                     //������ �̸�
    public AudioClip clip;                  //���� Ŭ��

    [Range(0f, 1f)]                         //�ν����Ϳ��� ���� ����
    public float volum = 1.0f;              //���� ����

    [Range(0.1f, 3f)]
    public float pitch = 1.0f;             //���� ��ġ
    public bool loop;                      //�ݺ� ��� ����
    public AudioMixerGroup mixerGroup;       //����� �ͼ� �׷�

    [HideInInspector]
    public AudioSource source;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;                   //��Ŭ�� �ν��Ͻ� ȭ ��Ų��

    public List<Sound> sounds = new List<Sound>();
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;                                  //�̱��� ���� ����
            DontDestroyOnLoad(gameObject);                    //Scene�� ����Ǿ �� ������Ʈ�� �ı� X
        }
        else
        {
            Destroy(gameObject);                           //�̹� �̱��� ������Ʈ�� ������� �ı��Ѵ�

        }

        foreach (Sound sound in sounds)               //����Ʈ �ȿ� �ִ� ������� �ʱ�ȭ�Ѵ�.
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
            Debug.LogWarning("���� :" + name + "�����ϴ�.");
        }
    }




}
