using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))] 
public class TargetCollision : MonoBehaviour
{
    bool beenHit = false;
    Animation targetRoot;
    public AudioClip hitSound;
    public AudioClip resetSound;
    public float resetTime = 3.0f;

    void Start() 
    {
        targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
    }

    void OnCollisionEnter(Collision theObject) 
    {
        if(!beenHit && theObject.gameObject.name == "coconut")
        {
            StartCoroutine("targetHit");
        }
    }

    IEnumerator targetHit() 
    {
        CoconutWin.targets++;
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("down");
        beenHit = true;

        yield return new WaitForSeconds(resetTime);

        GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetRoot.Play("up");
        beenHit = false;
        CoconutWin.targets--;
    }
}