using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public TankData pawn;
    public enum LoopTypes
    {
        Loop,
        Stop,
        PingPong,
        Random
    };

    public enum AIStates
    {
        Idle, Patrol, TurnToAvoid, MoveToAvoid, Chase, Flee
    }

    public LoopTypes loopType;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public float cutoff;
    public bool isForward;
    public float stateStartTime;
    public AIStates currentState;
    public float feelerDistance;

    public void ChangeState( AIStates newState )
    {
        // Save the time I entered this state
        stateStartTime = Time.time;
        currentState = newState;
    }
    public void Idle()
    {
        // Do Nothing!
    }

    public bool isBlocked()
    {
        if (Physics.Raycast(pawn.tf.position, pawn.tf.forward, feelerDistance))
        {
            return true;
        }

        return false;
    }



   
    

   
                }
            }
        }
    }
}
