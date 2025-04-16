using UnityEngine;

public interface ITriggerCheckable
{
    void AngryCustomerHit();
}

public interface IPowerUpGrab
{
    void PowerUpGrabbed(float speedIncrease);
}

public interface IComputerBroke
{
    void ComputerBroken();
}
