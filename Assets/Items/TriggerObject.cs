using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerObject : MonoBehaviour
{
    [SerializeField] UnityEvent triggerEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            triggerEvent.Invoke();
        }
    }
}
