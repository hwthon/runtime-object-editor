using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeObjectEditor
{
	/// <summary>
	/// オブジェクトの値を編集可能なGUI
	/// </summary>
	[RequireComponent(typeof(FrontestCanvas))]
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
		/// 終了時コールバック
		/// </summary>
		private System.Action _onClose;

		[SerializeField]
		EditorGUIStyle guiStyle;

		public FrontestCanvas canvas { get { return GetComponent<FrontestCanvas>() ?? gameObject.AddComponent<FrontestCanvas>(); } }

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

			canvas.Activate();
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

			if (guiStyle == null)
			{
				guiStyle = new EditorGUIStyle();
			}

			var skin = GUI.skin;
			GUI.skin = guiStyle.GetSkin();

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, GUI.skin.box))
			{
				DrawScreen();
			}

			GUI.skin = skin;
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

			canvas.Deactivate();

			_enable = false;
			if (_onClose != null)
			{
				_onClose();
			}
		}
	}
}