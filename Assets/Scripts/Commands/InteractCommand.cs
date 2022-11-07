using UnityEngine;

public class InteractCommand : Command
{
    private GameObject _currentBanana;
    private bool _killedABanana;
    public override void Do(Cube cube)
    {
        if (cube.InteractWithBanana && cube.BananaObject != null)
        {
            _currentBanana = cube.BananaObject;
            var bananaCommand = new PickUpCommand(_currentBanana);
            bananaCommand.Do(cube);
            cube.InteractWithBanana = false;
            _killedABanana = true;
        }
    }

    public override void Undo(Cube cube)
    {
        if (_killedABanana)
        {
            var bananaCommand = new PickUpCommand(_currentBanana);
            bananaCommand.Undo(cube);
        }
    }
}