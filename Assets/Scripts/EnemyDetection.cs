using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private bool lookingAtEnemy;
    public bool enemyDetected;
    [SerializeField] FlashlightController flashController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(lookingAtEnemy && flashController.flashlightOn)
        {
            enemyDetected = true;
        }
        else if (lookingAtEnemy && !flashController.flashlightOn)
        {
            enemyDetected = false;
        } 
        else if (!lookingAtEnemy)
        {
            enemyDetected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            lookingAtEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            lookingAtEnemy = false;
        }
    }
}
