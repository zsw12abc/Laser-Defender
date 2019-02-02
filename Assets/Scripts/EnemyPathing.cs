using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig waveConfig;
    [SerializeField] private float moveSpeed = 2f;


    // Start is called before the first frame update
    private int _wayPointIndex = 0;
    private List<Transform> _wayPoints;

    private void Start()
    {
        _wayPoints = waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_wayPointIndex <= _wayPoints.Count - 1)
        {
            var targetPosition = _wayPoints[_wayPointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition) _wayPointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}