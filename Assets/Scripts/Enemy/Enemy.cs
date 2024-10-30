using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    
    private bool _canAttack = true;
    
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
