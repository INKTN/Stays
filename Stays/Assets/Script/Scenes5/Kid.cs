using UnityEngine;

public class Kid : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DataDalogue dataDalogues;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string target = "player";
    #endregion
    private void OnTriggerEnter(Collider other)
    {
       // if (other.name == target) dialongueSystem.StartDialogue(dataDalogues.dialogues);
    }
}
