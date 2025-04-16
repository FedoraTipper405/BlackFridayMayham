using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPowerUpGrab
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _taserCoolDown;
    [SerializeField] private Transform _firePoint;
    private Rigidbody2D rb;
    protected Vector3 currentInput;
    protected Vector2 currentMouse;
    private float _taserCoolDownTimer;

    public TaserBar taserBar;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        taserBar.SetMaxTaserAmount(_taserCoolDown);
    }   

    protected void LookAt(Vector2 mousePosition)
    {
        transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);
    }

    protected void Shoot()
    {
        if (_taserCoolDownTimer < _taserCoolDown) return;
        {
            GameObject bullet = ObjectPooling.instance.GetBulletPrefab();
            if (bullet != null)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShootBullet(_firePoint);
            }
            _taserCoolDownTimer = 0;
        }
    }

    private void FixedUpdate()
    {
        _taserCoolDownTimer += Time.deltaTime;
        rb.linearVelocity = _movementSpeed * currentInput * Time.fixedDeltaTime;
        taserBar.SetTaserAmount(_taserCoolDownTimer);
    }

    public void PowerUpGrabbed(float speedIncrease)
    {
        StartCoroutine(SpeedPowerUpTimer(speedIncrease));
    }

    IEnumerator SpeedPowerUpTimer(float speed)
    {
        _movementSpeed = speed;
        yield return new WaitForSeconds(4);
        _movementSpeed = 400f;
    }
}
