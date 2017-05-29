using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action {Tidy, EndTurn, Reset, EndGame};

	public Action Bowl(int pins)
    {
        if(pins < 0 || pins > 0)
        {
            throw new UnityException("Not sure what action to return");
        }

        if(pins==10)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");

    }
}
