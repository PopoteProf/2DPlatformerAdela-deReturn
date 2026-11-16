using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DeathTriggerZone : MonoBehaviour
{
    [SerializeField] private bool _usTagToTrigger = true; 
    [SerializeField] private string[] _triggerTag = new []{"Player", "Monsters"};
    
    [SerializeField] private UnityEvent _onTriggerEnter;
    private void OnTriggerEnter2D(Collider2D other) {
        if (_usTagToTrigger && !_triggerTag.Contains(other.tag)) return;
        _onTriggerEnter?.Invoke();
        if (other.CompareTag("Player")) StaticData.KillPlayer();
        if( other.CompareTag("Monsters")) other.GetComponent<Monster>().Kill();
    }
}