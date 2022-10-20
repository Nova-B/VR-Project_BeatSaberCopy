using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Quit_Canvas : MonoBehaviour
{
    [SerializeField] GameObject quit_Btn;
    [SerializeField] Transform quit_BtnTrs;
    [SerializeField] MusicData musicData;
    float musicLength;
    // Start is called before the first frame update
    void Start()
    {
        musicData = MusicData.Inst;
        musicLength = musicData.list[musicData.id].music.length;
        
        quit_Btn.SetActive(false);
        StartCoroutine(EnableQuitBtn());
    }

    IEnumerator EnableQuitBtn()
    {
        yield return new WaitForSeconds(musicLength + 3f);
        quit_Btn.SetActive(true);
        AnimQuitBtn();
    }

    void AnimQuitBtn()
    {
        Sequence quitBtnSeq = DOTween.Sequence();
        quitBtnSeq.Append(quit_BtnTrs.DOScale(Vector3.one * 0.1f, 0.1f).SetEase(Ease.InBounce))
            .Append(quit_BtnTrs.DOScale(Vector3.one * 0.05f, 2f));
    }

    public void PushQuitBtn(int num)
    {
        SceneManager.LoadScene(num);
    }
}
