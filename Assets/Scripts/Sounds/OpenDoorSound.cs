using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorSound : MonoBehaviour
{
    public AudioSource door;
    
    public void PlaySound()
    {
        door.Play();
    }
}
