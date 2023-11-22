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
    [SerializeField] private AudioClip _spottedFX;
    [SerializeField] private AudioClip _spottedFromGoalDoorFX;
    [SerializeField] private AudioClip _waterPuddleFX;

    private float _maleHurtVolumeScale = 0.75f;

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
        EventsManager.instance.OnStudentLifeDamage += OnStudentLifeDamage;
        EventsManager.instance.OnCharacterSpotted += OnStudentSpotted;
        EventsManager.instance.OnStudentSpottedFromGoalDoor += OnStudentSpottedFromGoalDoor;
        EventsManager.instance.OnStudentWaterPuddleEntered += OnStudentWaterPuddleEntered;
    }

    #endregion

    #region EVENTS

    private void OnStudentLifeDamage(int currentLife, int maxLife)
    {
        _audioSource.PlayOneShot(_maleHurtFX, _maleHurtVolumeScale);
    }

    private void OnStudentSpotted()
    {
        _audioSource.PlayOneShot(_spottedFX);
    }

    private void OnStudentSpottedFromGoalDoor()
    {
        _audioSource.PlayOneShot(_spottedFromGoalDoorFX);
    }

    private void OnStudentWaterPuddleEntered()
    {
        _audioSource.PlayOneShot(_waterPuddleFX);
    }

    #endregion
}