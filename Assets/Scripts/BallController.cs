using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Trajcetory _trajcetory;
    private GameManager _gameManager;
    private float _shootingPower = 0f;
    private float _shootingAngle = 45f;

    private void Start()
    {
        _trajcetory = Trajcetory.Instance;
        _gameManager = GameManager.Instance;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _trajcetory.Show();
            _shootingPower = 0;
        }
        
        if (Input.GetMouseButton(0))
        {
            PrepareShoot();
            predict();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
            _trajcetory.Hide();
        }
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.zero;
    }

    private void PrepareShoot()
    {
        _shootingPower += _gameManager.currentPowerIncreaseRate * Time.deltaTime;
    }

    private void Shoot()
    {
        rb.AddForce(calculateForce(), ForceMode2D.Impulse);
        _gameManager.EnableFail(true);
    }
    
    void predict()
    {
        _trajcetory.UpdateDots(transform.position, calculateForce());
    }
    
    public Vector2 calculateForce()
    {
        Quaternion shootRotation = Quaternion.identity;
        shootRotation.eulerAngles = new Vector3(0,0,_shootingAngle);
        return shootRotation * Vector3.right * _shootingPower;
    }
}
