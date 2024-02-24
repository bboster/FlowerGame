using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Growable : MonoBehaviour
{
    [SerializeField]
    float minScale = 0.5f;

    [SerializeField]
    float maxScale = 1.5f;

    [SerializeField]
    float timeToGrow = 10;

    [SerializeField]
    ParticleSystem fullyGrownParticles;

    [SerializeField]
    UnityEvent FullGrowthEvent;

    Vector3 startScale;

    float growthTimer = 0;

    bool isGrowing = false;

    private void Awake()
    {
        startScale = transform.localScale;

        FullGrowthEvent.AddListener(ActivateParticles);
    }

    private void FixedUpdate()
    {
        if (!isGrowing)
            return;

        if(growthTimer > timeToGrow)
        {
            isGrowing = false;
            FullGrowthEvent.Invoke();
            return;
        }

        growthTimer += Time.fixedDeltaTime;

        Scale(growthTimer / timeToGrow);
    }

    private void Scale(float progress)
    {
        Vector3 newScaleVector = startScale;
        float scaleModifier = minScale + ((maxScale - minScale) * progress);

        newScaleVector *= scaleModifier;

        transform.localScale = newScaleVector;
    }

    private void ActivateParticles()
    {
        var vel = fullyGrownParticles.velocityOverLifetime;
        vel.speedModifier = transform.localScale.y;
        fullyGrownParticles.Play();
    }

    public void StartGrowth()
    {
        growthTimer = 0;
        enabled = true;

        isGrowing = true;
    }

    public bool IsGrowing()
    {
        return isGrowing;
    }
}
