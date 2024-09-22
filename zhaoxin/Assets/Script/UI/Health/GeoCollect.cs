using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoCollect : MonoBehaviour
{
    public Animator collectAnim;
    public AudioClip[] geoCollect;
    private Hero player;
    Text geoText;

    AudioSource audiSource;
    private void Start()
    {
        player = transform.parent.GetComponent<Hero>();

        audiSource = GetComponent<AudioSource>();

        geoText = GameObject.Find("GeoText").GetComponent<Text>();

        geoText.text = player.GeoNum.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Geo"))
        {
            collectAnim.SetTrigger("Collect");
            int index = Random.Range(0, geoCollect.Length);
            audiSource.PlayOneShot(geoCollect[index]);
            player.GeoNum++;
            geoText.text = player.GeoNum.ToString();

            Destroy(collision.gameObject);
        }
    }
}
