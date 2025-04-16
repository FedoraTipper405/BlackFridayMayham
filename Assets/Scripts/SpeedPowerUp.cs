using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float _speedIncreaseAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPowerUpGrab powerUpGrab = collision.gameObject.GetComponent<IPowerUpGrab>();
        if (powerUpGrab != null)
        {
            powerUpGrab.PowerUpGrabbed(_speedIncreaseAmount);
            Destroy(gameObject);
        }
    }
}
