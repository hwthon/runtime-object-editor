using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeObjectEditor
{
	public class FrontestCanvas : MonoBehaviour
	{
		/// <summary>
		/// レイキャスト防止パネル
		/// </summary>
		private GameObject _blockingPanel;

		/// <summary>
		/// 最前面に表示
		/// </summary>
		public void Activate()
		{
			transform.SetParent(null, false);

			int maxSortingOrder = 0;
			Canvas[] canvases = FindObjectsOfType<Canvas>();
			foreach (Canvas canvas in canvases)
			{
				maxSortingOrder = Mathf.Max(maxSortingOrder, canvas.sortingOrder);
			}

			var screenCanvas = AddUniqueComponent<Canvas>();
			screenCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			screenCanvas.sortingOrder = maxSortingOrder + 1;

			var scaler = AddUniqueComponent<CanvasScaler>();
			scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			scaler.referenceResolution = new Vector2(1024f, 800f);
			scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			scaler.matchWidthOrHeight = 0f;

			AddUniqueComponent<GraphicRaycaster>();

			ActivateBlockingPanel();
		}

		/// <summary>
		/// コンポーネントをつける（あればつけない）
		/// </summary>
		private T AddUniqueComponent<T>() where T : Component
		{
			var component = gameObject.GetComponent<T>();
			if (component == null)
			{
				component = gameObject.AddComponent<T>();
			}
			return component;
		}

		/// <summary>
		/// タッチ防止パネルを有効化する
		/// </summary>
		private void ActivateBlockingPanel()
		{
			if (_blockingPanel == null)
			{
				_blockingPanel = new GameObject("Block");
				_blockingPanel.transform.SetParent(transform);

				var image = _blockingPanel.AddComponent<Image>();
				image.rectTransform.anchorMin = Vector2.zero;
				image.rectTransform.anchorMax = Vector2.one;
				image.rectTransform.offsetMin = new Vector2(0f, 0f);
				image.rectTransform.offsetMax = new Vector2(0f, 0f);
				image.color = Color.white;
			}
			_blockingPanel.SetActive(true);
		}

		public void Deactivate()
		{
			if (_blockingPanel != null)
			{
				_blockingPanel.SetActive(false);
			}
		}
	}
}