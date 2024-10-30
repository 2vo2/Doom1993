using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var colliders = Physics.OverlapSphere(transform.position, AttackRange);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy)) 
                    enemy.TakeDamage(Damage);
            }
        } 
    }
}
