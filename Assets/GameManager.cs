using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; // Arrastra el GameOverText desde el Inspector

    void Start()
    {
        // Asegúrate de que el texto de Game Over esté oculto al inicio
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