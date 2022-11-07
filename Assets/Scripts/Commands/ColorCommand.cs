using UnityEngine;

public class ColorCommand : Command
{
    private GameObject cubePrefab;
    public override void Do(Cube cube)
    {
        if (cubePrefab == null)
        {
            Color actualColor = cube.GetComponent<MeshRenderer>().material.color;
            if (actualColor == Color.green)
            {
                actualColor = Color.magenta;
            }
            else if (actualColor == Color.black)
            {
                actualColor = Color.green;
            }
            else if (actualColor == Color.white)
            {
                actualColor = Color.black;
            }

            cube.GetComponent<MeshRenderer>().material.color = actualColor;
        }
        else
        {
            cubePrefab.GetComponent<MeshRenderer>().material.color = cube.GetComponent<MeshRenderer>().material.color;
        }
    }

    public override void Undo(Cube cube)
    {
        Color actualColor = cube.GetComponent<MeshRenderer>().material.color;
        if (actualColor == Color.magenta)
        {
            actualColor = Color.green;
        }
        else if (actualColor == Color.green)
        {
            actualColor = Color.black;
        }
        else if (actualColor == Color.black)
        {
            actualColor = Color.white;
        }

        cube.GetComponent<MeshRenderer>().material.color = actualColor;
    }

    public ColorCommand(GameObject CubePrefab)
    {
        cubePrefab = CubePrefab;
    }
}