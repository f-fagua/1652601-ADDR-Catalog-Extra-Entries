using System;
using UnityEngine;

public class AssetComponent : MonoBehaviour
{
    public SerializableClass Ref;
    public SerializableClass Ref2;
    public SerializableClass Ref3;
    
    [Serializable]
    public class SerializableClass
    {
        public int C;
    }
}
