using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [Header("StartMenu")]
    [SerializeField] GameObject startMenu;

    [Header("SelectMenu")]
    [SerializeField] MusicData musicData;
    [SerializeField] Image musicImage;
    [SerializeField] GameObject selectMenu;
    int musicId = 0;
    private void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 90);
        startMenu.SetActive(true);
        selectMenu.SetActive(false);
    }
    public void PushStartBtn()
    {
        startMenu.SetActive(false);
        selectMenu.SetActive(true);
        musicImage.sprite = musicData.list[musicId].musicImg;
        selectMenu.GetComponent<SelectMenu>().PlaySampleAudio(musicData.list[musicId].music);
    }

    #region SelectMenu
    public void NextMusic()
    {
        if (musicId >= musicData.list.Count - 1) return;
        musicId++;
        musicImage.sprite = musicData.list[musicId].musicImg;
        selectMenu.GetComponent<SelectMenu>().PlaySampleAudio(musicData.list[musicId].music);
    }

    public void PrevMusic()
    {
        if (musicId <= 0) return;
        musicId--;
        musicImage.sprite = musicData.list[musicId].musicImg;
        selectMenu.GetComponent<SelectMenu>().PlaySampleAudio(musicData.list[musicId].music);

    }

    public void PushPlayBtn(int id)
    {
        musicData.id = musicId;
        SceneManager.LoadScene(id);
    }
    #endregion
}
