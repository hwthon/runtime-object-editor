using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ModelEditor : MonoBehaviour
	{
		private ObjectViewer _viewer;

		public void Show(object model)
		{
			_viewer = new ObjectViewer(model);
		}

		private void OnGUI()
		{
			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height)))
			{
				_viewer.OnGUI();
			}
		}
	}
}

/**

Viewer.Show(model);
viewer.onclose?
viewer.onsaved??
いる？

objectのメンバーを辿っていく



*/