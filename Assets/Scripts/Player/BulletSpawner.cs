using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private DefaultBullet _defaultBulletPrefab;
    [SerializeField] private AmmoSetter _ammoSetter;
    
    private ObjectPooler<Bullet> _pool;
    private Bullet _prefab;
    
    private void Awake()
    {
        if (_ammoSetter == null)
            _ammoSetter = GetComponent<AmmoSetter>();
        _prefab = _defaultBulletPrefab;
        _pool = new ObjectPooler<Bullet>(_prefab, _container);
    }

    private void OnEnable()
    {
        _ammoSetter.AmmoChanged += SetBulletPrefab;
    }
    
    private void OnDisable()
    {
        _ammoSetter.AmmoChanged -= SetBulletPrefab;
    }
    
    public void RemoveObject(Bullet bullet)
    {
        _pool.PutObject(bullet);
    }
    
    public Bullet SpawnObject(Vector3 position)
    {
        var bullet = _pool.GetObject();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        
        if (_prefab != _defaultBulletPrefab)
            _ammoSetter.RemoveBullet(_prefab);
            
        return bullet;
    }

    private void SetBulletPrefab(Bullet bullet)
    {
        if (bullet != _prefab)
        {
            _prefab = bullet;
            _pool.UpdatePrefab(_prefab);
        }
    }
}