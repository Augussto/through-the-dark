using UnityEngine;

using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    public Tilemap tilemap;  // Referencia al Tilemap
    public TileBase newTile; // Nuevo Tile que se usará para el cambio
    public Vector3Int tilePosition; // Posición del Tile que cambiará

    private TileBase originalTile; // Para almacenar el Tile original

    private OpenDoorSound doorSFX;

    void Start()
    {
        doorSFX = FindObjectOfType<OpenDoorSound>();
        // Obtener el Tile original en la posición específica
        originalTile = tilemap.GetTile(tilePosition);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Cambia esto según la tag de tu jugador
        {
            doorSFX.PlaySound();
            ChangeToNewTile();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Cambia esto según la tag de tu jugador
        {
            ChangeToOriginalTile();
        }
    }

    void ChangeToNewTile()
    {
        tilemap.SetTile(tilePosition, newTile);
    }

    void ChangeToOriginalTile()
    {
        tilemap.SetTile(tilePosition, originalTile);
    }
}
