using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    private GameObject player;
    private Health playerH;
    public ParticleSystem particle;
    

    private float maxTorque = 10;
    private float xRange = -13.5f;
    private float ySpawnPosmax = 25;
    private float ySpawnPosmin = 15;
    private float zSpawnPos = -9;

    public int pointValue;
    private int damage = 1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerH = GameObject.Find("Game Manager").GetComponent<Health>();



        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        /*targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);*/

        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 10 * Time.deltaTime);

        if(transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(xRange, Random.Range(ySpawnPosmin,ySpawnPosmax), zSpawnPos);
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (!gameObject.CompareTag("bad") && player)
        {
            particle.Play();
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Fish Sound");
            gameManager.UpdateScore(pointValue);
        }
        else if (gameObject.CompareTag("bad") && player)
        {
            particle.Play();
            FindObjectOfType<AudioManager>().Play("Rock Sound");
            Destroy(gameObject);
            playerH.TakeDamage(damage);
            gameManager.GameOver();
        }

    }


}

