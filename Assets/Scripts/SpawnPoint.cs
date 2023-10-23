using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _target;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x * 0.5f);
    }

    public void SpawnEnemy()
    {
        Enemy spawnedEnemy = Instantiate(_prefab, transform.position, Quaternion.identity);

        spawnedEnemy.SetTarget(_target);
    }
}
