using UnityEngine;
/// <summary>
/// 20220926 ���֤���
/// </summary>
public class ChangeMusic : MonoBehaviour
{
    #region ���
    public AudioSource cameraAudio;
    public AudioClip inStation;
    public bool chIn=false;
    public bool playBGM=false;
    #endregion
    private void Start()
    {
        cameraAudio= GameObject.Find("MainCamera").GetComponent<AudioSource>();
        
    }
    #region ��k
    private void FixedUpdate()
    {
        chIn = GetComponent<area>().chIn;
        Music();
    }
    private void Music()
    {
        if (chIn&&!playBGM)
        {
            playBGM = true;
            cameraAudio.clip = inStation;
            cameraAudio.Play();
        }
    }
    #endregion
}
