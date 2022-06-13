using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AudioSource _audioSource;

    private float _volumeStep = 0.5f;
    private bool _runCoroutine = false;
    private float _maxAlarmVolume = 1;
    private float _minAlarmVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.DoorOpened += ActiveAlarm;
        _door.DoorClosed += DisableAlarm;
    }

    private void OnDisable()
    {
        _door.DoorOpened -= ActiveAlarm;
        _door.DoorClosed -= DisableAlarm;
    }

    private void ActiveAlarm()
    {
        _audioSource.Play();

        if (_runCoroutine == false)
        {
            StartCoroutine(ChangeVolume(_maxAlarmVolume));
        }
    }

    private void DisableAlarm()
    {
        if (_runCoroutine == false)
        {
            StartCoroutine(ChangeVolume(_minAlarmVolume));
        }  

        if (_audioSource.volume == _minAlarmVolume)
        {
            _audioSource.Stop();
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        _runCoroutine = true;

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeStep * Time.deltaTime);
            yield return null;
        }

        _runCoroutine = false;
    }
}
