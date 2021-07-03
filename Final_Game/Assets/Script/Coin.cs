using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject ParticlePrefab;
    [SerializeField]
    private float ParticleTime = 1;
    public AudioClip coinSound;
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        AudioSource.PlayClipAtPoint(coinSound, transform.position);
        ScoreManager.instance.ChangeScore(coinValue);
        GameObject effect =Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, ParticleTime);
    }
}
