using TMPro;
using UnityEngine;

public class HeathPlayerUI : MonoBehaviour
{
   private TextMeshProUGUI _health;
   private PlayerController _playerController;

   private void Start()
   {
      _health = GetComponent<TextMeshProUGUI>();
      _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
      
      RestoreHealth();
      
      _playerController.GetDamaged += RestoreHealth;
   }

   private void RestoreHealth()
   {
      _health.text = _playerController.Health.ToString();
   }
}
