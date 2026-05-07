using UnityEngine;
using UnityEngine.InputSystem;

public class GiroscopioController : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    public int life;
    [SerializeField]
    private GameObject[] heart;
    [SerializeField]
    private float tiempoSpawn;
    private float timePass;
    [SerializeField]
    private float minimX, minimZ, maxX, maxZ;
    [SerializeField]
    private GameObject[] enemigos;
    [SerializeField]
    public GameObject gameOverPannel;
    [SerializeField]
    private AudioClip shoot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (SystemInfo.supportsGyroscope == true) 
        {
            Quaternion inputGyro = Input.gyro.attitude;

            //cam.rotation = new Quaternion(inputGyro.x, inputGyro.y, - inputGyro.z, -inputGyro.w);

            Quaternion correcionGiro = Quaternion.Euler (90, 0, 0);
            cam.rotation = correcionGiro * new Quaternion(inputGyro.x, inputGyro.y, -inputGyro.z, -inputGyro.w);
        }
    }
    private void Update()
    {
        timePass += Time.deltaTime;
        if (timePass >= tiempoSpawn)
        {
            timePass = 0;
            float x = Random.Range(minimX, maxX);
            float z = Random.Range(minimZ, maxZ);

            int enemigoZ = Random.Range (0, enemigos.Length);
            GameObject enemigo = Instantiate(enemigos[enemigoZ], new Vector3 (x, 0, z), Quaternion.identity);
            enemigo.GetComponent<EnemyController>().player = cam;

            EnemyController enemyScript = enemigo.GetComponent<EnemyController>();
            enemyScript.vidaPlayer = GetComponent<GiroscopioController>();     
        }
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;

        AudioManager.instance.PlaySFX(shoot, transform.position);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {               
                Destroy(hit.transform.gameObject);
            }
        }
    }
    public void TouchScreen(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Shoot();
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        heart[life].SetActive(false);

        if (life <= 0)
        {
            gameOverPannel.SetActive(true);
        }
    }
}
