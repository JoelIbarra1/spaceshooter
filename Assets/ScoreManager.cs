using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esto si usas UI

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Puntaje inicial
    public Text scoreText; // Referencia al objeto de texto UI

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // Aumenta el puntaje
        UpdateScoreText(); // Actualiza el texto en la UI
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Actualiza el texto de puntaje
    }
}

