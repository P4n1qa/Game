using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private GameObject _snowBall;

   private SliderPower _sliderPower;
   private bool _canShot;
   
   public int _health;
   
   private void Start()
   {
      _sliderPower = FindObjectOfType<SliderPower>().GetComponent<SliderPower>();
      _canShot = true;
   }

   public void GetDamage()
   {
      _health -= 1;
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
      GameObject SnowBall = Instantiate(_snowBall, gameObject.transform.position, quaternion.identity);
      SnowBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(_sliderPower.Slider.value, 0));
      _canShot = false;
      yield return new WaitForSeconds(2f);
      _canShot = true;
   }
}
