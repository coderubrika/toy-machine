using UnityEngine;
using System;

namespace Assets.Scripts.Serializable.SencentiveFields
{
    [System.Serializable]
    public abstract class SencentiveField<T>
    {
        [SerializeField]
        protected T filed;

        private int sensitivity, sensitivityCounter;

        public SencentiveField(T filed, int sensitivity = 1)
        {
            this.sensitivity = sensitivity;
            this.filed = filed;
        } 

        public void Set(T value)
        {
            if (Compare(value) && Compare(filed)) return;

            if (Compare(value))
            {
                sensitivityCounter += 1;

                if (sensitivityCounter > sensitivity)
                {
                    sensitivityCounter = 0;
                    filed = value;
                }
            }

            else
            {
                sensitivityCounter = 0;
                filed = value;
            }
        }

        public T Get()
        {
            return filed;
        }

        protected abstract bool Compare(T value);
    }
}