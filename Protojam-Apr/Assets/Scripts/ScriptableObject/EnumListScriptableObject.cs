using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnumListScriptableObject<T1, T2> : ScriptableObject where T1 : Enum
{
    [Serializable]
    public struct List
    {
        [Serializable]
        public struct Element
        {
            public T1 type;
            public T2 value;
        }
        
        [SerializeField]
        private List<Element> elements;
        
        public T2 this[T1 type]
        {
            get
            {
                return elements.FirstOrDefault(element => element.type.Equals(type)).value;
            }
        }
    }
    
    public List list;
}