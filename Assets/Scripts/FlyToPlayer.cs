using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    public float Animation;
    public float duration;
    protected Vector3 playerPos;
    private Vector3 startPos;
    private GameObject player;
    public float height = 20f;
    private Vector3 nextPos;
    public float Timer = 2f;
    Explosion expl;

    // Start is called before the first frame update
    void Start()
    {
        Timer = duration;
        startPos = this.transform.position;
        player = GameObject.Find("player");
        if(player != null)
            playerPos = player.transform.position;
        expl = GetComponent<Explosion>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (playerPos == null || Timer <= 0f) {
            expl.Explode();
            Destroy(gameObject,1f);
        }
        else
        {
            LaunchBomb(playerPos);
        }

        

    }

    void LaunchBomb(Vector3 playerStartingPos)
    {
        Animation += Time.deltaTime;
        Animation = Animation % duration;
        transform.position = MathParabola.Parabola(startPos, playerPos, height, Animation / duration);
        nextPos = MathParabola.Parabola(startPos, playerPos, height, Animation + Time.deltaTime / duration);
        transform.LookAt(nextPos);
    }
}
