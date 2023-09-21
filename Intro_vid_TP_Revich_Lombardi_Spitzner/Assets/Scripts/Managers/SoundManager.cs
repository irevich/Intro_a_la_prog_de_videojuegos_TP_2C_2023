using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //Game audioclips
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _schoolBellFX;
    [SerializeField] private AudioClip _maleHurtFX;
    private int _maleHurtVolumeScale = 15;

    [SerializeField] private AudioSource _audioSource;
    
    #region UNITY_EVENTS

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //First play the school bell FX
        _audioSource.PlayOneShot(_schoolBellFX);
        //Then, play the background music
        _audioSource.clip = _backgroundMusic;
        _audioSource.loop = true;
        _audioSource.Play();
        //Subscription to events
        print($"Event manager instance is null : {EventsManager.instance == null}");
        EventsManager.instance.OnStudentLifeDamage += OnStudentLifeDamage;
    }

    #endregion

    #region EVENTS

    private void OnStudentLifeDamage(int currentLife, int maxLife){
        _audioSource.PlayOneShot(_maleHurtFX,_maleHurtVolumeScale);
    }

    #endregion
}
