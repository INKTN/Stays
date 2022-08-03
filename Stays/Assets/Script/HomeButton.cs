using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ¥D­¶«ö¯Ã
/// </summary>

public class HomeButton : MonoBehaviour
{
    public string play;
    public void StartGame()
    {
        SceneManager.LoadScene(play);
    }
    public void Movie()
    {
        SceneManager.LoadScene("");
    }
    public void Setting()
    {
        SceneManager.LoadScene("");
    }
    public void Work()
    {
        SceneManager.LoadScene("");
    }
}
