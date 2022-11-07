using System.Collections.Generic;
using UnityEngine;

public class NumberCommand : Command
{
    private static List<string> _numberList = new List<string>();
    public override void Do(Cube cube)
    {
        if (cube.numberText != null)
        {
            if (_numberList.Count == 0)
            {
                _numberList.Add("");
            }
            else
            {
                _numberList.Add(cube.numberText.text);
            }
            cube.numberText.text = Random.Range(1,29).ToString();
        }
    }

    public override void Undo(Cube cube)
    {
        if (_numberList[0] != null)
        {
            cube.numberText.text = _numberList[^1];
            _numberList.RemoveAt(_numberList.Count - 1);
        }
    }
}