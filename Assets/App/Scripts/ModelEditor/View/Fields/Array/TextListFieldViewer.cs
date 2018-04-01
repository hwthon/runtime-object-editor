using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextListFieldViewer : FieldViewer
	{
		private bool _foldout = true;

		public TextListFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo) { }

		public static bool Available(System.Type type)
		{
			return type == typeof(List<string>);
		}

		public override void OnGUI()
		{
			if (_model == null || _fieldInfo == null)
			{
				return;
			}

			using(new FieldScope(false))
			{
				if (GUILayout.Button(_foldout ? "▼" : "▶︎", GUILayout.ExpandWidth(false)))
				{
					_foldout = !_foldout;
				}
				GUILayout.Label(_model.GetType().Name);
			}

			if (_foldout)
			{
				using(new GUILayout.HorizontalScope())
				using(new IndentScope(View.indentLevel + 1))
				using(new FieldScope(false))
				{
					using(new GUILayout.VerticalScope())
					{
						System.Type itemType = typeof(string);
						System.Type listType = typeof(List<>).MakeGenericType(itemType);

						var list = _fieldInfo.GetValue(_model) as List<string>;
						if (list == null)
						{
							list = new List<string>();
						}

						int removeIndex = -1;
						for (int i = 0; i < list.Count; i++)
						{
							using(new GUILayout.HorizontalScope())
							{
								list[i] = GUILayout.TextField(list[i]);

								if (GUILayout.Button("-", GUILayout.ExpandWidth(false)))
								{
									removeIndex = i;
								}
							}
						}

						if (removeIndex != -1)
						{
							list.RemoveAt(removeIndex);
						}

						if (GUILayout.Button("+"))
						{
							list.Add(default(string));
						}

						_fieldInfo.SetValue(_model, list);
					}
				}
			}
		}
	}
}