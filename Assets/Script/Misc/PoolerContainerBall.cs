using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Balls;

namespace PerfectRoot.Misc
{
    public class PoolerContainerBall : MonoBehaviour
    {
        private List<Ball> listPool = new List<Ball>();

        [SerializeField] Ball poolObject;

        [Space]
        [SerializeField] int initPool = 5;

        private void Start()
        {
            Ball temp;

            for (int i = 0; i < initPool; i++)
            {
                temp = Instantiate(poolObject, transform);
                listPool.Add(temp);
                temp.gameObject.SetActive(false);
            }
        }

        public Ball Pop()
        {
            Ball temp;

            if (listPool.Count == 0)
                listPool.Add(Instantiate(poolObject, transform));

            temp = listPool[0];
            temp.SetupContainer(this);

            return temp;
        }

        public void Add(Ball _poolerObject)
        {
            if (!listPool.Contains(_poolerObject))
                listPool.Add(_poolerObject);
        }

        public void Remove(Ball _poolerObject)
        {
            if (listPool.Contains(_poolerObject))
                listPool.Remove(_poolerObject);
        }
    }
}