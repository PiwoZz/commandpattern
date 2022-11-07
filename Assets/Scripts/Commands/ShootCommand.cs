using System.Threading;
using UnityEngine;

public class ShootCommand : Command {
    private GameObject _bullet;
    private float _speed;
    
    public override void Do(Cube cube) {
        _bullet.GetComponent<BulletScript>().IsSended = true;
        _bullet.transform.position = cube.transform.position;
        _bullet.SetActive(true);
        if (Camera.main is not null) {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.y = 0;
            Debug.DrawLine(cube.transform.position, ray);
            _bullet.transform.LookAt(ray);
            var euler = _bullet.transform.rotation.eulerAngles; 
            euler.x = 0; 
            euler.z = 0; 
            _bullet.transform.rotation = Quaternion.Euler(euler);
            _bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * _speed);
            cube.HasSendBullet = true;
        }
    }

    public override void Undo(Cube cube) {
        _bullet.GetComponent<BulletScript>().IsSended = false;
        _bullet.SetActive(true);
        if (Camera.main is not null) {
            _bullet.transform.LookAt(cube.transform.position);
            var euler = _bullet.transform.rotation.eulerAngles; 
            euler.x = 0; 
            euler.z = 0; 
            _bullet.transform.rotation = Quaternion.Euler(euler);
            _bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * _speed);
            cube.HasSendBullet = false;
        }
    }

    public ShootCommand(GameObject bullet, float speed) {
        _bullet = bullet;
        _speed = speed;
    }
}