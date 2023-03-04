using UnityEngine;
using System.Collections;

public class ChatTest : MonoBehaviour
{
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    void Start()
    {
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取 
        dialongueSystem.NameEnter(dataDalogues[0].talkName);

    }

    
    void Update()
    {
        
    }
}
