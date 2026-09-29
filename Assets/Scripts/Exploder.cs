using System.Diagnostics;
using UnityEngine;

public class Exploder : Actor
{
    public float explosionRadius = 5f;

    public override void PerformAttack()
    {
        Explode();
    }

    public override void TakeDamage(float damageAmount)
    {
        Explode();
        base.TakeDamage(damageAmount);
    }

    private void Explode()
    {
        UnityEngine.Debug.Log("Boom!");
        Destroy(gameObject);
    }

}
