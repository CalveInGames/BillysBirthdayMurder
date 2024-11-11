using UnityEngine;
using Fungus;

public class ClickableObject : MonoBehaviour
{
    public Flowchart flowchart;     // Reference to the main Flowchart
    public string blockName;        // Name of the block to call on click

    private void OnMouseDown()
    {
        if (flowchart != null && !string.IsNullOrEmpty(blockName))
        {
            flowchart.ExecuteBlock(blockName);
            // Disable the GameObject to prevent further clicks
            gameObject.SetActive(false);
        }
    }
}