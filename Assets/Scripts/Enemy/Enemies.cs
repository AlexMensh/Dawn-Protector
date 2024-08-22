using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemiesMover))]
public class Enemies : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    
    private EnemiesMover _enemiesMover;

    private void Awake()
    {
        if (_enemiesMover == null)
            _enemiesMover = GetComponent<EnemiesMover>();
    }

    private void OnEnable()
    {
        _enemiesMover.TurnFinished += GetEnemiesCount;
    }

    private void OnDisable()
    {
        _enemiesMover.TurnFinished += GetEnemiesCount;
    }

    private void GetEnemiesCount()
    {
        int enemiesCount = _enemies.Count;
        foreach (var enemy in _enemies)
        {
            if (enemy.isActiveAndEnabled == false)
            {
                enemiesCount--;
            }
        }

        if (enemiesCount > 0)
            Debug.Log(enemiesCount);
        else
            Debug.Log("Player Win");
    }
    
    private void RemoveEnemy(Enemy enemy)
    {
        if (enemy != null)
            _enemies.Remove(enemy);
    }
}