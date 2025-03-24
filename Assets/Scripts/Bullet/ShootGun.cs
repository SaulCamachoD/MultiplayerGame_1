using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootGun : MonoBehaviour
{
    public Bulletpool bulletPool;
    public float fireRate = 0.5f;
    public float _speedBullet = 30f;
    public Transform _spawnpoint;
    private float nextFireTime = 0f;
    private PlayerInput playerInput;
    private InputAction fireAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        fireAction = playerInput.actions["Attack"];
    }

    void Update()
    {
        if (fireAction.ReadValue<float>() > 0&& Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = _spawnpoint.transform.position;
        bullet.transform.rotation = _spawnpoint.transform.rotation;

        // Aquí puedes agregar cualquier lógica adicional para el disparo, como aplicar fuerza, etc.
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * _speedBullet; // Ajusta la velocidad según sea necesario
        }
    }
}
