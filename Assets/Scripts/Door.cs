using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private float _maxLarmVolume = 1;
    private float _minLarmVolume = 0;

    public event UnityAction<float> IsOpen;
    public event UnityAction<float> DoorClose;

    public bool IsDoorOpen { get; private set; }
    public bool IsDooClose { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsOpen.Invoke(_maxLarmVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            DoorClose.Invoke(_minLarmVolume);
        }
    }
}