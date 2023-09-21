using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _defeat;
    [SerializeField] private AudioClip _characterSpotted;
    
    [SerializeField] private AudioSource _audioSource;
    
    #region UNITY_EVENTS

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnCharacterSpotted += OnCharacterSpotted;
    }

    #endregion

    #region EVENTS

    private void OnGameOver(bool isVictory)
    {
        _audioSource.PlayOneShot(isVictory ? _victory : _defeat);
        
    }
    
    private void OnCharacterSpotted()
    {
        _audioSource.PlayOneShot(_characterSpotted);
    }

    #endregion
}
