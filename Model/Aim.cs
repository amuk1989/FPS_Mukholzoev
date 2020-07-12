using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class Aim : MonoBehaviour, ICollision, ISelectObj
    {
        public event Action OnPointChange = delegate {  };
		
        public float Hp = 100;
        private bool _isDead;
        private float _timeToDestroy = 10.0f;
        //todo дописать поглащение урона
        public void CollisionEnter(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, _timeToDestroy);

                OnPointChange.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return $"{gameObject.name} - {Hp}";
        }
    }
}
