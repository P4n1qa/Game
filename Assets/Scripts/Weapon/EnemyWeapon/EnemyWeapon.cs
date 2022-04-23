using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().GetDamage();
            gameObject.SetActive(false);
        }
    }
}
