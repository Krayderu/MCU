using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPuzzle : MonoBehaviour
{
    private conditionsToAccessThePuzzle conditions;
    private actionsWhenPuzzleIsSolved actions;
    private AP_Generic thing;
    public GameObject iconPosition;
    //public bool b_PuzzleSolved = false;         // Know if the puzzle is solved

    private void Start()
    {
        conditions = GetComponent<conditionsToAccessThePuzzle>();
        actions = GetComponent<actionsWhenPuzzleIsSolved>();
        thing = GetComponent<AP_Generic>();
    }

    private void Update()
    {
        if (!ingameGlobalManager.instance.b_InputIsActivated) return;

        if (conditions.b_PuzzleIsActivated && !ingameGlobalManager.instance.b_Ingame_Pause && !thing.b_PuzzleSolved)
        {
            if (thing.b_PuzzleSolved || ingameGlobalManager.instance._P)
            {
                actions.F_PuzzleSolved();                   // Call script actionsWhenPuzzleIsSolved. Do actions when the puzzle is solved the first time.
                thing.b_PuzzleSolved = true;
            }
            else
                actions.b_actionsWhenPuzzleIsSolved = true; // Use when focus is called. The variable b_actionsWhenPuzzleIsSolved in script puzzleSolved equal True
        }

    }
    public bool Enter()
    {
        conditions.F_ActivateFocus(gameObject);
        Debug.Log("Test");
        return true;
    }

    public bool Solved()
    {
        
        Debug.Log("Solved !");
        return true;
    }
}
