using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ObjectViewer : Viewer
	{
		private object _model;

		private ObjectViewer _parent;

		private int _indent;

		private bool _foldout = true;

		private List<Viewer> _viewers;

		public ObjectViewer(object model, ObjectViewer parent = null)
		{
			_model = model;
			_parent = parent;
			_indent = CalculateIndent();
			_viewers = new List<Viewer>();

			foreach (FieldInfo fieldInfo in _model.GetType().GetFields())
			{
				Viewer viewer = FieldFactory.Create(_model, fieldInfo);
				if (viewer == null)
				{
					Debug.LogWarning("viewer is null.");
					continue;
				}

				_viewers.Add(viewer);
			}
		}

		/// <summary>
		/// インデントの計算
		/// </summary>
		public int CalculateIndent()
		{
			if (_parent == null)
			{
				return 0;
			}
			return _parent.CalculateIndent() + 1;
		}

		public override void OnGUI()
		{
			// TODO: field名が欲しい
			if (GUILayout.Button(_model.GetType().Name))
			{
				_foldout = !_foldout;
			}

			if (_foldout)
			{
				foreach (Viewer viewer in _viewers)
				{
					viewer.OnGUI();
				}
			}
		}
	}
}