using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ColorFieldViewer : FieldViewer
	{
		private Texture2D _texture;

		public ColorFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo)
		{
			_texture = new Texture2D(32, 32, TextureFormat.ARGB32, false);
		}

		public static bool Available(System.Type type)
		{
			return type == typeof(Color);
		}

		protected override void DrawField()
		{
			var value = (Color) _fieldInfo.GetValue(_model);

			Rect rect = GUILayoutUtility.GetLastRect();
			rect.x = rect.xMax - rect.height;
			rect.width = rect.height;

			string r = GUILayout.TextField(value.r.ToString());
			string g = GUILayout.TextField(value.g.ToString());
			string b = GUILayout.TextField(value.b.ToString());
			string a = GUILayout.TextField(value.a.ToString());

			var color = new Color(r.ToFloat(value.r), g.ToFloat(value.g), b.ToFloat(value.b), a.ToFloat(value.a));
			_fieldInfo.SetValue(_model, color);

			Color[] pixels = _texture.GetPixels();
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = color;
			}
			_texture.SetPixels(pixels);
			_texture.Apply();

			GUI.DrawTexture(rect, _texture);
		}
	}
}