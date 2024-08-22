using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    
    public void ApplyDamage(float damage)
    { 
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            gameObject.SetActive(false);
        }
    }
}
