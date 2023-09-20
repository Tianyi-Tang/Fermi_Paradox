using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 打击
/// </summary>
public class Projectile : MonoBehaviour
{
    private float projectileSpeed;

    private Transform target;
    private Vector3 targetPos;

    private Vector3 targetDir;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.position;
        targetDir = Vector3.Normalize(targetPos - gameObject.transform.position);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetPos) > Time.deltaTime * projectileSpeed)
                transform.position += targetDir * Time.fixedDeltaTime * projectileSpeed;
            else
                transform.position = targetPos;

            if (targetPos == transform.position)
            {
                Destroy(gameObject, 0.4f);
            }

        }
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public void setSpeed(float speed)
    {
        projectileSpeed = speed;
    }

    
}
