using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Collections.Generic;
using EditorAttributes.Editor.Utility;

namespace EditorAttributes.Editor
{
	[CustomPropertyDrawer(typeof(DropdownAttribute))]
    public class DropdownDrawer : PropertyDrawerBase
    {
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var dropdownAttribute = attribute as DropdownAttribute;
			var root = new VisualElement();
			var errorBox = new HelpBox();

			var memberInfo = ReflectionUtility.GetValidMemberInfo(dropdownAttribute.CollectionName, property);
			var collectionValues = ConvertCollectionValuesToStrings(dropdownAttribute.CollectionName, property, memberInfo, errorBox);

			var dropdownField = IsCollectionValid(collectionValues) ? new DropdownField(property.displayName, collectionValues, GetDropdownDefaultValue(collectionValues, property)) 
				: new DropdownField(property.displayName, new List<string>() { "NULL" }, 0);

			dropdownField.tooltip = property.tooltip;
			dropdownField.AddToClassList(BaseField<Void>.alignedFieldUssClassName);

			AddPropertyContextMenu(dropdownField, property);

			dropdownField.RegisterValueChangedCallback(callback => 
			{
				if (!property.hasMultipleDifferentValues)
					SetPropertyValueFromString(callback.newValue, property);
			});

			if (dropdownField.value != "NULL")
			{
				dropdownField.showMixedValue = property.hasMultipleDifferentValues;

				if (!property.hasMultipleDifferentValues)
					SetPropertyValueFromString(dropdownField.value, property);
			}

			root.Add(dropdownField);

			ExecuteLater(dropdownField, () => dropdownField.Q(className: DropdownField.inputUssClassName).style.backgroundColor = EditorExtension.GLOBAL_COLOR / 2f);

			UpdateVisualElement(dropdownField, () =>
			{
				var dropdownValues = ConvertCollectionValuesToStrings(dropdownAttribute.CollectionName, property, memberInfo, errorBox);

				if (IsCollectionValid(dropdownValues))
				{
					errorBox.text = string.Empty;
					dropdownField.choices = dropdownValues;
				}

				DisplayErrorBox(root, errorBox);
			});
			
			return root;
		}

		protected override void PasteValue(VisualElement element, SerializedProperty property, string clipboardValue)
		{
			var dropdown = element as DropdownField;

			if (dropdown.choices.Contains(clipboardValue))
			{
				base.PasteValue(element, property, clipboardValue);
				dropdown.SetValueWithoutNotify(clipboardValue);
			}
			else
			{
				Debug.LogWarning($"Could not paste value \"{clipboardValue}\" since is not availiable as an option in the dropdown");
			}
		}

		private string GetDropdownDefaultValue(List<string> collectionValues, SerializedProperty property)
		{
			var propertyStringValue = GetPropertyValueAsString(property);

			return collectionValues.Contains(propertyStringValue) ? propertyStringValue : collectionValues[0];
		}
	}
}
