using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distDamage;
    public GiroscopioBUENO vidaPlayer;

    [SerializeField]
    private AudioClip damage;

    void Update()
    {
        transform.LookAt(player);
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < distDamage)
        {
            vidaPlayer.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
