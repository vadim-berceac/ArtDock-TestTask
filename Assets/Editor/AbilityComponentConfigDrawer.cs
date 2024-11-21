using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AbilityComponentConfig))]
public class AbilityComponentConfigDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property); 
        
        var componentType = property.FindPropertyRelative("componentType");
        
        //animation component
        var animationName = property.FindPropertyRelative("animationName");
        
        //sound component
        var soundClip = property.FindPropertyRelative("soundClip"); 
        
        //area damage component
        var radius = property.FindPropertyRelative("radius"); 
        var damage = property.FindPropertyRelative("damage"); 
        var colliderCount = property.FindPropertyRelative("colliderCount");
        
        position.height = EditorGUIUtility.singleLineHeight;
        
        EditorGUI.PropertyField(position, componentType);
        
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        switch ((AbilityComponentConfig.ComponentType)componentType.enumValueIndex)
        {
            case AbilityComponentConfig.ComponentType.PlayAnimation:
                EditorGUI.PropertyField(position, animationName);
                break;
            case AbilityComponentConfig.ComponentType.PlaySound: 
                EditorGUI.PropertyField(position, soundClip); 
                break;
            case AbilityComponentConfig.ComponentType.AreaDamage:
                EditorGUI.PropertyField(position, radius);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, damage);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, colliderCount);
                break;
        }
        EditorGUI.EndProperty();
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var componentType = property.FindPropertyRelative("componentType");
        var height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        switch ((AbilityComponentConfig.ComponentType)componentType.enumValueIndex)
        {
            case AbilityComponentConfig.ComponentType.PlayAnimation:
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing); 
                break; 
            case AbilityComponentConfig.ComponentType.PlaySound:
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                break;
            case AbilityComponentConfig.ComponentType.AreaDamage:
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 3;
                break;
        } 
        return height;
    }
}