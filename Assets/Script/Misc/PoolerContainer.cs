using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Misc
{
    public class PoolerContainer : MonoBehaviour
    {
        private List<PoolerObject> listPool = new List<PoolerObject>();

        [SerializeField] PoolerObject poolObject;

        [Space]
        [SerializeField] int initPool = 5;

        private void Start()
        {
            PoolerObject temp;

            for (int i = 0; i < initPool; i++)
            {
                temp = Instantiate(poolObject, transform);
                listPool.Add(temp);
                temp.gameObject.SetActive(false);
            }
        }

        public PoolerObject Pop()
        {
            PoolerObject temp;

            if (listPool.Count == 0)
                listPool.Add(Instantiate(poolObject, transform));

            temp = listPool[0];
            temp.Setup(this);

            return temp;
        }

        public void Add(PoolerObject _poolerObject)
        {
            if(!listPool.Contains(_poolerObject))
                listPool.Add(_poolerObject);
        }

        public void Remove(PoolerObject _poolerObject)
        {
            if (listPool.Contains(_poolerObject))
                listPool.Remove(_poolerObject);
        }
    }
}