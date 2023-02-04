using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class GenerateRoot : MonoBehaviour
{
    [SerializeField]
    private Grid m_grid;

    [SerializeField]
    private Tilemap m_tilemap;

    [SerializeField]
    private Tile[] m_tiles;

    [SerializeField]
    private Transform m_playerPos;

    [SerializeField]
    private Transform m_targetPos;

    private Vector3Int cellPlayer, cellBoss, posTile;
    private Vector2 gridSize;

    private int distance;

    private void Start()
    {
        gridSize = new Vector2(1, 1);
        GeneratePath();
    }

    public void GeneratePath()
    {
        cellPlayer = m_grid.WorldToCell(m_playerPos.position);
        cellBoss = m_grid.WorldToCell(m_targetPos.position);
        Debug.Log(cellPlayer.x + " " + cellPlayer.y + " " + cellBoss.x + " " + cellBoss.y);
        int xDiff = (int)Mathf.Abs(cellPlayer.x - cellBoss.x);
        int yDiff = (int)Mathf.Abs(cellPlayer.y - cellBoss.y);
        int cellDistance = (int)Math.Sqrt((Math.Pow(xDiff, 2)) + (Math.Pow(yDiff, 2)));
        Debug.Log(xDiff + " " + yDiff + " Cells between = " + cellDistance);


        Vector3Int offset = cellPlayer;
        for(int i = 0; i < cellDistance; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, 4);
            switch (randomIndex)
            {
                case 0:
                    posTile = new Vector3Int(offset.x-1, offset.y, offset.z);
                    m_tilemap.SetTile(posTile, m_tiles[0]);
                    m_tilemap.SetTransformMatrix(posTile, Matrix4x4.Rotate(Quaternion.Euler(0, 0, 90f)));
                    break;
                case 1:
                    posTile = new Vector3Int(offset.x, offset.y - 1, offset.z);
                    m_tilemap.SetTile(posTile, m_tiles[0]);
                    break;
                case 2:
                    posTile = new Vector3Int(offset.x + 1, offset.y, offset.z);
                    m_tilemap.SetTile(posTile, m_tiles[0]);
                    m_tilemap.SetTransformMatrix(posTile, Matrix4x4.Rotate(Quaternion.Euler(0, 0, 90f)));
                    break;
                case 3:
                    posTile = new Vector3Int(offset.x, offset.y + 1, offset.z);
                    m_tilemap.SetTile(posTile, m_tiles[0]);
                    break;
            }
            offset = posTile;
            Debug.Log(posTile);
        }

    }

}
