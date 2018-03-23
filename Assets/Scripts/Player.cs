using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private Skill skill;
    private float health;
    private float defence;
    private MainWeapon mainWeapon;
    private AdditionalWeapon additionalWeapon;

    private void Start()
    {
        Debug.Log("Player has been created: " +
            "skill: " + skill + "\n" +
            "health: " + health + "\n" +
            "defence: " + defence + "\n" +
            "mainWeapon: " + mainWeapon + "\n" +
            "additionalWeapon: " + additionalWeapon);
    }

    public void SetHealth(float value)
    {
        health = value;
    }

    public void SetDefence(float value)
    {
        defence = value;
    }

    public void SetSkill(Skill value)
    {
        skill = value;
    }

    public void SetMainWeapon(MainWeapon weapon)
    {
        mainWeapon = weapon;
    }

    public void SetAdditionalWeapon(AdditionalWeapon weapon)
    {
        additionalWeapon = weapon;
    }
}

public enum Skill
{
    Ice,
    Fire,
    Thunder
}

public enum MainWeapon
{
    Axe
}

public enum AdditionalWeapon
{
    Pistol,
    Machinegun,
    Shotgun
}
