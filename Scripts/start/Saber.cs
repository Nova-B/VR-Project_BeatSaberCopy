using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    Vector3 prevPos;

    [SerializeField] Score score;
    [SerializeField] GameObject destructCube;
    [SerializeField] MusicData musicData;
    float musicLength;
    // Start is called before the first frame update
    void Start()
    {
        musicData = MusicData.Inst;
        musicLength = musicData.list[musicData.id].music.length;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        { 
            if(Vector3.Angle(transform.position - prevPos, hit.transform.up) > 130)
            {
                int randScore = Random.Range(20, 41);
                score.PlusScore(randScore);
                Instantiate(destructCube, hit.transform.position, hit.transform.rotation);
                Destroy(hit.transform.gameObject);
            }
        }
        prevPos = transform.position;
    }
}
