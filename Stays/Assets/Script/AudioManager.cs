using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
/// <summary>
/// 音效控制20221217
/// </summary>

public class AudioManager : MonoBehaviour
{
    #region 欄位
    static AudioManager current;
    [Header("音樂")]
    public AudioClip ambientClip;
    [Header("音效")]
    public AudioClip[] sundEffects;
    #endregion
    private void Awake()
    {
        current = this;
        DontDestroyOnLoad(gameObject);
    }
}
