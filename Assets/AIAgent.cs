using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _zoom = 10f;

    [SerializeField] private Transform[] _patrolpoints;
    [SerializeField] private int _patrolpointIndex = 0;

    public void Patrol()
    {
        Vector2 patrolpointPosition = _patrolpoints[_patrolpointIndex].position;
        MoveToPoint(patrolpointPosition);
        //MoveToPoint(_player.transform.position);
        if (Vector2.Distance(transform.position, patrolpointPosition) < 0.1f)
        {
            _patrolpointIndex++; // ++ Increase by 1 integer
        }

        if (_patrolpointIndex >= _patrolpoints.Length)
        {
            _patrolpointIndex = 0;
        }
    }

    public void Search()
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;
        for(int index = 0; index < _patrolpoints.Length; index++)
        {
            float currentDistance = Vector2.Distance(_patrolpoints[index].position, transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestIndex = index;
            }
            
        }
        _patrolpointIndex = closestIndex;
    }

    public bool IsPlayerInRange()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < 7f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void HuntPlayer()
    {
        MoveToPoint(_player.transform.position);
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