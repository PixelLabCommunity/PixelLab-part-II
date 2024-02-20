using UnityEngine;

namespace Forest2D.Utils
{
    public static class ForestUtils
    {
        private const float RandomMin = -1f;
        private const float RandomMax = 1f;

        public static Vector3 GetRandomDir()
        {
            return new Vector3(Random.Range(RandomMin, RandomMax), Random.Range(RandomMin, RandomMax)).normalized;
        }
    }
}