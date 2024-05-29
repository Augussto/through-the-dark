using System.Diagnostics;
using UnityEngine;


public class MovimientoplayerAnimaciones : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimientoX = Input.GetAxisRaw("Horizontal");
        float movimientoY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(movimientoX, movimientoY).normalized;

        playerAnimator.SetFloat("Horizontal", movimientoX);
        playerAnimator.SetFloat("Vertical", movimientoY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
        private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);
    }

}
