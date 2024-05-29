using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenAreaController : MonoBehaviour
{
    public bool isInsideRoom;
    [SerializeField] Sprite warningSprite;
    private UIWarnings UIWarnings;
    private KitchenPuzzleInfo puzzleInfo;

    private void Start()
    {
        UIWarnings = FindObjectOfType<UIWarnings>();
        puzzleInfo = FindObjectOfType<KitchenPuzzleInfo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInsideRoom = true;
            UIWarnings.WarningImage(warningSprite);
            if(!puzzleInfo.puzzleCompleted)
            {
                UIWarnings.WarningText("Tengo hambre, deberia calentar algo en el horno");
            }
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
