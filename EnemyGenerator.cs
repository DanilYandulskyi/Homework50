using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _lowestBound;
    [SerializeField] private float _highestBound;
    [SerializeField] private float _delay;
    [SerializeField] private float _destroyDelay;

    private void Awake()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowestBound, _highestBound);
        Vector2 spawnPoint = new Vector2(transform.position.x, spawnPositionY);

        GameObject clone = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
        Destroy(clone, _destroyDelay);
    }
}
