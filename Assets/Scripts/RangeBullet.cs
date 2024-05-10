using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBullet : MonoBehaviour
{
    public float waitTime = 2f; // Tiempo que el proyectil permanecerá quieto
    public float scaleIncrease = 2f; // Cantidad que se escalará el proyectil
    public int damage = 10; // Daño que se aplicará a los enemigos
    public float speed = 10f;
    public float damageInterval = 1f; // Intervalo de tiempo entre cada aplicación de daño
    private Rigidbody2D _compRigidbody2D;
    private bool isStationary = false; // Bandera para controlar si el proyectil está quieto
    private float lastDamageTime; // Última vez que se aplicó daño

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isStationary)
        {
            _compRigidbody2D.velocity = new Vector2(speed, 0);
        }
        else
        {
            _compRigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BasicEnemy")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        else if (other.tag == "KamikazeEnemy")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        if (other.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isStationary && Time.time >= lastDamageTime + damageInterval)
        {
            if (other.tag == "BasicEnemy")
            {
                // Aplica daño al enemigo
                BasicEnemy enemy = other.gameObject.GetComponent<BasicEnemy>();
                if (enemy != null)
                {
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        // Hay un 20% de probabilidad de soltar una caja misteriosa
                        if (Random.value < 0.3f)
                        {
                            Instantiate(enemy.mysteryBoxPrefab, transform.position, Quaternion.identity);
                        }
                        AudioManagerController.Instance.PlaySfx(4);
                        UIManagerController.Instance.EnemyEliminated();
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;
            }
            else if (other.tag == "KamikazeEnemy")
            {
                // Aplica daño al enemigo
                KamikazeEnemy enemy = other.gameObject.GetComponent<KamikazeEnemy>();
                if (enemy != null)
                {
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        // Hay un 20% de probabilidad de soltar una caja misteriosa
                        if (Random.value < 0.3f)
                        {
                            Instantiate(enemy.mysteryBoxPrefab, transform.position, Quaternion.identity);
                        }
                        AudioManagerController.Instance.PlaySfx(4);
                        UIManagerController.Instance.EnemyEliminated();
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;
            }
        }
    }

    private IEnumerator StayAndScale()
    {
        isStationary = true;

        // Guarda la posición original del proyectil
        Vector3 originalPosition = transform.position;

        // Escala el proyectil
        transform.localScale *= scaleIncrease;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(waitTime);

        // Destruye el proyectil
        Destroy(this.gameObject);
    }
}
