using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData : MonoBehaviour
{
    public static MusicData Inst { get; private set; }

    public List<MusicInfo> list = new List<MusicInfo>();
    public int id;

    private void Awake()
    {
        Inst = this;
        DontDestroyOnLoad(gameObject);
    }
}
