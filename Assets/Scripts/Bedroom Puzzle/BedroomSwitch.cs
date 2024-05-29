using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSwitch : MonoBehaviour
{
    [SerializeField] GameObject bedroomLights;
    [SerializeField] bool isInRange;
    public bool puzzleCompleted;
    private EnemySister enemySister;
    private LightSwitchSound sound;
    public GameObject UIIndicator;

    void Start()
    {
        bedroomLights.SetActive(false);
        enemySister = FindObjectOfType<EnemySister>();
        sound = FindObjectOfType<LightSwitchSound>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            puzzleCompleted = true;
            bedroomLights.SetActive(true);
            sound.PlaySound();
            UIIndicator.SetActive(true);
            Destroy(enemySister.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = false;
        }
    }
}
