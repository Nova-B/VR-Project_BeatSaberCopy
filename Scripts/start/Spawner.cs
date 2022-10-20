using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = 1;
    float timer;
    [SerializeField] MusicData musicData;
    float musicLength;

    float playTime;
    // Start is called before the first frame update
    void Start()
    {
        playTime = 0;
        musicData = MusicData.Inst;
        musicLength = musicData.list[musicData.id].music.length;
    }

    // Update is called once per frame
    void Update()
    {
        if(playTime < musicLength - 8f)
        {
            if(timer > beat)
            {
                GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);

                cube.transform.localPosition = Vector3.zero;

                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

                timer -= beat;
            }
            timer += Time.deltaTime;
            playTime += Time.deltaTime;
        }
    }
}
