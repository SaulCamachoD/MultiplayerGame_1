using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; 

    void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    void OnDisable()
    {
        
        CancelInvoke("Deactivate");
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Desactiva la bala al colisionar con algo
        Deactivate();
    }
}
