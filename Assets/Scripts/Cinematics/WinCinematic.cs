using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCinematic : MonoBehaviour
{
    private Image image;
    public Sprite[] apertura;
    public GameObject optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        image = GetComponent<Image>();
        StartCoroutine(IntroImages(0));
    }

    IEnumerator IntroImages(int i)
    {
        image.sprite = apertura[i];
        yield return new WaitForSeconds(2f);
        if (i == 2) ShowOptionsPanel();
        else StartCoroutine(IntroImages(i + 1));
    }

    private void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
