using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenItemController : MonoBehaviour
{
    [SerializeField] Sprite onLightSprite, onDarkSprite;
    [SerializeField] SpriteRenderer currentSprite;
    [SerializeField] bool canPickUp, lookingAtItem;
    private FlashlightController flashlight;
    private KitchenPuzzleInfo puzzleInfo;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = FindObjectOfType<FlashlightController>();
        puzzleInfo = FindObjectOfType<KitchenPuzzleInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            puzzleInfo.items.Add(this);
            Destroy(this.gameObject);
        }
        if (lookingAtItem && flashlight.flashlightOn)
        {
            currentSprite.sprite = onLightSprite;
        }
        else if (lookingAtItem && !flashlight.flashlightOn)
        {
            currentSprite.sprite = onDarkSprite;
        }
        else if (!lookingAtItem)
        {
            currentSprite.sprite = onDarkSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Flashlight")
        {
            lookingAtItem = true;
        }
        else if(collision.tag == "Player")
        {
            canPickUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Flashlight")
        {
            lookingAtItem = false;
        }
        else if (collision.tag == "Player")
        {
            canPickUp = false;
        }
    }
}
