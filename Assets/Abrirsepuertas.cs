using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Abrirsepuertas : MonoBehaviour
{
    public Tilemap doorTilemap; // Referencia al Tilemap de la puerta
    public TileBase openTile; // Tile de la puerta abierta
    public TileBase closedTile; // Tile de la puerta cerrada
    public float detectionRadius = 1f; // Radio de detección del jugador

    private Transform player; // Referencia al jugador
    private Vector3Int doorTilePosition; // Posición del tile de la puerta en el Tilemap

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        doorTilePosition = doorTilemap.WorldToCell(transform.position);
    }

    void Update()
    {
        // Obtener la posición del jugador
        Vector3 playerPosition = player.position;

        // Calcular la distancia entre el jugador y la puerta
        float distance = Vector3.Distance(playerPosition, transform.position);

        if (distance < detectionRadius)
        {
            // Abrir la puerta si el jugador está cerca
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        // Cambiar el tile de la puerta al tile abierto
        doorTilemap.SetTile(doorTilePosition, openTile);
    }
}
