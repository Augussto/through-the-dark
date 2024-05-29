using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySister : MonoBehaviour
{
    public EnemyDetection flaslight;
    [SerializeField] Transform[] patrollPoints;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    private PlayerMovement pm;
    private int currentTargetIndex = 0;
    private BedroomArea area;
    private GameManager gm;
    [SerializeField] Sprite screamer;
    private Animator animator;
    [SerializeField] AudioSource steps;
    [SerializeField] private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = FindObjectOfType<PlayerMovement>();
        area = FindObjectOfType<BedroomArea>();
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(pm.transform.position, transform.position);
        if (area.isInsideRoom)
        {
            steps.mute = false;

            if (distance < 1.5f) steps.volume = 1f;
            else if(distance < 3.5f) steps.volume = 0.7f;
            else if(distance < 5.5f) steps.volume = 0.4f;
            else steps.volume = 0.2f;
        } 
        else
        {
            steps.mute = true;
            steps.volume = 0.2f;
        }
    }

    void FixedUpdate()
    {
        if (flaslight.enemyDetected && area.isInsideRoom)
        {
            // Calculate direction towards the current target
            Vector2 direction = (pm.transform.position - transform.position).normalized;

            // Move towards the current target
            rb.velocity = direction * speed;
            animator.SetFloat("Horizontal",direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", speed);
        }
        else if (patrollPoints.Length > 0)
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
    private void OnDestroy()
    {
        steps.mute = true;
    }
    private void KillPlayer()
    {
        gm.DeadPlayer(screamer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && flaslight.enemyDetected)
        {
            KillPlayer();
        }
    }
}
