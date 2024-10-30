using UnityEngine;

public class PickUpWeapon : MonoBehaviour, IPickable
{
    [SerializeField] private Weapon _weapon;

    public Weapon WeaponExample()
    {
        return _weapon;
    }
    
    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    public void Drop()
    {
        gameObject.SetActive(true);
    }
}
