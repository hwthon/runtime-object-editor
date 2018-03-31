using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class FieldViewer : Viewer
	{
		protected object _model;
		protected FieldInfo _fieldInfo;

		public FieldViewer(object model, FieldInfo fieldInfo)
		{
			_model = model;
			_fieldInfo = fieldInfo;
		}

		public sealed override void OnGUI()
		{
			if (_model == null || _fieldInfo == null)
			{
				return;
			}

			using(new FieldScope(false))
			{
				GUILayout.Label(_fieldInfo.Name);
				DrawField();
			}
		}

		protected string GetTextValue()
		{
			object value = _fieldInfo.GetValue(_model);
			return value == null ? string.Empty : value.ToString();
		}

		protected virtual void DrawField()
		{
			GUILayout.TextField(_fieldInfo.GetValue(_model) != null ? _fieldInfo.GetValue(_model).ToString() : "");
		}
	}
}