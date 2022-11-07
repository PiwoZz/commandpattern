using UnityEngine;

public class PutBlocksCommand : Command
{
    private GameObject _cubePrefab;
    private GameObject actualBlock;
    public override void Do(Cube cube)
    {
        actualBlock = GameObject.Instantiate(_cubePrefab);
        actualBlock.transform.position = cube.transform.position;
        var colorCommand = new ColorCommand(actualBlock);
        colorCommand.Do(cube);
    }

    public override void Undo(Cube cube)
    {
        GameObject.Destroy(actualBlock);
    }

    public PutBlocksCommand(GameObject cubePrefab)
    {
        _cubePrefab = cubePrefab;
    }
    
}