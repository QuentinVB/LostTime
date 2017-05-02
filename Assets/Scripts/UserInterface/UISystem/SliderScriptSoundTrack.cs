using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScriptSoundTrack : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private GameObject _sliderBackGround;
    private GameObject _sliderBall;
    private GameObject _CreateMusiquelevelLabel;

    private int _sliderSoundTrackMusicValue;

    private float _LeftLimit;
    private float _RightLimit;

    private void Start()
    {
        _sliderBackGround = GameObject.Find("CreateMusicLevelSliderBackGround");
        _sliderBall = GameObject.Find("CreateMusicLevelSliderBall");
        _CreateMusiquelevelLabel = GameObject.Find("CreateMusicLevelNb");
        _LeftLimit = (-_sliderBackGround.GetComponent<RectTransform>().rect.width / 2.2f + _sliderBackGround.transform.position.x);
        _RightLimit = (_sliderBackGround.GetComponent<RectTransform>().rect.width / 2.4f + _sliderBackGround.transform.position.x);
    }

    public virtual void OnDrag(PointerEventData SliderEvent)
    {
        Vector2 tmpPosition = _sliderBall.transform.position;
        


        if (SliderEvent.position.x > _LeftLimit && SliderEvent.position.x < tmpPosition.x)
        {
            tmpPosition.x = Mathf.Lerp(_sliderBall.transform.position.x, SliderEvent.position.x, 0.1f);
            _sliderBall.transform.position = tmpPosition;
        }

        if(SliderEvent.position.x < _RightLimit && SliderEvent.position.x > tmpPosition.x)
        {
            tmpPosition.x = Mathf.Lerp(_sliderBall.transform.position.x, SliderEvent.position.x, 0.1f);
            _sliderBall.transform.position = tmpPosition;
            
        }
        getSliderValue();
    }

    public virtual void OnPointerDown(PointerEventData SliderEvent)
    {
        Vector2 tmpPosition = _sliderBall.transform.position;

        if (SliderEvent.position.x > _LeftLimit && SliderEvent.position.x < tmpPosition.x)
        {
            tmpPosition.x = SliderEvent.position.x;
            _sliderBall.transform.position = tmpPosition;
        }

        if (SliderEvent.position.x < _RightLimit && SliderEvent.position.x > tmpPosition.x)
        {
            tmpPosition.x = SliderEvent.position.x;
            _sliderBall.transform.position = tmpPosition;
        }

        getSliderValue();
        OnDrag(SliderEvent);
    }

    public virtual void OnPointerUp(PointerEventData SliderEvent)
    {
        PlayerPrefs.SetInt("SoundTrackVolumeSave", _sliderSoundTrackMusicValue);
    }

    private void getSliderValue()
    {
        float SliderWidth = _RightLimit - _LeftLimit;
        
        for (int count = 0; count <= 100; count ++)
        {
            
            if (_sliderBall.transform.position.x >= _LeftLimit + (SliderWidth / 100) * (count + 1) && _sliderBall.transform.position.x < _LeftLimit + (SliderWidth / 100) * (count + 2))
            {
                _sliderSoundTrackMusicValue = count;
                _CreateMusiquelevelLabel.GetComponent<Text>().text = count.ToString();
            }
        }

        
    } 

}
