using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _zoom = 10f;

    [SerializeField] private Transform[] _patrolpoints;
    [SerializeField] private int _patrolpointIndex = 0;

    void Update()
    {
        Vector2 patrolpointPosition = _patrolpoints[_patrolpointIndex].position;
        MoveToPoint(patrolpointPosition);
        //MoveToPoint(_player.transform.position);
        if (Vector2.Distance(transform.position, patrolpointPosition) < 0.5f)
        {
            _patrolpointIndex = (_patrolpointIndex++)%(_patrolpoints.Length);
        }
    }
    void MoveToPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2)transform.position;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _zoom * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}