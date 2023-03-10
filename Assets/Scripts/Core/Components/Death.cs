using System;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    [SerializeField] private AudioSource deathEnemySoundEffect;

    private ParticleManager ParticleManager =>
        particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
    
    private ParticleManager particleManager;

    private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private Stats stats;
    
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
        deathEnemySoundEffect.Play();
    }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}