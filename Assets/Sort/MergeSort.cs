using Sort;
using TriInspector;
using UnityEditor;
using UnityEngine;

namespace Sort
{
    public class MergeSort : MonoBehaviour
    {
        [SerializeField] private TextAnchor _labelAlignment;
        [SerializeField] private Color _labelColor = Color.green;
        [SerializeField] private Color _labelBackgroundColor = Color.green;
        [SerializeField] private float _sortingDelay = 1;
        [SerializeField] private float _spacing = 1;
        [SerializeField] private int[] _numbers;

        private GUIStyle _labelStyle;

        [Button]
        public void Sort()
        {
            _numbers.MergeSortAsync(_sortingDelay).Forget();
        }

        [Button]
        public void Fill(int size)
        {
            ArrayExtensions.Refill(ref _numbers, size);
        }

        private void OnDrawGizmos()
        {
            UpdateStyle();

            for (int i = 0; i < _numbers.Length; i++)
            {
                Vector3 position = transform.position + new Vector3(i * _spacing, 1, 0);
                Handles.Label(position, $"{_numbers[i].ToString()}", _labelStyle);
            }
        }

        private void UpdateStyle()
        {
            if (_labelStyle == null ||
                _labelStyle.alignment != _labelAlignment ||
                _labelStyle.normal?.textColor != _labelColor ||
                _labelStyle.normal?.background?.GetPixel(0, 0) != _labelBackgroundColor)
            {
                _labelStyle = new GUIStyle
                {
                    alignment = _labelAlignment,
                    normal = new GUIStyleState
                    {
                        textColor = _labelColor
                    }
                };
            }
        }
    }
}