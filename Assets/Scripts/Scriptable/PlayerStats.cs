using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats Template", menuName = "Player Template", order = 52)]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    public float maxHealth;
    public int soulShards;
    public float speed;
    //dash speed
    //dash cd
    //dash distance
    public bool isDead;
    public GameObject[] weapons;

    [NonSerialized]
    private float healthValue;

    public float CurrentHealth
    {
        get { return healthValue; }
        set
        {
            if (healthValue > maxHealth)
                healthValue = maxHealth;
            else if (healthValue < 0)
                healthValue = 0;
            else
                healthValue = value;
        }
    }

    public void OnAfterDeserialize()
    {
        healthValue = maxHealth;
    }

    public void OnBeforeSerialize() { }
}
