using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates the data for movement, rotation, and cannonball damage
public class TankData : MonoBehaviour
{
    public Transform tf;
    public TankMotor motor;
    public TankShooter attack;
    public Health health;

    public float moveSpeed = 3f;
    public float turnSpeed = 30f;
    public int cannonBallDamage = 1;
    public float fireCooldown = 1.5f;

    public GameObject cannonBallPrefab;
    internal object mover;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        motor = GetComponent<TankMotor>();
        attack = GetComponent<TankShooter>();
        health = GetComponent<Health>();
    }
    private void Start()
    {
        
    }

}
