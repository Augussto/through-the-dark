using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThunderSound : MonoBehaviour
{
    [SerializeField] AudioSource thunder;
    [SerializeField] Light2D lightning;
    [SerializeField] float thunderTimer = 20f;

    void Start()
    {
        StartCoroutine(EffectCD());
    }
    void Update()
    {
        if(lightning.intensity != 0) lightning.intensity -= 0.01f;
        else if(lightning.intensity < 0) lightning.intensity = 0;
    }

    IEnumerator EffectCD()
    {
        yield return new WaitForSeconds(thunderTimer);
        StartCoroutine(PlayEffect());
    }

    IEnumerator PlayEffect()
    {
        thunder.Play();
        lightning.intensity = 0.5f;
        yield return null;
        StartCoroutine(EffectCD());
    }
    
}
