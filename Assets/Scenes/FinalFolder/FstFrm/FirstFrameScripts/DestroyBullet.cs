using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerController2DPlatformer player;

    private void Awake()
    {
        player = playerObject.GetComponent<PlayerController2DPlatformer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.died)
        {
            Destroy(gameObject);
        }
    }
}
