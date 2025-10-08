using System;
using UnityEngine;

public class LaderComponent : Interactable
{
    [SerializeField] private Vector2 _targetPosition;
    private PlayerController2D _player;
    public override void Interact() {
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

    public Vector2 GetClosestPointCommand(Vector2 position) {
        // find the closest point on the ladder line.
        float angle = Vector2.Angle(
            _targetPosition.normalized,
            (position - (Vector2)transform.position).normalized);
        Debug.Log("Angle"+ angle);
        float adjasent = Mathf.Cos(angle*Mathf.Deg2Rad)*Vector2.Distance(position, transform.position); 
        Vector2 testPoint =_targetPosition.normalized*adjasent;
        
        //Check if the point is between the 2 points of the ladder
        float testDistance = _targetPosition.magnitude;
        if (testPoint.magnitude > testDistance) return _targetPosition+(Vector2)transform.position;
        if (Vector2.Distance(testPoint, _targetPosition) > testDistance) return transform.position;
        return testPoint+(Vector2)transform.position;
    }

    public bool IsOnLadder(Vector2 position)
    {
        float testDistance = _targetPosition.magnitude;
        if (Vector2.Distance(position, transform.position) > testDistance) return false;
        if (Vector2.Distance(position, _targetPosition+(Vector2)transform.position) > testDistance) return false;
        return true;
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

