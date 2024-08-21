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
        AddBullet(_tracerBullet);
    }
    
    public void AddRocket()
    {
        AddBullet(_rocket);
    }
    
    public void AddMine()
    {
        AddBullet(_mine);
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

    private void AddBullet(Bullet bullet)
    {
        _ammoStock.TryGetValue(bullet, out int value);
        value++;
        _ammoStock[bullet] = value;
        
        AmmoChanged?.Invoke(bullet, value);
    }
}