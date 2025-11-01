using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [SerializeField] private float _damage;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<IDamageable>(out var component))
        {
            component.OnDamage(_damage);
        }
    }
}