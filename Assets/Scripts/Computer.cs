using UnityEngine;

public class Computer : MonoBehaviour, IComputerBroke
{
    [SerializeField] private Sprite newSprite;

    [SerializeField] private float _reducePayCheckAmount;
    public void ComputerBroken()
    {
        GameManager.Instance.ReducePaycheck(_reducePayCheckAmount);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
    }
}
