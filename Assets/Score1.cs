using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public static Score1 Instance; // Singleton para acceder a la puntuaci�n desde otros scripts
    public int score = 0; // Puntuaci�n actual
    public Text scoreText; // Referencia al texto de UI que mostrar� la puntuaci�n

    private void Awake()
    {
        // Verifica si ya existe una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el ScoreManager al cambiar de escena

        }
        else
        {
            Destroy(gameObject); // Destruir el objeto si ya existe una instancia
        }
    }

    private void Start()
    {
        // Solo se inicializa el scoreText si estamos en la escena de juego
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            FindScoreText(); // Busca ScoreText solo en la escena de juego
            UpdateScoreUI();
        }
    }

    private void FindScoreText()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();
        Debug.Log(scoreText != null ? "ScoreText encontrado" : "ScoreText no se encontr�"); //Opcional por depuraci�n
    }

    public void AddScore(int points)
    {
        score += points; // Sumar puntos
        UpdateScoreUI(); // Actualizar la interfaz de usuario

    }

    public void UpdateScoreUI()
    {
        // Obt�n nuevamente el objeto de texto de la UI si es nulo
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score; // Actualiza el texto de puntuaci�n
        }
    }


    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
}
