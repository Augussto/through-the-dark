using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchSound : MonoBehaviour
{
    [SerializeField] AudioSource lightSwitch;
    public void PlaySound()
    {
        lightSwitch.Play();
    }
}
