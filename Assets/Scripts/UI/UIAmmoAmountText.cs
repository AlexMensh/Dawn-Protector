using System;
using TMPro;
using UnityEngine;

public class UIAmmoAmountText : MonoBehaviour
{
    [SerializeField] private AmmoStock _ammoStock;
    [SerializeField] private TextMeshProUGUI _tracerBulletsAmountText;
    [SerializeField] private TextMeshProUGUI _rocketsAmountText;
    [SerializeField] private TextMeshProUGUI _minesAmountText;

    private void Awake()
    {
        if (_ammoStock == null)
            _ammoStock = GetComponent<AmmoStock>();
    }

    private void OnEnable()
    {
        _ammoStock.AmmoChanged += SetAmmoAmount;
    }

    private void OnDisable()
    {
        _ammoStock.AmmoChanged -= SetAmmoAmount;
    }

    private void Start()
    {
        _tracerBulletsAmountText.text = "0";
        _rocketsAmountText.text = "0";
        _minesAmountText.text = "0";
    }

    private void SetAmmoAmount(Bullet bullet, int value)
    {
        if (bullet is TracerBullet)
            _tracerBulletsAmountText.text = value.ToString();
        else if (bullet is Rocket)
            _rocketsAmountText.text = value.ToString();
        else if (bullet is Mine)
            _minesAmountText.text = value.ToString();
    }
}
