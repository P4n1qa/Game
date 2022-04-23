using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speed;

   private SliderPower _sliderPower;
   private bool _canShot;
   private PoolUse _poolUse;
   
   public int Health;
   public event Action GetDamaged;
   
   private void Start()
   {
      _sliderPower = FindObjectOfType<SliderPower>().GetComponent<SliderPower>();
      _canShot = true;
      _poolUse = FindObjectOfType<PoolUse>().GetComponent<PoolUse>();
   }

   public void GetDamage()
   {
      Health -= 1;
      GetDamaged?.Invoke();
   }
   private void Move()
   {
      transform.position += new Vector3(0, _speed, 0) * Input.GetAxis("Vertical");
   }

   private void Update()
   {
      Move();
      if (Input.GetMouseButtonDown(0) && _canShot == true)
      {
         StartCoroutine(CR_Shot());
      }
   }

   private IEnumerator CR_Shot()
   {
      _poolUse.CreatePlayerWeapon(this.transform , _sliderPower.Slider.value);
      _canShot = false;
      yield return new WaitForSeconds(2f);
      _canShot = true;
   }
}
