using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject _enemyData;
    
    private float _health;
    private float _damage;
    private float _attackSpeed;
    private float _attackRange;
    
    private bool _canAttack = true;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= _attackRange)
        {
            if (_canAttack && Player.Instance.IsAlive)
            {
                StartCoroutine(AttackDelay());
                print("Attack");
                Player.Instance.TakeDamage(_damage);
            }
        }
    }

    private void Initialize()
    {
        _health = _enemyData.Health;
        _damage = _enemyData.Damage;
        _attackSpeed = _enemyData.AttackSpeed;
        _attackRange = _enemyData.AttackRange;
    }

    private IEnumerator AttackDelay()
    {
        _canAttack = false;
        
        yield return new WaitForSeconds(_attackSpeed);

        _canAttack = true;
    }

    private void Die()
    {
        if (_health <= 0f)
            gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            return;
        
        _health -= damage;
        
        Die();
    }
}
