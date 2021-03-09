using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    private void Start()
    {
        groundSpawner =GameObject.FindGameObjectWithTag("GameController").GetComponent<GroundSpawner>();
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }
}
