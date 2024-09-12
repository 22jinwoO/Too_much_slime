using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitStateMachine : MonoBehaviour
{
    public PlayerUnitController controller { get; set; }

    private void Awake()
    {
        controller = GetComponent<PlayerUnitController>();
    }

    private void Update()
    {
        if (controller.UnitAct != null) controller.UnitAct.DoAction();
    }
}
