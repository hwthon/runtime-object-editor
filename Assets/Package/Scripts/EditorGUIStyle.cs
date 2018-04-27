using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeObjectEditor
{
	/// <summary>
	/// デバッグのスタイル
	/// </summary>
	[System.Serializable]
	public class EditorGUIStyle
	{
		/// <summary>
		/// フォント
		/// </summary>
		[SerializeField]
		private Font m_Font;

		/// <summary>
		/// スキン
		/// </summary>
		[SerializeField]
		private GUISkin m_Skin;

		/// <summary>
		/// 画面の高さ
		/// </summary>
		private const float BASE_SCREEN_HEIGHT = 854;

		/// <summary>
		/// フォントサイズ
		/// </summary>
		private const int BASE_FONT_SIZE = 13;

		/// <summary>
		/// 画面のサイズに合わせたスキン設定
		/// </summary>
		private GUISkin m_CachedSkin;

		private int m_ScreenWidth = -1;
		private int m_ScreenHeight = -1;

		/// <summary>
		/// スキン取得（OnGUI()内から呼ぶ事）
		/// </summary>
		/// <returns>The skin.</returns>
		public GUISkin GetSkin()
		{
			int screenWidth = Screen.width;
			int screenHeight = Screen.height;

			if (m_ScreenWidth == screenWidth && m_ScreenHeight == screenHeight)
			{
				return m_CachedSkin;
			}

			m_ScreenWidth = screenWidth;
			m_ScreenHeight = screenHeight;

			if (m_Skin == null)
			{
				m_Skin = GUI.skin;
			}
			if (m_Font == null)
			{
				m_Font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			}

			m_CachedSkin = m_Skin;

			// 解像度に合わせてフォントサイズを調整する
			float calcedFontSize = (float) BASE_FONT_SIZE;
			if (m_ScreenWidth > m_ScreenHeight)
			{
				calcedFontSize *= (float) m_ScreenWidth / BASE_SCREEN_HEIGHT;
			}
			else
			{
				calcedFontSize *= (float) m_ScreenHeight / BASE_SCREEN_HEIGHT;
			}

			int fontSize = (int) calcedFontSize;

			InitStyle(m_CachedSkin.button, fontSize);
			InitStyle(m_CachedSkin.toggle, fontSize);
			InitStyle(m_CachedSkin.box, fontSize);
			InitStyle(m_CachedSkin.label, fontSize);
			InitStyle(m_CachedSkin.textField, fontSize);
			InitStyle(m_CachedSkin.textArea, fontSize);
			InitStyle(m_CachedSkin.scrollView, fontSize);
			InitStyle(m_CachedSkin.window, fontSize);

			foreach (GUIStyle style in m_CachedSkin.customStyles)
			{
				InitStyle(style, fontSize);
			}

			return m_CachedSkin;
		}

		/// <summary>
		/// スタイルの初期化
		/// </summary>
		/// <param name="style">Style.</param>
		/// <param name="fontSize">Font size.</param>
		private void InitStyle(GUIStyle style, int fontSize)
		{
			style.font = m_Font;
			style.fontSize = fontSize;
		}
	}
}