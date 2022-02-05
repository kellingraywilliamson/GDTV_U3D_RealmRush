using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RealmRush
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] [Range(0f, 5f)] private float speed = 1f;

        private List<Waypoint> _path = new();
        private const string PathTag = "Path";

        private void OnEnable()
        {
            FindPath();
            ReturnToStart();
            StartCoroutine(FollowPath());
        }

        private void FindPath()
        {
            _path.Clear();
            _path = GameObject.FindGameObjectWithTag(PathTag).GetComponentsInChildren<Waypoint>().ToList();
        }

        private void ReturnToStart()
        {
            transform.position = _path.First().transform.position;
        }

        private IEnumerator FollowPath()
        {
            foreach (var waypoint in _path)
            {
                var startPosition = transform.position;
                var endPosition = waypoint.transform.position;
                float travelPercent = 0;

                if (startPosition == endPosition) continue;

                transform.LookAt(endPosition);

                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }

            gameObject.SetActive(false);
        }
    }
}
