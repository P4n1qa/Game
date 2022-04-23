using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().GetDamage();
            gameObject.SetActive(false);
        }
    }
}
