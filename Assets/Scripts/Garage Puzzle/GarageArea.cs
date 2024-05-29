using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageArea : MonoBehaviour
{
    public bool isInsideRoom;
    [SerializeField] Sprite warningSprite;
    private UIWarnings UIWarnings;

    private void Start()
    {
        UIWarnings = FindObjectOfType<UIWarnings>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInsideRoom = true;
            UIWarnings.WarningImage(warningSprite);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInsideRoom = false;
        }
    }
}
