using UnityEngine;
using System.Collections.Generic;

public class MonoCache : MonoBehaviour
{
    public static List<MonoCache> allUpdate = new List<MonoCache>();

    private void OnEnable() => allUpdate.Add(this);
    private void OnDisable() => allUpdate.Remove(this);

    public void Tick() => OnTick();
    public virtual void OnTick() { }
}
