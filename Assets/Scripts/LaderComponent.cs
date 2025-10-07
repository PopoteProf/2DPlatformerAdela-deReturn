using System;
using UnityEngine;

public class LaderComponent : Interactable
{
    [SerializeField] private Vector2 _targetPosition;
    private PlayerController2D _player;
    public override void Interact()
    {
        base.Interact();
        if (_player != null) {
            _player.EnterOnLader(this);
        }
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.GetComponent<PlayerController2D>() != null)
        {
            _player = other.gameObject.GetComponent<PlayerController2D>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetClosestPosition(Vector2 position) {
        return NearestPointOnLine(transform.position, (Vector3)_targetPosition - transform.position, position);
    }
    
    public  Vector2 NearestPointOnLine(Vector2 linePnt, Vector2 lineDir, Vector2 pnt)
    {
        lineDir.Normalize();//this needs to be a unit vector
        var v = pnt - linePnt;
        var d = Vector2.Dot(v, lineDir);
        return linePnt + lineDir * d;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.chartreuse;
        Gizmos.DrawLine(transform.position, (Vector3)_targetPosition+transform.position);
    }
}

