using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(CharacterController))]
public class TankMotor : MonoBehaviour
{
    private TankData data;
    private CharacterController characterController;

    public void Start()
    {
        // Accesses TankData component
        data = GetComponent<TankData>();
        // Accesses CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    // sets up move speed
    public void Move(float moveSpeed)
    {
        Vector3 speedVector = transform.forward * moveSpeed;
        characterController.SimpleMove(speedVector);
    }

    // sets up rotation speed
    public void Rotate(float rotateSpeed)
    {
        Vector3 rotateVector = Vector3.up * rotateSpeed * Time.deltaTime;
        transform.Rotate(rotateVector, Space.Self);
    }

    internal void Move(Vector3 forward)
    {
        throw new NotImplementedException();
    }

    internal void RotateTowards(Vector3 targetVector)
    {
        throw new NotImplementedException();
    }

    internal void SimpleMove(Vector3 forward)
    {
        throw new NotImplementedException();
    }

    internal void RotateVector(Vector3 awayVector)
    {
        throw new NotImplementedException();
    }
}
