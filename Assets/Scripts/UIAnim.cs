using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnim : MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _scaleTo;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();

        _originalScale = transform.localScale;
        _scaleTo = _originalScale * 2;
       
        OnScale();   
    }

    private void OnScale()
    {
        transform.DOScale(_scaleTo, 2f)
          .SetEase(Ease.InOutSine)
          .SetLoops(-1, LoopType.Yoyo);
    }

    public void PlayAudio(bool value)
    {
        if(value)
        {
            _audioSource.Play();
        }     
    }
}