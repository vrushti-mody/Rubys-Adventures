using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{

    public delegate void EndGame();
    public static event EndGame endGame;

    void PlayerDiedEndGame() {
        if (endGame != null) {
            endGame();
        }
        Time.timeScale = 0;
        Destroy (gameObject);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Collector") {
            PlayerDiedEndGame();
        }
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Bot") {
            PlayerDiedEndGame();
        }
    }



}
