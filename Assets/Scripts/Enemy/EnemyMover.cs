using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _visionValue;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= _visionValue)
        {
            var direction = (Player.Instance.transform.position - transform.position).normalized;
            
            _rigidbody.velocity = direction * (_speed * Time.deltaTime);
        }
    }
}
