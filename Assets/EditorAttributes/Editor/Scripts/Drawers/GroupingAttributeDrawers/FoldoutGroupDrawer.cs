using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace EditorAttributes.Editor
{
	[CustomPropertyDrawer(typeof(FoldoutGroupAttribute))]
    public class FoldoutGroupDrawer : PropertyDrawerBase
    {
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var foldoutGroup = attribute as FoldoutGroupAttribute;
			var isFoldedSaveKey = $"{property.serializedObject.targetObject}_{property.propertyPath}_IsFolded";

			var root = new VisualElement();

			var foldout = new Foldout
			{
				style = { unityFontStyleAndWeight = FontStyle.Bold },
				text = foldoutGroup.GroupName,
				tooltip = property.tooltip,
				value = EditorPrefs.GetBool(isFoldedSaveKey)
			};

			if (foldoutGroup.DrawInBox)
				ApplyBoxStyle(foldout.contentContainer);

			foreach (string variableName in foldoutGroup.FieldsToGroup)
			{
				var variableProperty = FindNestedProperty(property, GetSerializedPropertyName(variableName, property));

				if (variableProperty != null)
				{
					var propertyField = DrawProperty(variableProperty);

					if (variableProperty.propertyType == SerializedPropertyType.Generic) // Slightly move dropdowns for serialized objects
						propertyField.style.marginLeft = 10f;

					propertyField.style.unityFontStyleAndWeight = FontStyle.Normal;

					foldout.Add(propertyField);

					ExecuteLater(propertyField, () =>
					{
						var label = propertyField.Q<Label>();

						if (label != null)
							label.style.marginRight = foldoutGroup.WidthOffset;
					});
				}
				else
				{
					foldout.Add(new HelpBox($"{variableName} is not a valid field", HelpBoxMessageType.Error));
					break;
				}
			}

			foldout.RegisterValueChangedCallback((callback) => EditorPrefs.SetBool(isFoldedSaveKey, callback.newValue));
			root.Add(foldout);

			ExecuteLater(foldout, () =>
			{
				var toggle = foldout.Q<Toggle>();

				toggle.style.backgroundColor = CanApplyGlobalColor ? EditorExtension.GLOBAL_COLOR / 3f : new Color(0.1f, 0.1f, 0.1f, 0.2f);
			});

			return root;
		}
	}
}
