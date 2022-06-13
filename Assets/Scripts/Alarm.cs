using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AudioSource _audioSource;

    private float _volumeStep = 0.5f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.IsOpen += ActiveAlarm;
        _door.DoorClose += DisableAlarm;
    }

    private void OnDisable()
    {
        _door.IsOpen -= ActiveAlarm;
        _door.DoorClose -= DisableAlarm;
    }

    private void ActiveAlarm(float volue)
    {
        _audioSource.enabled = true;
        StartCoroutine(ChangeVolume(volue));
    }

    private void DisableAlarm(float volue)
    {
        StartCoroutine(ChangeVolume(volue));
        if (_audioSource.volume == volue)
        {
            _audioSource.enabled = false;
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeStep * Time.deltaTime);
            yield return null;
        }
    }
}
