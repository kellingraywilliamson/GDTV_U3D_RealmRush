using TMPro;
using UnityEngine;

namespace RealmRush
{
    [ExecuteAlways]
    [RequireComponent(typeof(TextMeshPro))]
    public class CoordinateLabeler : MonoBehaviour
    {
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color blockedColor = Color.gray;

        private TextMeshPro _label;
        private Vector2Int _coordinates = new();
        private Waypoint _waypoint;

        private void Awake()
        {
            _label = GetComponent<TextMeshPro>();
            _label.enabled = false;
            _waypoint = GetComponentInParent<Waypoint>();
            DisplayCoordinates();
            UpdateObjectName();
        }

        private void Update()
        {
            SetLabelColor();
            ToggleLabels();

            if (Application.isPlaying) return;

            DisplayCoordinates();
            UpdateObjectName();
        }

        private void DisplayCoordinates()
        {
            var position = transform.parent.position;
            _coordinates.x = Mathf.RoundToInt(position.x / UnityEditor.EditorSnapSettings.move.x);
            _coordinates.y = Mathf.RoundToInt(position.z / UnityEditor.EditorSnapSettings.move.z);
            _label.text = $"{_coordinates.x},{_coordinates.y}";
        }

        private void UpdateObjectName()
        {
            transform.parent.name = _coordinates.ToString();
        }

        private void SetLabelColor()
        {
            _label.color = _waypoint.IsPlaceable ? defaultColor : blockedColor;
        }

        private void ToggleLabels()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _label.enabled = !_label.IsActive();
            }
        }
    }
}
