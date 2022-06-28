using UnityEngine;

public class Kid : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DataDalogue dataDalogues;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string target = "player";
    #endregion
    private void OnTriggerEnter(Collider other)
    {
       // if (other.name == target) dialongueSystem.StartDialogue(dataDalogues.dialogues);
    }
}
