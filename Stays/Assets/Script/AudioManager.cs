using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Audio;
/// <summary>
/// ���ı���20221217
/// </summary>

public class AudioManager : MonoBehaviour
{
    #region ���
    public AudioSource audioSource;
    //static AudioManager current;
    [Header("����")]
    public AudioClip ambientClip;
    [Header("����")]
    public AudioClip[] soundEffect;
    #endregion
    private void Awake()
    {
        /*current = this;
        DontDestroyOnLoad(gameObject);*/
        audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }
    public void Walking()//�D���樫
    {
        audioSource.PlayOneShot(soundEffect[0]);
        print("������");
    }
    public void stop()
    {
        audioSource.Stop();
    }
}
