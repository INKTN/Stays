using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
/// <summary>
/// ���ı���20221217
/// </summary>

public class AudioManager : MonoBehaviour
{
    #region ���
    static AudioManager current;
    [Header("����")]
    public AudioClip ambientClip;
    [Header("����")]
    public AudioClip[] sundEffects;
    #endregion
    private void Awake()
    {
        current = this;
        DontDestroyOnLoad(gameObject);
    }
}
