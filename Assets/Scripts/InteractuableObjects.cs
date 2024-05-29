using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObjects : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") text.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") text.SetActive(false);
    }
}
