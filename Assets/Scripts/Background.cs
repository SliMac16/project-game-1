using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float speed = 10;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x  / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
            if (transform.position.x > startPos.x + 60)
            {
                transform.position = startPos;
            }
        

        
    }
}
