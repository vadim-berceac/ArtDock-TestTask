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
        var rotateToFirstTarget = property.FindPropertyRelative("rotateToFirstTarget");
        var layerMask = property.FindPropertyRelative("layerMask");
        var responseAbility = property.FindPropertyRelative("responseAbility");
        
        //particle component
        var prefab = property.FindPropertyRelative("effectPrefab");
        
        //move component
        var speed = property.FindPropertyRelative("speed");
        var moveDirection = property.FindPropertyRelative("moveDirection");
        
        //buff component
        var increaseStrength = property.FindPropertyRelative("increaseStrength");
        var increaseAgility = property.FindPropertyRelative("increaseAgility");
        var increaseDefence = property.FindPropertyRelative("increaseDefence");
        
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
                EditorGUI.PropertyField(position, rotateToFirstTarget);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, layerMask);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, responseAbility);
                break;
            
            case AbilityComponentConfig.ComponentType.PlayParticle:
                EditorGUI.PropertyField(position, prefab);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                break;
            
            case AbilityComponentConfig.ComponentType.Move:
                EditorGUI.PropertyField(position, speed);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, moveDirection);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                break;
            
            case AbilityComponentConfig.ComponentType.Buff:
                EditorGUI.PropertyField(position, increaseStrength);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, increaseAgility);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, increaseDefence);
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
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 6;
                break;
            
            case AbilityComponentConfig.ComponentType.PlayParticle:
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                break;
            
            case AbilityComponentConfig.ComponentType.Move:
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 2;
                break;
            
            case AbilityComponentConfig.ComponentType.Buff:
                height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 3;
                break;
        } 
        return height;
    }
}