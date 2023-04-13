using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnumList", menuName = "ScriptableObjects/EnumList", order = 0)]
public class EnumListScriptableObject : ScriptableObject
{
    public BGMType enumType;
    public List<string> stringList;
}