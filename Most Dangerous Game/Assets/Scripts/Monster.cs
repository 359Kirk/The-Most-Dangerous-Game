using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] AudioSource _source1;
    [SerializeField] AudioSource _source2;

    bool _hasDied;

    void OnMouseDown()
    {
        _source2.Play();
    }

    IEnumerator Start()
    {
        while (_hasDied == false)
        {
            float delay = UnityEngine.Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (_hasDied == false)
            {
                _source2.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
        {
            return false;
        }
        Elephant elephant = collision.gameObject.GetComponent<Elephant>();
        if (elephant != null)
        {
            return true;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }

        return false;
    }

    IEnumerator Die()
    {
        _hasDied = true;
        _particleSystem.Play();
        _source1.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
