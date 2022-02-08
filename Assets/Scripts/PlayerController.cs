using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private GameManager gameManager;
    private GameObject player;
    public ParticleSystem fishEat;
    public ParticleSystem rockHit;
    private Health playerH;
    public float speed = 10.0f;

    private void Awake()
    {
        fishEat.Stop();
        rockHit.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerH = GameObject.Find("Player").GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerInput = Input.GetAxis("Vertical");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        transform.Translate(Vector3.up * speed * playerInput * Time.deltaTime);

        if(transform.position.y > 26 )
        {
            transform.position = new Vector3(transform.position.x, 26, transform.position.z);
        }
        else if (transform.position.y < 14)
        {
            transform.position = new Vector3(transform.position.x, 14, transform.position.z);
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("bad"))
        {
            fishEat.Play();

        }
        else if (gameObject.CompareTag("bad"))
        {
            rockHit.Play();

        }
    }


}
