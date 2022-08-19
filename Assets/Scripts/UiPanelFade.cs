using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiPanelFade : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform _rectTransform;

    [SerializeField] private GameObject _popup;
    [SerializeField] private GameObject _enterSettingPanel;

    public void PanelFadeIn()
    {
        _canvasGroup.alpha = 0f;
        _rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        _rectTransform.DOAnchorPos(new Vector2(0f, 0f), _fadeTime, false).SetEase(Ease.OutElastic);
        _canvasGroup.DOFade(1, _fadeTime);

        _enterSettingPanel.SetActive(false);
    }

    public void PanelFadeOut()
    {
        _canvasGroup.alpha = 1f;
        _rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        _rectTransform.DOAnchorPos(new Vector2(0f, -1000f), _fadeTime, false).SetEase(Ease.InOutQuint);
        _canvasGroup.DOFade(0f, _fadeTime);

        Invoke("EnterSettingsPanelActive", 1f) ;
    }

    private void EnterSettingsPanelActive()
    {
        _enterSettingPanel.SetActive(true);
    }
}
