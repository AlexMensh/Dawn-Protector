using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AmmoSetter))]
public class AmmoStock : MonoBehaviour
{ 
    [SerializeField] private DefaultBullet _defaultBullet;
    [SerializeField] private TracerBullet _tracerBullet;
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Mine _mine;
    
    private Dictionary<Bullet, int> _ammoStock = new ();
    private AmmoSetter _ammoSetter;
    
    public event Action<Bullet, int> AmmoChanged;
    
    public void Awake()
    {
        _ammoStock.Add(_tracerBullet, 0);
        _ammoStock.Add(_rocket, 0);
        _ammoStock.Add(_mine, 0);
    }
    
    private void Start()
    {
        _ammoSetter = GetComponent<AmmoSetter>();
    }
    
    public void AddTracerBullet()
    {
        _ammoStock.TryGetValue(_tracerBullet, out int value);
        value++;
        _ammoStock[_tracerBullet] = value;
        
        AmmoChanged?.Invoke(_tracerBullet, value);
    }
    
    public void AddRocket()
    {
        _ammoStock.TryGetValue(_rocket, out int value);
        value++;
        _ammoStock[_rocket] = value;
        
        AmmoChanged?.Invoke(_rocket, value);
    }
    
    public void AddMine()
    {
        _ammoStock.TryGetValue(_mine, out int value);
        value++;
        _ammoStock[_mine] = value;
        
        AmmoChanged?.Invoke(_mine, value);
    }
    
    public void RemoveBullet(Bullet bullet)  
    {
        _ammoStock.TryGetValue(bullet, out int value);
        value--;
        _ammoStock[bullet] = value;
        
        AmmoChanged?.Invoke(bullet, value);

        if (value == 0)
            _ammoSetter.SetDefault();
    }
    
    public bool CheckAmount(Bullet bullet)
    {
        return _ammoStock.TryGetValue(bullet, out int value) && value > 0;
    }
}