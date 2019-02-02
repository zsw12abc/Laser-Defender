using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig _waveConfig;
    private int _wayPointIndex = 0;
    private List<Transform> _wayPoints;

    private void Start()
    {
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this._waveConfig = waveConfig;
    }

    private void Move()
    {
        if (_wayPointIndex <= _wayPoints.Count - 1)
        {
            var targetPosition = _wayPoints[_wayPointIndex].transform.position;
            var movementThisFrame = _waveConfig.GetMovesSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition) _wayPointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}