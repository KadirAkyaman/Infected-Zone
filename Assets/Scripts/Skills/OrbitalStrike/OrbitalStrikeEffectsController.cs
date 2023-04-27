using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStrikeEffectsController : MonoBehaviour
{
    [SerializeField] ParticleSystem electricEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie")|| other.gameObject.CompareTag("Demon"))
        {
            electricEffect.Play();
        }
    }
}
