using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageSwitcher : MonoBehaviour
{
    public Image[] images;  // 存儲所有要顯示的圖片
    public float fadeTime = 0.5f;  // 淡入淡出的時間

    public int currentIndex = 0;  // 當前顯示的圖片的索引
    private bool fading = false;  // 是否正在淡入淡出

    private void Start()
    {
        // 隱藏所有圖片，除了第一張
        for (int i = 1; i < images.Length; i++)
        {
            images[i].color = Color.clear;
        }
    }

    private void Update()
    {
        // 當按下滑鼠左鍵時，切換到下一張圖片
        if (Input.GetMouseButtonDown(0) && !fading)
        {
            StartCoroutine(FadeOut());
           
        }
    }

    // 淡出當前圖片，然後淡入下一張圖片
    private IEnumerator FadeOut()
    {
        fading = true;
        Image currentImage = images[currentIndex];
        print(currentImage);
        Color currentColor = currentImage.color;

        // 淡出當前圖片
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            currentImage.color = Color.Lerp(currentColor, Color.clear, timer / fadeTime);
            yield return null;
        }
        currentImage.color = Color.clear;

        currentIndex = (currentIndex + 1) % images.Length;
   // 淡入下一張圖片
        Image nextImage = images[currentIndex];
        print(nextImage);
        Color nextColor = nextImage.color;
        nextImage.color = Color.clear;

        timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            currentImage.color = Color.Lerp(Color.clear, currentColor, timer / fadeTime);
            nextImage.color = Color.Lerp(Color.clear, nextColor, timer / fadeTime);
            yield return null;
        }
        currentImage.color = currentColor;
        nextImage.color = nextColor;

        fading = false;
    }
    private void Load()
    {
        // 如果是最後一張圖片，就切換到下一個場景
        if (currentIndex == images.Length - 1)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("關卡1 城市");
            asyncLoad.completed += LoadNextScene;
        }
    }
    private void LoadNextScene(AsyncOperation obj)
    {
        // 在這裡寫入您要執行的代碼，例如淡入淡出效果或者其他場景初始化操作
    }
}
