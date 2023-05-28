using System.Collections;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoveFx;
    public AudioClip clickFx;

    
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        // Здесь можно продолжить выполнение кода после задержки
    }
}
