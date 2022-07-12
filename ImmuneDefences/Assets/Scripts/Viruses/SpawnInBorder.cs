using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInBorder : MonoBehaviour
{
    public Transform target;
    private PolygonCollider2D targerColl;
    private int spawns = 0;
    private bool running = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Material[] materials = new Material[11];

    

    void Start()
    {
        float i = Random.Range(6.00f, 9.00f);
        transform.localScale = new Vector3(i, i, 1);
        targerColl = target.GetComponent<PolygonCollider2D>();
        transform.position = targerColl.ClosestPoint(new Vector2 (Random.Range(targerColl.bounds.min.x, targerColl.bounds.max.x), Random.Range(targerColl.bounds.min.y, targerColl.bounds.max.y)));
        spriteRenderer = this.transform.GetComponent<SpriteRenderer>();
        spriteRenderer.material = materials[int.Parse(target.name.Remove(0, 4)) - 1];
        spriteRenderer.enabled = false;
        StartCoroutine("selfDestruct");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "V"){
            StopCoroutine("selfDestruct");
            if (running == false){
                spawn();
            }
        }
    }

    private void spawn(){
        running = true;
        transform.position = targerColl.ClosestPoint(new Vector2 (Random.Range(targerColl.bounds.min.x, targerColl.bounds.max.x), Random.Range(targerColl.bounds.min.y, targerColl.bounds.max.y)));
        spawns++;
        StartCoroutine("selfDestruct");
        if(spawns >= 100){
            Destroy(gameObject);
        }
        running = false;
    }

    private IEnumerator selfDestruct(){
        while(true){
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.enabled = true;
            Destroy(this);
        }
    }
}
