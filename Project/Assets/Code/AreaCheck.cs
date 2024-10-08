using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AreaCheck : MonoBehaviour
{
    public LayerMask characterLayer;
    public AudioSource source;
    public AudioClip clip;
    public float volume = 1.0f;
    public float fadeDuration = 3.0f;
    public UnityEvent actions;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.characterLayer) != 0)
        {
            source.clip = clip;
            source.volume = 0; 
            source.Play();
            actions.Invoke();

            
            StartCoroutine(StartFade(source, fadeDuration, volume));
        }
    }

  
    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.volume = targetVolume; 
        yield break;
    }
}
