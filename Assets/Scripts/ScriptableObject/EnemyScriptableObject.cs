using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/New Enemy", fileName = "New Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    
    public float Health => _health;
    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public float AttackRange => _attackRange;
}
