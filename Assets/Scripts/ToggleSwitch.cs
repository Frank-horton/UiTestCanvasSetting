using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleSwitch : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private bool _isOn = false;
    public bool isOn
    {
        get
        {
            return _isOn;
        }
    }

    [SerializeField] private RectTransform ToggleIndicator;
    [SerializeField] private Image BackgroundImage;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;
    private float offX;
    private float onX;
    [SerializeField] private float TweenTime = 0.25f;

    private AudioSource audioSource;
    public delegate void ValueChanged(bool value);
    public event ValueChanged valueChanged;

    [SerializeField] private GameObject GreenToggle;
    [SerializeField] private GameObject RedToggle;

    void Start()
    {
        offX = ToggleIndicator.anchoredPosition.x;
        onX = BackgroundImage.rectTransform.rect.width - ToggleIndicator.rect.width;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Toggle(isOn);
    }

    private void Toggle(bool value, bool playSFX = true)
    {
        if(value != isOn)
        {
            _isOn = value;
           // ToggleColor(isOn);
            MoveIndicator(isOn);

            if (playSFX)
                audioSource.Play();

            if (valueChanged != null)
                valueChanged(isOn);
        }
    }

   // private void ToggleColor(bool value)
   //  {
   //    if(value)
   //  {
   //     BackgroundImage.DOColor(onColor, TweenTime);
   //  }
   // else
   //  {
   //     BackgroundImage.DOColor(offColor,TweenTime);
   //  }
   //  }

    private void MoveIndicator(bool value)
    {
        if (value)
        {
            ToggleIndicator.DOAnchorPosX(onX, TweenTime);
            GreenToggle.SetActive(true);
            RedToggle.SetActive(false);
        }
        else
        {
            ToggleIndicator.DOAnchorPosX(offX, TweenTime);
            GreenToggle.SetActive(false);
            RedToggle.SetActive(true);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Toggle(!isOn);
    }
}
