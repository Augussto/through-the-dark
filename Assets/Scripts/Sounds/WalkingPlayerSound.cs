using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlayerSound : MonoBehaviour
{
    private PlayerMovement pm;
    [SerializeField] AudioSource walking;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isMoving) walking.mute = false;
        else walking.mute = true;
    }
}
