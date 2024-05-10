using UnityEngine;

public class InfiniteScrollSimple : MonoBehaviour
{
    public GameObject otherBackground; // Referencia al otro objeto de juego
    public float speed = 2f; // Velocidad de desplazamiento
    public float resetPosition = -10f; // Posición en x donde se resetea el objeto
    public float offset = 20f; // Distancia entre los dos objetos

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mueve el objeto en la dirección negativa de x
        rb.velocity = new Vector2(-speed, 0);

        // Si el objeto alcanza la posición de reseteo
        if (transform.position.x <= resetPosition)
        {
            // Teletransporta el objeto detrás del otro objeto
            Vector3 newPos = new Vector3(otherBackground.transform.position.x + offset, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
