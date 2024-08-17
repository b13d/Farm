using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    List<GameObject> _interactiveObjects = new List<GameObject>();
    InteractiveObject _targetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactive")
        {
            _interactiveObjects.Add(collision.gameObject);

            if (_interactiveObjects.Count == 1)
            {
                _targetObject = collision.GetComponent<InteractiveObject>();

                _targetObject.outline.SetActive(true);

                Debug.Log("Объект рядом");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactive")
        {
            if (_interactiveObjects.Contains(collision.gameObject))
            {
                _interactiveObjects.Remove(collision.gameObject);

                collision.GetComponent<InteractiveObject>().outline.SetActive(false);

                Debug.Log("Объект потерял фокус");

                if (_interactiveObjects.Count > 0)
                {
                    _interactiveObjects[0].GetComponent<InteractiveObject>().outline.SetActive(true);
                }
            }
        }
    }


    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _targetObject.animator.SetTrigger("Interactive");
    //    }
    //}
}
