using UnityEngine;

public class PickUpCommand : Command
{
    private GameObject pickUpCurrentObject;
    public override void Do(Cube cube)
    {
        pickUpCurrentObject.SetActive(false);
        var position = pickUpCurrentObject.transform.position;
        position = new Vector3
        (
            position.x,
            -10,
            position.z
        );
        pickUpCurrentObject.transform.position = position;
    }

    public override void Undo(Cube cube)
    {
        pickUpCurrentObject.SetActive(true);
        var position = pickUpCurrentObject.transform.position;
        position = new Vector3
        (
            position.x,
            0.5f,
            position.z
        );
        pickUpCurrentObject.transform.position = position;
    }

    public PickUpCommand(GameObject PickUpCurrentObject)
    {
        pickUpCurrentObject = PickUpCurrentObject;
    }

   
}