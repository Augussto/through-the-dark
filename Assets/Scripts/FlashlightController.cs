using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Transform flashlightTransform; // Reference to the gun's transform
    [SerializeField] GameObject flashlight;
    public bool flashlightOn= true;
    private LightSwitchSound sound;

    private void Start()
    {
        sound = FindObjectOfType<LightSwitchSound>();
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate the direction from the player to the mouse
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        flashlightTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0) && flashlightOn)
        {
            flashlightOn = false;
            flashlight.SetActive(false);
            sound.PlaySound();
        }
        else if (Input.GetMouseButtonDown(0) && !flashlightOn)
        {
            flashlightOn = true;
            flashlight.SetActive(true);
            sound.PlaySound();
        }
    }
}
