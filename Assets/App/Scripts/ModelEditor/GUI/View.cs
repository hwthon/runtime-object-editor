using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public static class View
	{
		public static int indentLevel = 0;

		// public static bool Button(string text, params GUILayoutOption[] options)
		// {
		// 	return GUILayout.Button(text, options);
		// }

	}

	public class IndentScope : System.IDisposable
	{
		private int _indentLevel;

		public IndentScope(int indentLevel)
		{
			_indentLevel = indentLevel;
			View.indentLevel = indentLevel;
		}

		public void Dispose()
		{
			View.indentLevel = _indentLevel;
		}
	}

	public class FieldScope : System.IDisposable
	{
		private GUILayout.HorizontalScope _scope;
		public FieldScope(bool boxLayout)
		{
			_scope = new GUILayout.HorizontalScope();

			GUILayout.Space((Screen.width / 10f) * View.indentLevel);
		}

		public void Dispose()
		{
			_scope.Dispose();
		}
	}
}