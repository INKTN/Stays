using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Audio;
/// <summary>
/// 音效控制20221217
/// </summary>

public class AudioManager : MonoBehaviour
{
    #region 欄位
    public AudioSource audioSource;
    //static AudioManager current;
    [Header("音樂")]
    public AudioClip ambientClip;
    [Header("音效")]
    public AudioClip[] soundEffect;
    #endregion
    private void Awake()
    {
        /*current = this;
        DontDestroyOnLoad(gameObject);*/
        audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }
    public void Walking()//主角行走
    {
        audioSource.PlayOneShot(soundEffect[0]);
        print("走路中");
    }
    public void stop()
    {
        audioSource.Stop();
    }
}
