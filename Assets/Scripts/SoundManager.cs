using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager _Instance = null;
    GameObject sfxManager;
    GameObject bgmManager;
    public float sfxVolume = 1f;
    public float bgmVolume = 1f;
    public AudioSource SFX_Manager
    {
        get
        {
            if (sfxManager == null)
                return null;
            else
                return sfxManager.GetComponent<AudioSource>();
        }
    }
    public AudioSource BGM_Manager
    {
        get
        {
            if (bgmManager == null)
                return null;
            else
                return bgmManager.GetComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        _Instance = this;
        sfxManager = this.transform.Find("SFX").gameObject;
        bgmManager = this.transform.Find("BGM").gameObject;
    }

    // Use this for initialization
    void Start () {
        SFX_Manager.volume = sfxVolume;
        BGM_Manager.volume = bgmVolume;

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySFX()
    {

    }

    public void PlayBGM(int index)
    {
        BGM_Manager.clip = ResourceManager._Instance.BGMs[index];
        BGM_Manager.Play();
    }

    public void PlayBGM(AudioClip bgm)
    {
        BGM_Manager.clip = bgm;
        BGM_Manager.Play();
    }

    public void BGMpause()
    {
        BGM_Manager.Pause();
    }

    public void BGMcontinue()
    {
        BGM_Manager.UnPause();
    }
}
