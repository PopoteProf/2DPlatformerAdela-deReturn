using System;
using System.Collections;
using Codice.CM.Client.Differences;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SOAnimationSprite))]
public class SoAniamtionSpriteObjectPreview : Editor {
    private int _selectedSprite = 0;
    private bool _isplaying = false;
    private float _time;
    
    private Texture2D _texture;
    static double lastTime;
    public override bool HasPreviewGUI() {
        return true;
    }
    
    public override void OnPreviewGUI(Rect r, GUIStyle background) {
        
        
        SOAnimationSprite targ = (SOAnimationSprite)target;
        if (targ.sprites == null|| targ.sprites.Length==0) return;
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
        if (_selectedSprite >= targ.sprites.Length) {
            _selectedSprite = 0;
        }
        
        if (targ.sprites[_selectedSprite] != null) {
            Rect spriteRect = targ.sprites[_selectedSprite].rect;
            Texture2D tex = targ.sprites[_selectedSprite].texture;
            
            //Rect rect = new Rect(spriteRect.x / tex.width, spriteRect.y / tex.height, size.x, size.y);
            Rect rect = new Rect(spriteRect.x / tex.width, spriteRect.y / tex.height, spriteRect.width / tex.width,
                spriteRect.height / tex.height);
            Rect size = GetSize(targ.sprites[_selectedSprite].rect, r);
            string infoDisplay = " Sprite name : " + targ.sprites[_selectedSprite].name + " \n" +
                                 " texture name : " + targ.sprites[_selectedSprite].texture.name + " \n" +
                                 " Sprite Size : X = " + targ.sprites[_selectedSprite].rect.width + "   Y = " +
                                 targ.sprites[_selectedSprite].rect.height;
            
            
            _texture = Texture2D.linearGrayTexture;
            
            
            GUI.DrawTextureWithTexCoords( size,_texture, new Rect(0f,0f,10,10));
            GUI.DrawTextureWithTexCoords( size, targ.sprites[_selectedSprite].texture, rect);
            GUI.Label(new Rect(r.x+r.width/3, r.y+5, r.width/3, 30), infoDisplay,style);
        }
        else {
            
            
            GUI.Label(new Rect(r.x+r.width/3, r.y+5, r.width/3, 20), "sprite is null", style);
        }

        if (GUI.Button(new Rect( r.x,  r.y+5,  100, 20), "Preview")) {
            ChangeSelectedSprite(-1);
        }
        if (GUI.Button(new Rect( r.x+ r.width-100,  r.y+5,  100, 20), "Next")) {
            ChangeSelectedSprite(1);
        }
        if (GUI.Button(new Rect( 0,  r.height-5,  60, 20), "play/stop")) {
            if (_isplaying) {
                _isplaying = false;
                EditorApplication.update -= ManageAnimation;
            }
            else {
                _isplaying = true;
                EditorApplication.update += ManageAnimation;
            }
        }
        _selectedSprite = Mathf.RoundToInt(EditorGUI.Slider(new Rect( 65,  r.height-5,  r.width-65, 20),_selectedSprite, 0,targ.sprites.Length-1));
    }

    private Rect GetSize(Rect spriteRect, Rect windowRect) {
        float spriteAspect = spriteRect.width/spriteRect.height;
        float windowAspect = windowRect.width/windowRect.height;
        float rasio;
        if (spriteAspect > windowAspect) {
            rasio = windowRect.width / spriteRect.width;
        }
        else
        {
            rasio = windowRect.height / spriteRect.height;
        }

        Vector2 size = new Vector2(spriteRect.width * rasio, (float)rasio * spriteRect.height);
        Vector2 center = windowRect.center-size/2+new Vector2(0,0);

        return new Rect(center,size ); 
    }

    private void ManageAnimation() {
        double currentTime = EditorApplication.timeSinceStartup;
        float deltaTime = (float)(currentTime - lastTime);

        lastTime = currentTime;
        _time += deltaTime;
        if (_time >= (target as SOAnimationSprite).TimeBetweenFame) {
            _time = 0;
            ChangeSelectedSprite(1);
            Repaint();
        }
    }
    
    private void ChangeSelectedSprite(int mod) {
        if (_selectedSprite + mod < 0) {
            _selectedSprite = ((SOAnimationSprite)target).sprites.Length - 1;
        }
        else if ( _selectedSprite +mod >=((SOAnimationSprite)target).sprites.Length) {
           _selectedSprite = 0;
        }
        else
        {
            _selectedSprite += mod;
        }
    }

    public void OnDisable() {
        if(_isplaying) EditorApplication.update -= ManageAnimation;
    }
}
