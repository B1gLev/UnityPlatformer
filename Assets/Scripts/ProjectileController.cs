using Unity.Burst;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 15f;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(transform.rotation.z == 0 ? 1 : -1, 0) * projectileSpeed, ForceMode2D.Impulse);
    }

    public void Stop()
    {
        rigidbody2D.velocity = new(0, 0);
        audioSource.mute = true;
    }
}
