using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerSound : MonoBehaviour
{
    [SerializeField] AudioSource screamer;

    public void PlayScreamer()
    {
        screamer.Play();
    }
}
