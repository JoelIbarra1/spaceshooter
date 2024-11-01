using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float lifetime = 5f; // Tiempo que el enemigo vivirá antes de ser destruido

    void Start()
    {
        // Destruye el enemigo después de un tiempo
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Busca el ScoreManager en la escena
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(100); // Aumenta el puntaje en 100
        }
        // Destruye el enemigo al colisionar con cualquier objeto
        Destroy(gameObject);

        // Opcionalmente, también puedes destruir el objeto con el que colisionó
        Destroy(collision.gameObject);
    }
}
