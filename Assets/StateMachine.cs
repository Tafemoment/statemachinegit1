using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public enum State
    {
        Patrol,
        Hunt,
        Pursue,
        FindBerries
    }

    [SerializeField] private State _state;

    private void Start()
    {
        NextState();
    }

    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.FindBerries:
                StartCoroutine(FindBerriesState());
                break;
            default:
                Debug.LogWarning("State does not exist in NextState function, stopping statemachine");
                break;
        }
    }
    private IEnumerator PatrolState()
    {
        Debug.Log("Patrolling");
        while (_state == State.Patrol)
        {
            yield return null; //wait 1 frame
        }
        Debug.Log("Halting Patrol");
        NextState();
    }
    
    private IEnumerator FindBerriesState()
    {
        Debug.Log("Berry Picking");
        while (_state == State.FindBerries)
        {
            yield return null; //wait 1 frame
        }
        Debug.Log("Ending Berry Search");
        NextState();
    }

    

}
