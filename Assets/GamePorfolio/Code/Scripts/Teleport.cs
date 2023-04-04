using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private void Start()
    {
        this._player = FindObjectOfType<PlayerController>();
    }

    public void TeleportToTarget(Transform target)
    {
        StartCoroutine(TeleportCoroutine(target));
    }

    private IEnumerator TeleportCoroutine(Transform target)
    {
        yield return new WaitForSeconds(0.1f);
        this._player.gameObject.transform.position = target.position;
    }
}
