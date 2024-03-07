using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    public GameObject coin;
    public GameObject box;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("create", 4f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void create(){
        float x = Random.Range(0, 2);
        float position = Random.Range(-4, 5);
        if(x == 0){
            Instantiate(box, new Vector3(position, 0 , car.transform.position.z)
             + new Vector3(0, 0, 30), box.transform.rotation);
            return;
        }
        float y = Random.Range(3, 6);
        for(int i = 0; i < y; i++){
            Instantiate(coin, new Vector3(position, 0.3f, car.transform.position.z) + new Vector3(0, 0, 30 + i * 1.5f), coin.transform.rotation);
        }

    }
}
