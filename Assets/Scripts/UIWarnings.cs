using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWarnings : MonoBehaviour
{
    [SerializeField] Text warningText;
    [SerializeField] Image warningImage;

    public void WarningText(string newText)
    {
        warningText.text = newText;
        warningText.gameObject.SetActive(true);
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(4f);
        warningText.gameObject.SetActive(false);
    }

    public void WarningImage(Sprite newSprite)
    {
        warningImage.sprite = newSprite;
        warningImage.gameObject.SetActive(true);
        StartCoroutine(HideImage());
    }

    IEnumerator HideImage()
    {
        yield return new WaitForSeconds(4f);
        warningImage.gameObject.SetActive(false);
    }
}
