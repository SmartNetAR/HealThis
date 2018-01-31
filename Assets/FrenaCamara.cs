using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrenaCamara : MonoBehaviour {

    public Image EndgameFadeImage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TERMINA EL JUEGO");
            GameController.instance.speedBackground = 0;
            GameController.instance.EndGame();
        }
    }
}
