using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    public GameObject road;
    private int sliceNumber = 7;
    private int longeur = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sliceNumber; i++){
            GameObject o = Instantiate(road, road.transform.position, road.transform.rotation);
            o.transform.Translate(new Vector3(0, 0, longeur * i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
