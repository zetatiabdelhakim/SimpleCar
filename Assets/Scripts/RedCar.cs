using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCar : MonoBehaviour
{
    private float speed = 0.05f;
    public Car car;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("speed_", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
        
    }
    void speed_(){speed = car.getSpeed() + Random.Range(-0.07f, 0.07f);}
}
