using UnityEngine;

[System.Serializable]
public class Cooldown{
    [SerializeField] private float cooldownTime = 1f;
    private float  nextTime;

    public bool isCoolingDown => Time.time < nextTime;
    public void startCoolingDown() => nextTime = Time.time + cooldownTime;
}
