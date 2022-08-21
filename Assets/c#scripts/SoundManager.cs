using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    public AudioSource bgSound;

    public AudioClip[] bglist;


    public AudioClip ButtonDown;
    public AudioClip Back;


    //public float BGM_Volume_Save;
    //public float SFX_Volume_Save;
    public float BGM_Volume_Save;


    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    void Start()
    {
        mixer.SetFloat("BGSound", Mathf.Log10(PlayerPrefs.GetFloat("FILE_BGM_Sound")) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("FILE_SFX_Sound")) * 20);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
            {
                BgSoundPlay(bglist[i]);
            }
        }
    }

    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGSound", Mathf.Log10(val) * 20);
    }
    public void SFXVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }
    public void SFXPlay(string sfxname, AudioClip clip)
    {
        GameObject go = new GameObject(sfxname + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length);
    }
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGSound")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 1f;
        bgSound.Play();
    }
    public void ButtonDownSound()
    {
        instance.SFXPlay("ButtonDown", ButtonDown);

    }
    public void BackSound()
    {
        instance.SFXPlay("Back", Back);
    }
    public static void AllSoundRePlay()
    {
        FindObjectOfType<SoundManager>().GetComponent<AudioSource>().Play();
    }
}