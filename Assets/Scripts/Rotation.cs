using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Rigidbody targetrb;
    private float maxTorque = 5;
    // Start is called before the first frame update
    void Start()
    {
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddTorque(RandomTorque(), 0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
