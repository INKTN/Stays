using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
//using LeanTween;
/// <summary>
/// 圖淡入淡出
/// </summary>
public class ImageSwitcher : MonoBehaviour
{
    public Image[] images;  // 存儲所有要顯示的圖片
    public float fadeTime = 0.5f;  // 淡入淡出的時間

    private int currentIndex = 0;  // 當前顯示的圖片的索引
    public bool fading = false;  // 是否正在淡入淡出
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;
    [Header("讀取開關")]
    public bool lodingtoNext;


    public float moveDistance = 100.0f; // 移动的距离
    public float moveTime = 1.0f; // 移动的时间

    private void Start()
    {
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        // 隱藏所有圖片，除了第一張
        for (int i = 1; i < images.Length; i++)
        {
            images[i].color = Color.clear;
        }
        Plot();
    }

    private void Update()
    {
        // 當按下滑鼠左鍵時，切換到下一張圖片
        if (Input.GetMouseButtonDown(0) && !fading)
        {
            StartCoroutine(FadeOut());
           
        }
       /* if (!fading)
        {
            print(images[currentIndex]);
            Move(images[currentIndex]);
        }*/
    }

    // 淡出當前圖片，然後淡入下一張圖片
    private IEnumerator FadeOut()
    {
        fading = true;
        Image currentImage = images[currentIndex];
        Color currentColor = currentImage.color;

        // 淡出當前圖片
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            currentImage.color = Color.Lerp(currentColor, Color.clear, timer / fadeTime);
            //Move(currentImage);
            yield return null;
        }

        currentImage.color = Color.clear;
       // Move(currentImage);
        currentIndex = (currentIndex + 1) % images.Length;
        // 淡入下一張圖片
        Image nextImage = images[currentIndex];
        Color nextColor = nextImage.color;
        nextImage.color = Color.clear;

        timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            currentImage.color = Color.Lerp(currentColor, Color.clear, timer / fadeTime);
            nextImage.color = Color.Lerp(Color.clear,Color.white, timer / fadeTime);
            //Move(nextImage);
            yield return null;
        }
        currentImage.color = Color.clear;
        
        nextImage.color = nextColor;
       

        fading = false;
        if(lodingtoNext)Load();
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
    private void Plot()
    {
       
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取

    }
    private void Move(Image j)
    {
        // 计算起始和结束位置
        Vector2 startPos = j.GetComponent<RectTransform>().anchoredPosition;
        //print(startPos);
        Vector2 endPos = new Vector2(startPos.x, 145);
        if(startPos!=endPos)
        // 执行移动
        LeanTween.move(j.GetComponent<RectTransform>(), endPos, moveTime);
    }
}
