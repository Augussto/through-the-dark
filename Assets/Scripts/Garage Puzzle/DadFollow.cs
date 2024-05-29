using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class DadFollow : MonoBehaviour
{
    public float speed = 2f;
    public Transform player;
    public EnemyDetection padre;

    private GarageArea area;
    [SerializeField] Transform spawnPoint;
    private GameManager gm;
    [SerializeField] Sprite screamer;
    private Animator animator;

    void Start()
    {
        // Busca al jugador y la luz del jugador en la escena
        player = GameObject.FindGameObjectWithTag("Player").transform;

        area = FindObjectOfType<GarageArea>();
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(area.isInsideRoom)
        {
            // Comprueba si el jugador no está dentro del rango de la luz
            if (!padre.enemyDetected)
            {
                // Persigue al jugador
                ChasePlayer();
            }
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            transform.position = spawnPoint.position;
        }
    }

    void ChasePlayer()
    {
        // Mueve el objeto hacia la posición del jugador
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            KillPlayer();
        }
    }
    private void KillPlayer()
    {
        gm.DeadPlayer(screamer);
    }
}

