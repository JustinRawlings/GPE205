using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage;
    public GameObject attacker;
    private TankData shooter;

    //creates attack object and assigns it damage and who is the attacker
    public Attack(GameObject Attacker, int Damage)
    {
        attackDamage = Damage;
        attacker = Attacker;
    }

    //References the shooter as you, and gives attack damage
    public Attack(TankData shooter, int attackDamage)
    {
        this.shooter = shooter;
        this.attackDamage = attackDamage;
    }
}