using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public Transform tf;
    public TankData attacker;
    public float speed = 10.0f;
    public float damageDone = 1.0f;
    public int attackDamage;
    private TankData shooter;

    private void OnCollisionEnter(Collision collision)
    {
        Attack attackData = new Attack(shooter: shooter, attackDamage);
    }

    private void Awake()
    {
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        tf.position += tf.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        TankData otherData = other.GetComponent<TankData>();
        if (otherData != null)
        {
            otherData.health.TakeDamage(damageDone, shooter);
        }
    }

}