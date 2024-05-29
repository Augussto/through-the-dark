using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPuzzleInfo : MonoBehaviour
{
    public List<KitchenItemController> items;
    public bool puzzleCompleted;
    public GameObject UIIndicator;

    private void Update()
    {
        if (puzzleCompleted)
        {
            UIIndicator.SetActive(true);
        }
    }
}
