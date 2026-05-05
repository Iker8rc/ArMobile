using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    [SerializeField]
    private float speed;
    [SerializeField]
    private float destroyDistance;
    public GiroscopioBUENO vidaPlayer;
    [SerializeField]
    private AudioClip sfxDamage;

    void Update()
    {
        transform.LookAt(player);
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < destroyDistance)
        {
            vidaPlayer.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
