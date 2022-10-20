using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;

    GameObject[] sampleCube = new GameObject[512];
    public float maxScale;

    float rotSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <512; i++)
        {
            GameObject instSampleCube = (GameObject)Instantiate(sampleCubePrefab);
            instSampleCube.transform.position = this.transform.position;
            instSampleCube.transform.parent = this.transform;
            instSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -(360 / 512f) * i, 0);
            instSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = instSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, transform.localRotation.z));

        for (int i = 0; i < 512; i++)
        {
            if(sampleCube != null)
            {
                if (i >= 216)
                { 
                    sampleCube[i].transform.localScale = new Vector3(1, (AudioPeer.samples[i] * maxScale) + 2, 1);
                }
                else
                {
                    sampleCube[i].transform.localScale = new Vector3(1, (AudioPeer.samples[i + 216] * maxScale) + 2, 1);
                }
            }
        }
    }
}
