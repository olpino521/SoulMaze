using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats Template", menuName = "Player Template", order = 52)]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    public float maxHealth;
    [NonSerialized]public int soulShards;
    public float speed;
    //dash speed
    public float dashSpeed;
    //dash cd
    public float dashCooldown;
    //dash distance
    public float dashDistance;
    public bool isDead;
    public GameObject[] weapons;

    [NonSerialized]
    private float healthValue;
    [NonSerialized]
    private float dashCurrentCooldown;

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

    public float DashCurrentCooldown
    {
        get { return dashCurrentCooldown; }
        set
        {
            if (dashCurrentCooldown > dashCooldown)
                dashCurrentCooldown = dashCooldown;
            else if (dashCurrentCooldown < 0)
                dashCurrentCooldown = 0;
            else
                dashCurrentCooldown = value;
        }
    }

    public void OnAfterDeserialize()
    {
        healthValue = maxHealth;
        dashCurrentCooldown = dashCooldown;
    }

    public void OnBeforeSerialize() { }
}
