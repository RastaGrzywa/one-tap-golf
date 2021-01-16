using UnityEngine;

public class FailObject : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private bool _failEnabled = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_failEnabled && other.collider.tag == "Ball")
        {
            gameManager.FailLevel();
        }
    }

    public void EnableFail(bool enable)
    {
        _failEnabled = enable;
    }
}

