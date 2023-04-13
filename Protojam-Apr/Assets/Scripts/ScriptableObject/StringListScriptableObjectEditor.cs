using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

[CustomEditor(typeof(EnumListScriptableObject))]
public class StringListScriptableObjectEditor : Editor
{
    private EnumListScriptableObject _stringList;

    private void OnEnable()
    {
        _stringList = (EnumListScriptableObject)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        if (GUILayout.Button("Apply List to Enum"))
        {
            ApplyListToEnum();
        }
    }

    private void ApplyListToEnum()
    {
        var enumType = _stringList.enumType.GetType();

        if (!enumType.IsEnum)
        {
            Debug.LogError("The specified type is not an Enum!");
            return;
        }

        GenerateEnum(enumType.Name, _stringList.stringList);

        AssetDatabase.Refresh();
    }

    private void GenerateEnum(string enumName, List<string> enumValues)
    {
        var filePath = $"{Application.dataPath}/Scripts/Enums/{enumName}.cs";

        using var file = new StreamWriter(filePath);
        file.WriteLine("public enum " + enumName);
        file.WriteLine("{");

        for (int i = 0; i < enumValues.Count; i++)
        {
            file.WriteLine($"    {enumValues[i]}{(i < enumValues.Count - 1 ? "," : "")}");
        }

        file.WriteLine("}");
    }
}