using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{

    public delegate void EndGame();
    public static event EndGame endGame;

    void PlayerDiedEndGame() {
        if (endGame != null) {
            endGame();
        }
        SceneManager.LoadScene("EndlessRunner");
        Destroy (gameObject);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Collector") {
            PlayerDiedEndGame();
        }
    }

 



}
