using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public event UnityAction DoorOpened;
    public event UnityAction DoorClosed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            DoorOpened.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            DoorClosed.Invoke();
        }
    }
}