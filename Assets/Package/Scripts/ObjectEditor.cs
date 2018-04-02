using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeObjectEditor
{
	/// <summary>
	/// オブジェクトの値を編集可能なGUI
	/// </summary>
	public class ObjectEditor : MonoBehaviour
	{
		/// <summary>
		/// GUIの描画を行うか
		/// </summary>
		[SerializeField]
		private bool _enable = false;

		/// <summary>
		/// 表示中か
		/// </summary>
		public bool Visible { get { return _enable; } }

		/// <summary>
		/// オブジェクトの編集
		/// </summary>
		private Viewer _rootViewer;

		/// <summary>
		/// スクロール位置
		/// </summary>
		private Vector2 _scrollPosition;

		/// <summary>
		/// レイキャスト防止パネル
		/// </summary>
		private GameObject _blockingPanel;

		/// <summary>
		/// 終了時コールバック
		/// </summary>
		private System.Action _onClose;

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="model">編集したいオブジェクト</param>
		/// <param name="onClose">編集終了時呼び出し</param>
		public void Open(object model, System.Action onClose = null)
		{
			if (model == null)
			{
				Close();
				return;
			}

			_enable = true;
			_scrollPosition = Vector2.zero;
			_rootViewer = ViewerFactory.I.Create(model);
			_onClose = onClose;

			Foreground();
		}

		/// <summary>
		/// 最前面に表示
		/// </summary>
		private void Foreground()
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

		/// <summary>
		/// GUI描画
		/// </summary>
		private void OnGUI()
		{
			if (!_enable || _rootViewer == null)
			{
				return;
			}

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, GUI.skin.box))
			{
				DrawScreen();
			}
		}

		/// <summary>
		/// 画面描画
		/// </summary>
		private void DrawScreen()
		{
			float headerHeight = Screen.height / 10f;

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, headerHeight)))
			{
				DrawHeader();
			}

			using(new GUILayout.AreaScope(new Rect(0f, headerHeight, Screen.width, Screen.height - headerHeight)))
			using(new GUILayout.VerticalScope(GUI.skin.box))
			{
				DrawFields();
			}
		}

		/// <summary>
		/// ヘッダーの描画
		/// </summary>
		private void DrawHeader()
		{
			using(new GUILayout.HorizontalScope(GUI.skin.box))
			{
				GUILayout.Label("ModelEditor", GUILayout.ExpandWidth(true));

				if (GUILayout.Button("x", GUILayout.ExpandWidth(false)))
				{
					Close();
				}
			}
		}

		/// <summary>
		/// オブジェクトのフィールドの描画
		/// </summary>
		private void DrawFields()
		{
			using(var scrollScope = new GUILayout.ScrollViewScope(_scrollPosition))
			{
				_rootViewer.OnGUI();

				_scrollPosition = scrollScope.scrollPosition;
			}
		}

		/// <summary>
		/// 終了
		/// </summary>
		public void Close()
		{
			if (!_enable)
			{
				return;
			}

			if (_blockingPanel != null)
			{
				_blockingPanel.SetActive(false);
			}

			_enable = false;
			if (_onClose != null)
			{
				_onClose();
			}
		}
	}
}