using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]
public class InputController : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;

    public enum InputScheme { WASD, arrowKeys };
    public InputScheme inputScheme = InputScheme.WASD;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (inputScheme)
        {
            case InputScheme.WASD:
                // When pressing W and S, the tank moves Back and Forth
                if (Input.GetKey(KeyCode.W))
                {
                    motor.Move(data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    motor.Move(-data.moveSpeed);
                }
                else
                {
                    motor.Move(0);
                }

                // when pressing A and D key, the tank moves left and right respectively
                if (Input.GetKey(KeyCode.A))
                {
                    motor.Rotate(-data.turnSpeed);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    motor.Rotate(data.turnSpeed);
                }

                // When space is pressed, shoots the cannonball
                if (Input.GetKey(KeyCode.Space))
                {
                    data.attack.Shoot(data.cannonBallPrefab);
                }

                break;
            case InputScheme.arrowKeys:
                break;
            default:
                Debug.LogError("[InputController] Input scheme not implemented.");
                break;
        }


    }
}