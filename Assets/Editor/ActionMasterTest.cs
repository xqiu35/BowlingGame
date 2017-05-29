using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action enTurn = ActionMaster.Action.EndTurn;
    private ActionMaster actionMaster = new ActionMaster();

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEnturn()
    {
        Assert.AreEqual(enTurn, actionMaster.Bowl(10));
    }
}