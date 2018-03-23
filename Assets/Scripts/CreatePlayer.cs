using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{

    [SerializeField] private Skill skill;
    [SerializeField] private float health;
    [SerializeField] private float defence;
    [SerializeField] private MainWeapon mainWeapon;
    [SerializeField] private AdditionalWeapon additionalWeapon;

    public void CreateProcess()
    {
        Player.Instance.SetSkill(skill);
        Player.Instance.SetHealth(health);
        Player.Instance.SetDefence(defence);
        Player.Instance.SetMainWeapon(mainWeapon);
        Player.Instance.SetAdditionalWeapon(additionalWeapon);
    }
}
