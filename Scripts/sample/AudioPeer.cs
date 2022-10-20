using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];

    public static float[] frequBand = new float[8];//주파수 진폭 대역대 8개
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        //blackman - reduce leakage of spectrum data
    }

    void MakeFrequencyBands()
    {
        /*
         *  22050(Hz) / 512(band) = 43 Hz per sample
         *  
         *  8 Bands
         *  가청주파수 내
         *  20 - 60 Hz
         *  60 - 250 Hz
         *  250 - 500 Hz
         *  500 - 2000 Hz
         *  2000 - 4000 Hz
         *  4000 - 6000 Hz
         *  6000 - 20000 Hz
         *  
         *  0 - 2 = 43 * 2 = 86Hz(0~86)
         *  1 - 4 = 172 Hz(86~258)
         *  2 - 8 = 344 Hz(259~602)
         *  3 - 16 = 688Hz(603-1290)
         *  4 - 32 = 1376Hz(1291-2666)
         *  5 - 64 = 2752Hz(2667-5418)
         *  6 - 128 = 5504Hz(5419-10922)
         *  7 - 256 = 11008Hz(10923-21930)
         */

        int count = 0;
        for(int i = 0; i < 8; i++)
        {
            float avg = 0;
            int sampleCount = (int)Mathf.Pow(2, i + 1);

            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {
                avg += samples[count] * (count + 1);
                count++;
            }

            avg /= count;

            frequBand[i] = avg * 10;
        }
    }
}
