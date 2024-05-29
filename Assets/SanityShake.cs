using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    private Cordura sanity;

    private Vector3 originalPos;
    private float currentShakeDuration = 0f;

    [SerializeField] Transform player;

    void Start()
    {
        sanity = FindObjectOfType<Cordura>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        originalPos = cameraTransform.localPosition;
        player = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    void Update()
    {
        originalPos = cameraTransform.localPosition;
        if (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeMagnitude;
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            //cameraTransform.localPosition = originalPosition;
            currentShakeDuration = 0f;
        }

        if (sanity.sanity <= 50)
        {
            TriggerShake(1f);
        }
        else
        {
            StopShake();
        }
    }

    public void TriggerShake(float duration)
    {
        currentShakeDuration = duration;
    }

    public void StopShake()
    {
        currentShakeDuration = 0f;
        cameraTransform.localPosition = originalPos;
    }
}


