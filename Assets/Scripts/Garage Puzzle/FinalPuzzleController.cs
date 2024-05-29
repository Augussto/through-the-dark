using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleController : MonoBehaviour
{
    public BedroomSwitch bedroomPuzzle;
    public KitchenPuzzleInfo kitchenPuzzle;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private UIWarnings warnings;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        bedroomPuzzle = FindObjectOfType<BedroomSwitch>();
        kitchenPuzzle = FindObjectOfType<KitchenPuzzleInfo>();
        rb = GetComponent<Rigidbody2D>();
        warnings = FindObjectOfType<UIWarnings>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bedroomPuzzle.puzzleCompleted && kitchenPuzzle.puzzleCompleted)
        {
            boxCollider.isTrigger = false;
            rb.gravityScale = 0.25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            warnings.WarningText("Necesitas 2 ruedas y una bateria para empujar esto");
        }
    }
}
