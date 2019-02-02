using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;

    private int _startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[_startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (var enemyCount = 0; enemyCount < currentWave.GetNumberOfEnemies(); enemyCount++)
        {
            Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWayPoints()[0].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}