using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DeathVFX;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
