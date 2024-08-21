using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; }
}