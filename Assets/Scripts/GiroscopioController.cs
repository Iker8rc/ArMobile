using UnityEngine;

public class GiroscopioController : MonoBehaviour
{
    [SerializeField] 
    private Transform cam;

    public int life;
    private float timePass;
    [SerializeField]
    private float minimX, minimZ, maxX, maxZ;

    [Header("Enemy")]
    [SerializeField]
    private GameObject[] krillin;
    [SerializeField]
    private float spawnTime;

    [Header("UI")]
    [SerializeField]
    public GameObject panelGameOver;
    [SerializeField]
    private GameObject[] vidas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (SystemInfo.supportsGyroscope == true) // nos devuelve la rot del dispositivo
        {
            Quaternion inputGyro = Input.gyro.attitude;
            Quaternion correcionGiro = Quaternion.Euler(90, 0, 0);
            cam.rotation = correcionGiro * new Quaternion(inputGyro.x, inputGyro.y, -inputGyro.z, -inputGyro.w);
        }
    }
    private void Update()
    {
        timePass += Time.deltaTime;
        if (timePass >= spawnTime)
        {
            timePass = 0;
            float x = Random.Range(minimX, maxX);
            float z = Random.Range(minimZ, maxZ);

            int krillinv2 = Random.Range(0, krillin.Length);
            Instantiate(krillin[krillinv2], new Vector3(x, 0, z), Quaternion.identity);
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        vidas[life].SetActive(false);

        if (life <= 0)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void ShootRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
