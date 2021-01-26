using UnityEngine;

public class PlayerKillY : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D _col){
        if (_col.gameObject.CompareTag("Player")) {
            _col.gameObject.transform.position = Vector2.zero;
        }
    }
}
