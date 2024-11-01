using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public float rotationSpeed = 200f;
    public float maxRotationAngle = 30f;
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePointLeft; // Punto de disparo izquierdo
    public Transform firePointRight; // Punto de disparo derecho
    public float projectileSpeed = 20f; // Velocidad del proyectil
    public float projectileLifetime = 5f;
    private Quaternion initialRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = rb.rotation;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * speed;
        rb.velocity = movement;

        if (horizontalInput != 0)
        {
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = rb.rotation * Quaternion.Euler(0, 0, -rotationAmount);
            float angle = Quaternion.Angle(initialRotation, targetRotation);
            if (angle <= maxRotationAngle)
            {
                rb.MoveRotation(targetRotation);
            }
        }
        else
        {
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, initialRotation, rotationSpeed * Time.deltaTime));
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instancia el proyectil en el firePointLeft
        GameObject projectileLeft = Instantiate(projectilePrefab, firePointLeft.position, firePointLeft.rotation);
        Rigidbody projectileRbLeft = projectileLeft.GetComponent<Rigidbody>();
        projectileRbLeft.velocity = firePointLeft.forward * projectileSpeed;
        Destroy(projectileLeft, projectileLifetime);

        // Instancia el proyectil en el firePointRight
        GameObject projectileRight = Instantiate(projectilePrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody projectileRbRight = projectileRight.GetComponent<Rigidbody>();
        projectileRbRight.velocity = firePointRight.forward * projectileSpeed;
        Destroy(projectileRight, projectileLifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Llama a GameOver en el GameManager
        FindObjectOfType<GameManager>().GameOver();

        // Destruye el personaje
    }
}
