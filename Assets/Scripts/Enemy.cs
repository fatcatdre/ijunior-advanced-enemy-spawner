using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        ChaseTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void ChaseTarget()
    {
        if (_target == null)
            return;

        Vector3 directionToTarget = (_target.position - transform.position).normalized;

        transform.Translate(_moveSpeed * Time.deltaTime * directionToTarget);
    }
}
