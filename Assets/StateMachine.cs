using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class StateMachine : MonoBehaviour
{

    public enum State
    {
        Patrol,
        Hunt,
        FindBerries
    }

    [SerializeField] private State _state;

    private AIAgent _aiAgent;
    private SpriteRenderer _spriteRenderer;


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
            case State.Hunt:
                StartCoroutine(HuntState());
                break;
            default:
                Debug.LogWarning("State does not exist in NextState function, stopping statemachine");
                break;
        }
    }

   
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _aiAgent = GetComponent<AIAgent>();

        NextState();
    }
    private IEnumerator PatrolState()
    {
        Debug.Log("Patrolling");
        _aiAgent.Search();
        _spriteRenderer.color = Color.black;
        while (_state == State.Patrol)
        {
            _aiAgent.Patrol(); 
            if (_aiAgent.IsPlayerInRange())
            {
                _state = State.Hunt;
            }
            yield return null; //wait 1 frame
        }
        Debug.Log("Halting Patrol");
        NextState();
    }
    private IEnumerator HuntState()
    {
        Debug.Log("AYO C'MERE");
        _spriteRenderer.color = new Color(1, 0.3f, 0, 1);
        while (_state == State.Hunt)
        {
            _aiAgent.HuntPlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null; //wait a single
        }
        Debug.Log("Lost em");
        NextState();
    }
    private IEnumerator FindBerriesState()
    {
        Debug.Log("mmmmm Berries");
        while (_state == State.FindBerries)
        {
            yield return null; //wait 1 frame
        }
        Debug.Log("Ending Berry Search");
        NextState();
    }
}
