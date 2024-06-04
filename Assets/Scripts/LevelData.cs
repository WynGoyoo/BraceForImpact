using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData")]

public class LevelData : Data
{
    public bool isComplete;
    public float highScore;

    public override JObject Serialize()
    {
        SaveData sd = new SaveData(isComplete, highScore);
        string jsonString = JsonUtility.ToJson(sd);
        JObject retVal = JObject.Parse(jsonString);
        return retVal;

    }

    public override void Deserialize(string jsonString)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);

        isComplete = sd.isComplete;
        highScore = sd.highScore;
    }

    public class SaveData
    {
        public bool isComplete;
        public float highScore;

        public SaveData(bool isComplete, float highScore)
        {
            this.isComplete = isComplete;
            this.highScore = highScore;
        }
    }
}
