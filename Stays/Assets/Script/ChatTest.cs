using UnityEngine;
using System.Collections;

public class ChatTest : MonoBehaviour
{
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    void Start()
    {
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū�� 
        dialongueSystem.NameEnter(dataDalogues[0].talkName);

    }

    
    void Update()
    {
        
    }
}
