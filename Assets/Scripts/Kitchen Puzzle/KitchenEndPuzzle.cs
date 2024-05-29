using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenEndPuzzle : MonoBehaviour
{
    [SerializeField] bool inRange;
    private KitchenPuzzleInfo puzzleInfo;
    private UIWarnings warnings;
    // Start is called before the first frame update
    void Start()
    {
        puzzleInfo = FindObjectOfType<KitchenPuzzleInfo>();
        warnings = FindObjectOfType<UIWarnings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if(puzzleInfo.items.Count == 3)
            {
                puzzleInfo.puzzleCompleted = true;
            }
            else
            {
                warnings.WarningText("Te faltan ingredientes");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
}
