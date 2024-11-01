using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; // Arrastra el GameOverText desde el Inspector

    void Start()
    {
        // Aseg�rate de que el texto de Game Over est� oculto al inicio
        gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        // Activa el texto de Game Over
        gameOverText.SetActive(true);

        // Pausa el juego
        Time.timeScale = 0;
    }
}