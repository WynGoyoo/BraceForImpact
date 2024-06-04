using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float maxHealth = 20;
    public float damage = 10;
    public float damageLava = 10000;
}
