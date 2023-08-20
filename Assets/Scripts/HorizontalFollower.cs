using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalFollower : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if ( otherCollider.CompareTag("Player"))
        {
            SceneManager.LoadScene("Falha");
        }
    }
}