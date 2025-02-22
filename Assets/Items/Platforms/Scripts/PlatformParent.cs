using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformParent : Interactuable
{
    [Header("Platform Variables")]
    [SerializeField] Transform[] targets;
    [SerializeField] float speed;
    [SerializeField] float restTime;
    Rigidbody2D rb;
    IEnumerator movePlatform;
    int currentTarget;
    public override void Awake()
    {
        currentTarget = 0;
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        movePlatform = MovePlatform();
    }
    public override void Start()
    {
        base.Start();
        if (circlesHolder != null)
            transform.position = targets[currentTarget].position;
    }
    public override void Activate()
    {
        if (active)
            return;
        StopAllCoroutines();
        base.Activate();
        //Debug.Log(movePlatform);
        movePlatform= MovePlatform();
        StartCoroutine(movePlatform);
    }
    public override void Deactivate()
    {
        base.Deactivate();
        rb.velocity = Vector2.zero;
       // currentTarget = (currentTarget < targets.Length - 1) ? currentTarget + 1 : 0;
        StopCoroutine(movePlatform);
        movePlatform = null;

    }
    IEnumerator MovePlatform()
    {
        currentTarget = (currentTarget < targets.Length - 1) ? currentTarget + 1 : 0;
        Debug.Log("Move plataform "+ targets.Length);
        while (active)
        {
            rb.velocity = (targets[currentTarget].position - transform.position).normalized * speed;
            yield return new WaitUntil(() => Vector2.Distance(transform.position, targets[currentTarget].position) < 0.01f);
            Deactivate();
            //yield return Helpers.GetWait(restTime);
            //currentTarget = (currentTarget < targets.Length - 1) ? currentTarget + 1 : 0;
        }
    }
    private void OnDrawGizmos()
    {
        if (targets.Length > 0)
        { 
            for (int i = 0; i < targets.Length-1; i++)
            {
                Gizmos.DrawLine(targets[i].position, targets[i + 1].position);
            }
            Gizmos.DrawLine(targets[0].position, targets[targets.Length-1].position);
        }

    }
}
