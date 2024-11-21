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
        var layerMask = property.FindPropertyRelative("layerMask");
        var responseAbility = property.FindPropertyRelative("responseAbility");
        
        //particle component
        var prefab = property.FindPropertyRelative("effectPrefab");
        
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
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, layerMask);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, responseAbility);
                break;
            
            case AbilityComponentConfig.ComponentType.PlayParticle:
                EditorGUI.PropertyField(position, prefab);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
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
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 5;
                break;
            
            case AbilityComponentConfig.ComponentType.PlayParticle:
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                break;
        } 
        return height;
    }
}