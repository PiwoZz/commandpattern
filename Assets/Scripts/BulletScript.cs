using System;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {
    [NonSerialized]public bool IsSended;
    
    private Transform _beforeImpact;
    
    private void OnTriggerEnter(Collider other) {
        if (IsSended && other.gameObject.CompareTag("Lever")) {
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _beforeImpact = transform;
        }

        if (!IsSended && other.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = _beforeImpact.position;
        }
    }
}