using System;
using UnityEngine;

[RequireComponent(typeof(AmmoStock))]
public class AmmoSetter : MonoBehaviour
{
    [SerializeField] private DefaultBullet _defaultBullet;
    [SerializeField] private TracerBullet _tracerBullet;
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Mine _mine;

    private AmmoStock _ammoStock;

    public event Action<Bullet> AmmoChanged;

    private void Start()
    {
        _ammoStock = GetComponent<AmmoStock>();
    }

    public void SetDefault()
    {
        AmmoChanged?.Invoke(_defaultBullet);
    }

    public void SetTracer()
    {
        CheckAndSetAmmo(_tracerBullet);
    }

    public void SetRocket()
    {
        CheckAndSetAmmo(_rocket);
    }

    public void SetMine()
    {
        CheckAndSetAmmo(_mine);
    }

    public void RemoveBullet(Bullet bullet)
    {
        _ammoStock.RemoveBullet(bullet);
    }
    
    private void CheckAndSetAmmo(Bullet bullet)
    {
        if (_ammoStock.CheckAmount(bullet))
            AmmoChanged?.Invoke(bullet);
    }
}
