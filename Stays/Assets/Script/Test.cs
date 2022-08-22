using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ´ú¸Õ¥Î«ö¶s³]¸m20220817
/// </summary>

public class Test : MonoBehaviour
{
    public string s1;
    public string s2;
    public string s3;
    

    public void S1()
    {
        SceneManager.LoadScene(s1);
    }
    public void S2()
    {
        SceneManager.LoadScene(s2);
    }
    public void S3()
    {
        SceneManager.LoadScene(s3);
    }
}
