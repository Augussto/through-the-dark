using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMom : MonoBehaviour
{
    [SerializeField] Transform[] patrollPoints;
    [SerializeField] int currentTargetIndex = 0;
    private Rigidbody2D rb;
    private SpriteRenderer spriteR;
    private KitchenAreaController area;
    private PlayerMovement pm;
    public bool isActive;
    public bool playerInRange;
    public float speed;
    [SerializeField] bool kill;
    private GameManager gm;
    [SerializeField] Sprite screamer;
    private Animator animator;
    [SerializeField] AudioSource steps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = rb.GetComponent<SpriteRenderer>();
        area = FindObjectOfType<KitchenAreaController>();
        pm = FindObjectOfType<PlayerMovement>();
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(StartMoving());
    }

    private void Update()
    {
        if(isActive && playerInRange && pm.isMoving)
        {
            StartCoroutine(KillPlayer());
        }

        if(isActive && area.isInsideRoom)
        {
            steps.mute = false;
        }
        else
        {
            steps.mute = true;
        }
    }

    void FixedUpdate()
    {
        if(kill)
        {
            // Calculate direction towards the current target
            Vector2 direction = (pm.transform.position - transform.position).normalized;

            // Move towards the current target
            rb.velocity = direction * speed;

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", speed);
        }
        else if (patrollPoints.Length > 0 && isActive)
        {
            // Calculate direction towards the current target
            Vector2 direction = (patrollPoints[currentTargetIndex].position - transform.position).normalized;

            // Move towards the current target
            rb.velocity = direction * speed;

            // If the object is close enough to the current target, switch to the next target
            if (Vector2.Distance(transform.position, patrollPoints[currentTargetIndex].position) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % patrollPoints.Length; // Move to the next target, looping back to the first if needed
            }
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0f);
        }

    }
    IEnumerator KillPlayer()
    {
        kill = true;
        speed = 6;
        yield return new WaitForSeconds(2f);
        //gm.DeadPlayer();
    }
    private void TouchPlayer()
    {
        gm.DeadPlayer(screamer);
    }
    IEnumerator MovementOnCD()
    {
        isActive = false;
        //spriteR.color = Color.yellow;
        yield return new WaitForSeconds(4f);
        if(area.isInsideRoom) StartCoroutine(StartMoving());
        else StartCoroutine(MovementOnCD());
    }

    IEnumerator StartMoving()
    {
        isActive = true;
        //spriteR.color = Color.red;
        yield return new WaitForSeconds(3f);
        StartCoroutine(MovementOnCD());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            TouchPlayer();
        }
    }
}
