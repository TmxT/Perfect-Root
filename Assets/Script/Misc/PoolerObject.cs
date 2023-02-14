using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Misc
{
    public class PoolerObject : MonoBehaviour
    {
        private PoolerContainer poolerContainer;

        public void Setup(PoolerContainer _poolerContainer)
        {
            poolerContainer = _poolerContainer;

            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            if(poolerContainer)
                poolerContainer.Remove(this);
        }

        private void OnDisable()
        {
            if (poolerContainer)
                poolerContainer.Add(this);
        }
    }
}