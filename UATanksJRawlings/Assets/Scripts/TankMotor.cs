using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireCompontent(typeof(TankData))]
[RequireComponent(typeof(CharacterController))]
public class TankMotor : MonoBehaviour
{
    private TankData data;
    private CharacterController characterController;

    public void Start()
    {
        data = GetComponent<TankData>();
        characterController = GetComponent<CharacterController>();
    }

    public void Move(float moveSpeed)
    {
        Vector3 speedVector = transform.forward * moveSpeed;
        characterController.SimpleMove(speedVector);
    }

    public void Rotate(float rotateSpeed)
    {
        Vector3 rotateVector = Vector3.up * rotateSpeed * Time.deltaTime;
        transform.Rotate(rotateVector, Space.Self);
    }
}