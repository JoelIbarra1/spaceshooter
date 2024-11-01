using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class escena : MonoBehaviour
{
    public movement movement;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void escenas ()
    {
        SceneManager.LoadScene("Sample Scene");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene" && Score1.Instance != null)
        {
            // Resetea la puntuación al cargar la escena de juego
            Score1.Instance.ResetScore();
        }
    }
}
