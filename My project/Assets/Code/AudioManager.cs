using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사운드 출력 및 샘플출력

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    [SerializeField] Sound[] bgm = null;
    [SerializeField] Sound[] sfx = null;
    [SerializeField] AudioSource bgmP = null;
    [SerializeField] AudioSource sfxP = null;

    public void PlayBgm(string bgmName) // 브금재생
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName == bgm[i].name)
            {
                bgmP.clip = bgm[i].clip;
                bgmP.Play();
            }
            else
            {
                throw new System.Exception("--Noclip --BGM");
            }
        }
    }
    public void StopBgm(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgmP.Stop();
        }
    }
    public void PlaySFX(string sfxName) // SFX재생
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName == sfx[i].name)
            {
                sfxP.clip = sfx[i].clip;
                sfxP.PlayOneShot(sfxP.clip);
            }
            else
            {
                throw new System.Exception("--Noclip --SFX");
            }
        }
    }
    public void StopSFX(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgmP.Stop();
        }
    }
    public int getSamples()
    {
        return bgmP.timeSamples;
    }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
