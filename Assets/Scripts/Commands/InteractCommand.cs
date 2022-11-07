using UnityEngine;

public class InteractCommand : Command
{
    private PickUpCommand _banane;
    public override void Do(Cube cube)
    {
        if (cube.InteractWithBanana && cube.BananaObject != null)
        {
            _banane = new PickUpCommand(cube.BananaObject);
            _banane.Do(cube);
            cube.InteractWithBanana = false;
        }
    }

    public override void Undo(Cube cube)
    {
        if (_banane != null)
        {
            _banane.Undo(cube);
        }
    }
}