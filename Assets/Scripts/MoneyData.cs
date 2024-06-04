using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LevelData;

[CreateAssetMenu(menuName = "ScriptableObjects/CoinData")]
public class MoneyData : Data
{
    public int Coins;

    public override JObject Serialize()
    {
        SaveData sd = new SaveData(Coins);
        string jsonString = JsonUtility.ToJson(sd);
        JObject retVal = JObject.Parse(jsonString);
        return retVal;

    }

    public override void Deserialize(string jsonString)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);

        Coins = sd.Coins;
    }

    public class SaveData
    {
        public int Coins;

        public SaveData(int coins)
        {
            Coins = coins;
        }
    }
}
