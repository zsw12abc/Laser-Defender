using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;

    [SerializeField] private float moveSpeed = 2f;

    // Start is called before the first frame update
    private int _wayPointIndex = 0;

    private void Start()
    {
        transform.position = wayPoints[_wayPointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[_wayPointIndex].transform.position;
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