using UnityEngine;
public class MysteryBox : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] powerUps; // Los prefabs de los power ups

    private Rigidbody2D _compRigidbody2D;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // La caja se mueve en el eje x negativo al instanciarse
        _compRigidbody2D.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cuando el jugador colisiona con la caja...
        if (collision.tag == "Player")
        {
            // Seleccionamos un power up al azar
            int randomIndex = Random.Range(0, powerUps.Length + 1);

            // Si el índice es igual a la longitud del arreglo, entonces el power up es el de aumentar vida
            if (randomIndex == powerUps.Length)
            {
                // Aumentamos la vida del jugador en un rango de 1 a 3 vidas
                AudioManagerController.Instance.PlaySfx(2);
                PlayerController.Instance.Life += Random.Range(1, 4);
            }
            else
            {
                AudioManagerController.Instance.PlaySfx(1);
                // Si no, asignamos el power up seleccionado al jugador
                GameObject powerUp = powerUps[randomIndex];
                PlayerController.Instance.currentPowerUp = powerUp;
            }

            // Destruimos la caja
            Destroy(this.gameObject);
        }
    }
}
