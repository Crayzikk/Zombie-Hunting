using UnityEngine;

public class Direction
{
    public static Vector3 GetDirection(LookAtMouse lookAtMouse, Transform transform, Vector3 mousePos)
    {
        if (lookAtMouse.isLookingUp)
        {
            return Vector3.up;
        }
        else if (lookAtMouse.isLookingDown)
        {
            return Vector3.down;
        }
        else
        {
            return mousePos - transform.position;
        }
    }
}
