using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// John Paul Fairbanks - audio system Understood through SwishSwoosh tutorial
public class BackgroundMusic : MonoBehaviour
{
    private AudioSource origin;

    void Start()
    {
        // Starts music volume at a lower volume.
        origin = GetComponent<AudioSource>();
        origin.volume = 0f;
        StartCoroutine(Fade(true, origin, 2f, 1f));
    }

    public IEnumerator Fade(bool fadeIn, AudioSource origin, float duration, float endVolume)
    {
        if(!fadeIn)
        {
            double lengthOfAudio = (double)origin.clip.samples / origin.clip.frequency;
            yield return new WaitForSeconds((float)(lengthOfAudio - duration));
        }

        float time = 0f;
        float startVol = origin.volume;
        while(time < duration)
        {
            time += Time.deltaTime;
            origin.volume = Mathf.Lerp(startVol, endVolume, time / duration);
        }

        yield break;
    }

    
}
