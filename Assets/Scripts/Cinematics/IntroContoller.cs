using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroContoller : MonoBehaviour
{
    private Image image;
    public Sprite[] apertura;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(IntroImages(0));
    }

    IEnumerator IntroImages(int i)
    {
        image.sprite = apertura[i];
        yield return new WaitForSeconds(2f);
        if (i == 5) SceneManager.LoadScene("Level 1");
        else StartCoroutine(IntroImages(i+1));
    }
}
