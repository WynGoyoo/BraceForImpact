using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : ScriptableObject, ISave
{
    public virtual void Deserialize(string jsonString)
    {
        throw new System.NotImplementedException();
    }

    public virtual JObject Serialize()
    {
        throw new System.NotImplementedException();
    }
}
