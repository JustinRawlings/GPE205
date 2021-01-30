using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class TankShooter : MonoBehaviour
{
    public Transform firePoint; // Use this point in space for instantiating cannon balls
    private TankData data;
    private float lastFireTime;
    private GameObject cannonBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        lastFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(GameObject cannonBallPrefab)
    {
        
        if (Time.time > lastFireTime + data.fireCooldown)
        {
            GameObject firedcannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation) as GameObject;
            CannonBall cannonBall = firedcannonBall.GetComponent<CannonBall>();
            if (cannonBall != null)
            {
                cannonBall.attacker = data;
            }

            lastFireTime = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}