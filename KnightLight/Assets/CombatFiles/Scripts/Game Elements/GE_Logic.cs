﻿using UnityEngine;
using System.Collections;

public abstract class GE_Logic : ScriptableObject
{
    public abstract void OnClick(CardInstance inst);

    public abstract void OnHighlight(CardInstance inst);
}
