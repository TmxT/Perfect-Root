using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Misc
{
    public static class LayerComparer
    {
        public static bool Compare(LayerMask _targetLayer, LayerMask _objLayer)
        {
            return (_targetLayer & 1 << _objLayer) == 1 << _objLayer;
        }
    }
}