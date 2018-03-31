using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class TextFieldViewer : FieldViewer
	{
		public TextFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo)
		{

		}

		protected override void DrawField()
		{
			string text = _fieldInfo.GetValue(_model) as string ?? "";
			_fieldInfo.SetValue(_model, GUILayout.TextField(text));
		}
	}
}