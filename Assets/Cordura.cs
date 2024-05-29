using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cordura : MonoBehaviour
{
    private FlashlightController flash;
    public float sanity;
    [SerializeField] Image sanityBar;
    private GameManager gM;
    [SerializeField] private Sprite screamer;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        sanity = 100;
        flash = FindObjectOfType<FlashlightController>();
    }

    // Update is called once per frame
    void Update()
    {
        sanityBar.fillAmount = sanity/100;

        if (!flash.flashlightOn)
        {
            loseSanity();
        }
        else
        {
            gainSanity();
        }

        if (sanity < 1)
        {
            gM.DeadPlayer(screamer);
        }
    }

    void loseSanity()
    {
        if (sanity>=0.1)
        sanity = sanity - 0.06f;
    }

    void gainSanity()
    {
        if (sanity <= 100f) sanity = sanity + 0.1f;
    }
}
