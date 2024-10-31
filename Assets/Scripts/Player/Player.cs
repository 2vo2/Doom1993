using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public static Player Instance;
    
    [SerializeField] private float _health;
    [SerializeField] private Weapon _startWeapon;
    
    private readonly List<Weapon> _weapons = new List<Weapon>();
    
    private bool _isAlive;
    private int _weaponIndex;
    private Camera _camera;

    public bool IsAlive => _isAlive;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        _isAlive = true;
        _weapons.Add(_startWeapon);
    }

    private void Update()
    {
        ChangedWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickUpWeapon weapon))
        {
            _weapons.Add(weapon.WeaponExample());
            weapon.PickUp();
        }
    }

    private void Die()
    {
        if (_health <= 0f)
        {
            _camera!.transform.parent = null;
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }

    private void ChangedWeapon()
    {
        if (_weapons.Count <= 1) return;
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weapons[_weaponIndex].Drop();
            _weaponIndex++;

            if (_weaponIndex >= _weapons.Count) _weaponIndex = 0;
            
            _weapons[_weaponIndex].PickUp();
        }
    }
    
    public void TakeDamage(float damage)
    {
        if (damage <= 0) 
            return;
        
        _health -= damage;
        
        Die();
    }
}
