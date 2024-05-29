using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoverHaciaDestino : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] Transform destino;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidad);
    }
}