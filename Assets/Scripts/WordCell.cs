using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordAlgorithm
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WordCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text letterText;
        [SerializeField] private float timeToOpen = 0.5f;
        
        private CanvasGroup  _canvasGroup;
        private bool _isOpened;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Init(string letter)
        {
            CheckIfEmpty(letter);
        }

        private void CheckIfEmpty(string letter)
        {
            var trimmedLetter = letter.Trim();
            
            if (trimmedLetter.IsEmpty())
            {
                _canvasGroup.DOFade(0f, 0f);
            }
            else
            {
                letterText.text = letter;
                letterText.DOFade(0f, 0f);
            }
        }

        private void OpenLetter()
        {
            if(_isOpened) return;
            letterText.DOFade(1f, timeToOpen);
            _isOpened = true;
        }
    }
}
