using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private List<Vector3> availableCells;
    [SerializeField]
    private Tilemap tileMap;

    private void ConstructAvailableLocationOfTiles()
	{
        availableCells = new List<Vector3>();
        for (int i = tileMap.cellBounds.xMin + 2; i < tileMap.cellBounds.xMax - 1; i++)
		{
            for (int j = tileMap.cellBounds.yMin + 2; j < tileMap.cellBounds.yMax - 1; j++)
			{
                Vector3Int localPlace = new Vector3Int(i, j, (int)tileMap.transform.position.y);
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
				{
                    availableCells.Add(place);
                }
                else
				{
                }
            }
		}
        
	}

    // TODO: pass array of number of enemies type
    public void GenerateItem(GameObject item, int numberOfItem)
	{
        if (availableCells == null)
		{
            ConstructAvailableLocationOfTiles();
		}
        for (int i = 0; i < numberOfItem; ++i)
		{
            int randomIndex = Random.Range(0, availableCells.Count);
            Vector3 randomPosition = availableCells[randomIndex];
            Instantiate(item, new Vector3(randomPosition.x + 0.5f, randomPosition.y + 0.5f, randomPosition.z), Quaternion.identity);
        }
	}

    public List<Vector3> GenerateRandomPosition(int n, Vector3[] positions, float minDistance = 0f)
    {
        if (availableCells == null)
        {
            ConstructAvailableLocationOfTiles();
        }

        List<Vector3> result = new List<Vector3>();

        float getDistance(Vector3 pos)
		{
            // replace euler distance by manhatan distance -> reduce time complexity
            float getManhattanDistance(Vector3 A, Vector3 B)
			{
                return Mathf.Abs(A.x - B.x) + Mathf.Abs(A.y - B.y);
			}
            float minDist = getManhattanDistance(pos, positions[0]);
            for (int i = 1; i < positions.Length; ++i)
			{
                float curDist = getManhattanDistance(pos, positions[i]);
                if (curDist < minDist)
                    minDist = curDist; 
			}
            return minDist;
		}

        for (int i = 0; i < n; ++i)
        {
            int randomIndex = Random.Range(0, availableCells.Count);
            Vector3 randomPosition = availableCells[randomIndex];
            // warning: this code maybe infinity loop, fix later
            while (getDistance(randomPosition) < minDistance)
			{
                randomIndex = Random.Range(0, availableCells.Count);
                randomPosition = availableCells[randomIndex];
            }
            Debug.Log(getDistance(randomPosition));
            randomPosition = new Vector3(randomPosition.x + 0.5f, randomPosition.y + 0.5f, randomPosition.z);
            result.Add(randomPosition);
        }

        return result;
    }
}
