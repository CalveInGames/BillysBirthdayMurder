using UnityEngine;
using TMPro;
using Fungus;

public class HUDStatsUpdater : MonoBehaviour
{
    public Flowchart flowchart;
    public TMP_Text logicText;
    public TMP_Text empathyText;
    public TMP_Text humorText;

    public string logicVar = "LogicPoints";
    public string empathyVar = "EmpathyPoints";
    public string humorVar = "HumorPoints";

    // Call this from Fungus
    public void Apply()
    {
        if (!flowchart) return;
        if (logicText)   logicText.text   = flowchart.GetIntegerVariable(logicVar).ToString();
        if (empathyText) empathyText.text = flowchart.GetIntegerVariable(empathyVar).ToString();
        if (humorText)   humorText.text   = flowchart.GetIntegerVariable(humorVar).ToString();
    }
}
