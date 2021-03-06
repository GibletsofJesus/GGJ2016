﻿using UnityEngine;
using System.Collections;

public class exploder : MonoBehaviour {

    public AudioClip sound;
    public bool doDamage = false;
	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<CameraShake>().shake = true;
        Camera.main.GetComponent<CameraShake>().shakeRange = transform.localScale /2;

        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
        StartCoroutine(changCol());
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (doDamage)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<movement>().HP -= Random.Range(40, 60);
            }

            if (col.gameObject.tag == "enemy")
            {
                col.gameObject.GetComponent<enemy>().HP -= Random.Range(70, 90);
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(col.transform.rotation.z, col.transform.rotation.w) * 1000, ForceMode2D.Force);
            }
        }
    }

    IEnumerator changCol()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject,0.5f);
    }
}