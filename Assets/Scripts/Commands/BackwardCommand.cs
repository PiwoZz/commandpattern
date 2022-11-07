using UnityEngine;

public class BackwardCommand : Command
{
    public override void Do(Cube cube) {
        cube.transform.Translate(-Vector3.forward * cube.speed);
    }

    public override void Undo(Cube cube) {
        cube.transform.Translate(Vector3.forward * cube.speed);
    }
}