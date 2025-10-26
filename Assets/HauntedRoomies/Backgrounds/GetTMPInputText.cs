using UnityEngine;
using TMPro;
using Fungus;

public class GetTMPInputText : MonoBehaviour
{
    public TMP_InputField inputField;
    public Flowchart flowchart;
    public string variableName = "PlayerName";

    public void Apply()
    {
        if (inputField == null || flowchart == null) return;

        string value = inputField.text;
        flowchart.SetStringVariable(variableName, value);
    }
}
