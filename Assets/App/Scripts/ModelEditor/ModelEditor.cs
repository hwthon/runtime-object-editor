using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	/// <summary>
	/// オブジェクトの値を編集可能なGUI
	/// </summary>
	public class ModelEditor : MonoBehaviour
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
		private ObjectViewer _objectViewer;

		/// <summary>
		/// スクロール位置
		/// </summary>
		private Vector2 _scrollPosition;

		/// <summary>
		/// 終了時コールバック
		/// </summary>
		private System.Action _onClose;

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="model">編集したいオブジェクト</param>
		/// <param name="onClose">編集終了時呼び出し</param>
		public void Show(object model, System.Action onClose = null)
		{
			_enable = true;
			_scrollPosition = Vector2.zero;
			_objectViewer = new ObjectViewer(model);
			_onClose = onClose;
		}

		/// <summary>
		/// GUI描画
		/// </summary>
		private void OnGUI()
		{
			if (!_enable)
			{
				return;
			}

			if (_objectViewer == null)
			{
				return;
			}

			float headerHeight = Screen.height / 10f;

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, headerHeight)))
			{
				using(new GUILayout.HorizontalScope())
				{
					GUILayout.Label("ModelEditor", GUILayout.ExpandWidth(true));

					if (GUILayout.Button("X", GUILayout.ExpandWidth(false)))
					{
						Close();
					}
				}
			}

			using(new GUILayout.AreaScope(new Rect(0f, headerHeight, Screen.width, Screen.height - headerHeight)))
			{
				using(var scrollScope = new GUILayout.ScrollViewScope(_scrollPosition))
				{
					_objectViewer.OnGUI();

					_scrollPosition = scrollScope.scrollPosition;
				}
			}
		}

		/// <summary>
		/// 終了
		/// </summary>
		private void Close()
		{
			_enable = false;
			if (_onClose != null)
			{
				_onClose();
			}
		}
	}
}