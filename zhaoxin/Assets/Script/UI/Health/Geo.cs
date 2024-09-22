using UnityEngine;

public class Geo : MonoBehaviour
{
    [SerializeField] private AudioClip[] geoHitGround;
    AudioSource geoSource;
    public bool isGround;

    private void Awake()
    {
        geoSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isGround&&collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGround = true;
            int index = Random.Range(0, geoHitGround.Length);
            geoSource.PlayOneShot(geoHitGround[index]);
        }
    }
}
