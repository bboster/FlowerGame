using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    [SerializeField]
    float minScale = 0.5f;

    [SerializeField]
    float maxScale = 1.5f;

    [SerializeField]
    float timeToGrow = 10;

    Vector3 startScale;

    float growthTimer = 0;

    private void Awake()
    {
        startScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        if(growthTimer > timeToGrow)
        {
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

    public void StartGrowth()
    {
        growthTimer = 0;
        enabled = true;
    }
}
