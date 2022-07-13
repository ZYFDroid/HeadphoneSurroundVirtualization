#include "compressor.h"
#include "math_helper.h"
#include <cmath>

void ap::compressor::setParam(float srate, float gate, float ratio, float attack, float release)
{
    _gate = mh::db2linear(gate);
    _MininumGain = ratio == 0 ? -150 : mh::linear2db(1 / ratio);
    float sampleRate = srate;
    _gainAttackRate = (-_MininumGain) / (sampleRate * (attack / 1000.0f + 0.001f));
    _gainDecayRate = (-_MininumGain) / (sampleRate * (release / 1000.0f + 0.001f));
    _decayCds = srate / 1000.0f * 25.0f;
    if (attack <= 0.000001f)
    {
        _currentGain = 0.0f;//disable compressor
    }

}

void ap::compressor::process(float* buffer,int outOffset, int len, float* display)
{
    int i;
    for (i = 0; i < len; i+=2)
    {
        float l = buffer[outOffset + i];
        float r = buffer[outOffset + i + 1];
        _compressorGain = -_currentGain;
        float gainFactor = mh::db2linear(_currentGain);

        l = l * _gain * 0.9f * gainFactor;
        r = r * _gain * 0.9f * gainFactor;


        float dc = abs(l);//Math.Max(Math.Abs(l), Math.Abs(r));
        if (abs(r) > dc) {
            dc = abs(r);
        }

        if (dc > _gate)
        {
            _currentGain -= _gainAttackRate;
            if (_currentGain < _MininumGain)
            {
                _currentGain = _MininumGain;
            }
            _decayCd = _decayCds;
        }
        else
        {
            if (_decayCd > 0)
            {
                _decayCd--;
            }
            else
            {
                _currentGain += _gainDecayRate;
                if (_currentGain > 0)
                {
                    _currentGain = 0;
                }
            }
        }


        _maxLeft = _maxLeft > l ? _maxLeft : l;
        _maxRight = _maxRight > r ? _maxRight : r;


        buffer[outOffset + i] = l;
        buffer[outOffset + i + 1] = r;
        cd--;
        if (cd < 0)
        {
            cd = ccd;

            outLeft -= visualizerDownRate;
            outRight -= visualizerDownRate;

            if (outLeft < _maxLeft)
            {
                outLeft = _maxLeft;
            }
            if (outRight < _maxRight)
            {
                outRight = _maxRight;
            }
            _maxLeft = 0;
            _maxRight = 0;
            display[8] = outLeft;
            display[9] = outRight;
            display[10] = _compressorGain;
        }
    }
}

void ap::compressor::setMasterGain(float mastergain)
{
    _gain = mh::db2linear(mastergain);
}
