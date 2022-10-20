using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI scoreNum;
    public Transform scoreTran;

    public int score;

    private void Start()
    {
        score = 0;
        scoreNum.text = string.Format("{0:D4}", 0);
    }

    public void PlusScore(int n)
    {
        scoreNum.text = string.Format("{0:D4}", score + n);
        score += n;
        ScoreAnim(scoreTran);
    }

    void ScoreAnim(Transform text)
    {
        Sequence scoreSeq = DOTween.Sequence();
        scoreSeq.Append(text.DOScale(Vector3.one * 2f, 0.1f).SetEase(Ease.InBounce))
            .Append(text.DOScale(Vector3.one, 2f));
    }
}
