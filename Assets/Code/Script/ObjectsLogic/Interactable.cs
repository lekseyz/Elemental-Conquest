using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void applyFireBall();

    public abstract void applyWind(Vector2 dir);

    public abstract void applyStone();
}
