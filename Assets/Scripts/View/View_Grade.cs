using MrJi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class View_Grade : IDisposable
{

    Dictionary<int, int> Grade = new Dictionary<int, int>();

    [Preserve]
    public View_Grade()
    {
        MrJi_Event.ResetUIGrade += ResetUIGrade;
        MrJi_Event.Action_ReviseGrade += ReviseGrade;
    }

    void ResetUIGrade(int CheckId)
    {
        Grade[CheckId] = 0;

        MrJi_Event.Action_UIShowGrade?.Invoke(Grade[CheckId].ToString());
    }

    void ReviseGrade(int CheckId, int grade)
    {
        Grade[CheckId] += grade;

        MrJi_Event.Action_UIShowGrade?.Invoke(Grade[CheckId].ToString());
    }

    public void Dispose()
    {
        
    }
}
