using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] int[] tilesWeights;
    [SerializeField] GameObject[] tiles;
    Vector3 nextSpawnPoint;
    public bool lastTileWasSpawned;

    public void SpawnTile(int index = -1)
    {
        if (index == -1) index = GetRandomWeightedIndex(tilesWeights);
        GameObject newTile = Instantiate(tiles[index], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = newTile.transform.GetChild(0).GetChild(0).position;

    }

    private void Start()
    {
        lastTileWasSpawned = false;
        for (int i = 0; i < 30; i++)
        {
            if (i < 5) SpawnTile(0);
            else SpawnTile();
        }
    }

    int GetRandomWeightedIndex(int[] weights)
    {
        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }

            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }

        // No other item was selected, so return very last index.
        return index;
    }
}
