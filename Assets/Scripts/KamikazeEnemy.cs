
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform playerTransform;
    [SerializeField] private int damage;
    [SerializeField] public int life;
    private Rigidbody2D _compRigidBody2D;
    [SerializeField] public GameObject mysteryBoxPrefab;
    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            _compRigidBody2D.velocity = direction * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.Instance.Life = PlayerController.Instance.Life - damage;
            Destroy(this.gameObject);
        }
        else if (collision.tag == "EnemyEliminator")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Bullet")
        {
            BasicBullet bullet = collision.gameObject.GetComponent<BasicBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.3f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "PerforatorBullet")
        {
            PerforatorBullet bullet = collision.gameObject.GetComponent<PerforatorBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                if (life <= 0)
                {
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.3f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBullet")
        {
            TripleBullet bullet = collision.gameObject.GetComponent<TripleBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.3f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBulletPrefab")
        {
            TripleBulletPrefab bullet = collision.gameObject.GetComponent<TripleBulletPrefab>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.3f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
