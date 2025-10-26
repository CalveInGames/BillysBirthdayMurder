using UnityEngine;
using Fungus;
using System.Reflection;

public class SetCharacterDisplayName : MonoBehaviour
{
    public Flowchart flowchart;
    public Character character;
    public string variableName = "PlayerName";

    public void Apply()
    {
        if (flowchart == null || character == null) return;

        string newName = flowchart.GetStringVariable(variableName);
        if (string.IsNullOrEmpty(newName)) newName = "Obake";

        // Try property 'Name'
        var nameProp = character.GetType().GetProperty("Name");
        if (nameProp != null && nameProp.CanWrite)
        {
            nameProp.SetValue(character, newName);
            return;
        }

        // Try method 'SetName(string)'
        var setName = character.GetType().GetMethod("SetName", new[] { typeof(string) });
        if (setName != null)
        {
            setName.Invoke(character, new object[] { newName });
            return;
        }

        // Last resort: set private backing field (commonly 'nameText')
        var nameField = character.GetType().GetField("nameText", BindingFlags.NonPublic | BindingFlags.Instance);
        if (nameField != null)
        {
            nameField.SetValue(character, newName);
        }
        else
        {
            Debug.LogWarning("Could not set Character display name on this Fungus version.");
        }
    }
}