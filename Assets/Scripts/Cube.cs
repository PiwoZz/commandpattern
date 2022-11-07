using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Cube : MonoBehaviour {
    public int speed;
    public Text numberText;

    [NonSerialized] public bool InteractWithBanana;
    [NonSerialized] public GameObject BananaObject;
    [NonSerialized] public bool HasSendBullet;

    [SerializeField] private float force;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject cubePrefab;
    
    private List<Command> _commands = new List<Command>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (gameObject.transform.position.z >= 14f) return;
            _commands.Add(new ForwardCommand());
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (gameObject.transform.position.z <= -14f) return;
            _commands.Add(new BackwardCommand());
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (gameObject.transform.position.x >= 14f) return;
                _commands.Add(new RightCommand());
                _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (gameObject.transform.position.x <= -14f) return;
                _commands.Add(new LeftCommand());
                _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (gameObject.GetComponent<MeshRenderer>().material.color == Color.magenta) return;
            _commands.Add(new ColorCommand(null));
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _commands.Add(new PutBlocksCommand(cubePrefab));
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _commands.Add(new InteractCommand());
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            _commands.Add(new NumberCommand());
            _commands[^1].Do(this);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !HasSendBullet) {
            _commands.Add(new ShootCommand(bullet, force));
            _commands[^1].Do(this);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _commands.Count != 0) {
            Debug.Log("Undo " + _commands[^1]);
            _commands[^1].Undo(this);
            _commands.RemoveAt(_commands.Count - 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Banana"))
        {
            InteractWithBanana = true;
            BananaObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Banana"))
        {
            InteractWithBanana = false;
            BananaObject = null;
        }
    }
}