using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    
    private readonly Vector3 _rayVector = new Vector3(0.5f, 0.5f, 0);
    private bool _isAlive;

    public bool IsAlive => _isAlive;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
        
        _isAlive = true;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
        Debug.DrawRay(_rayVector, transform.position * _attackRange, Color.yellow);
        
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ViewportPointToRay(_rayVector);
            
            if (Physics.Raycast(ray, out var hit, _attackRange))
            {
                if (hit.transform.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }
        }
    }

    private void Die()
    {
        if (_health <= 0f)
        {
            Camera.main.transform.parent = null;
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
    
    public void TakeDamage(float damage)
    {
        if (_damage <= 0) 
            return;
        
        _health -= damage;
        
        Die();
    }
}
