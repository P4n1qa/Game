using System;
using System.Collections;
using System.Collections.Generic;
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
   }

   private void RestoreHealth()
   {
      _health.text = _playerController._health.ToString();
   }
}
