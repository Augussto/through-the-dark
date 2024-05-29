using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel, losePanel;
    public GameObject screamer01;
    public ScreamerSound screamerSound;
    public GameObject winCinematic;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        screamerSound = FindObjectOfType<ScreamerSound>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        Cursor.visible = false;
    }

    public void DeadPlayer(Sprite screamerSprite)
    {
        Destroy(player);
        screamerSound.PlayScreamer();
        screamer01.GetComponent<Image>().sprite = screamerSprite;
        screamer01.SetActive(true);
        StartCoroutine(HideScreamer());
    }
    IEnumerator HideScreamer()
    {
        yield return new WaitForSeconds(2f);
        screamer01.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }
    public void WinGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("WinAnimation");
        winCinematic.SetActive(true);
        StartCoroutine(WinCinematics());
    }
    IEnumerator WinCinematics()
    {
        yield return new WaitForSeconds(2f);
        winCinematic.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
}
