using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<T> where T : Bullet
{
    private Transform _container;
    private T _prefab;

    private List<T> _pool = new List<T>();

    public ObjectPooler(T prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    public T GetObject()
    {
        T item = null;

        foreach (var checkItem in _pool)
        {
            if (checkItem.isActiveAndEnabled == false)
            {
                if (checkItem.GetType() == _prefab.GetType())
                {
                    item = checkItem;
                    break;
                }
            }
        }
        
        if (item == null)
        {
            item = Object.Instantiate(_prefab);
            _pool.Add(item);
            item.transform.parent = _container;
        }

        return item;
    }

    public void PutObject(T item)
    {
        item.gameObject.SetActive(false);
    }

    public void UpdatePrefab(T newPrefab)
    {
        _prefab = newPrefab;
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item?.gameObject.SetActive(false);
        }
    }
}