using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Spike")
        {
            GameController.gameOver = true;
        }
    }
}
