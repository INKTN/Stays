using UnityEngine;
/// <summary>
/// 觸控變換材質
/// 20220415尚未完善
/// </summary>
internal class hightlightSelectionResponse : MonoBehaviour
{
    [Header("選擇_材質替換")]
    public Material hightmaterial;
    [Header("原有材質")]
    public Material orimaterial;
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = hightmaterial;
        }

    }
    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = orimaterial;
        }
    }
}