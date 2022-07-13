// pch.cpp: 与预编译标头对应的源文件

#include "pch.h"
using namespace fftconvolver;
using namespace ap;
// 当使用预编译的头时，需要使用此源文件，编译才能成功。


FFTConvolver* conv01 = new FFTConvolver();
FFTConvolver* conv02 = new FFTConvolver();
FFTConvolver* conv03 = new FFTConvolver();
FFTConvolver* conv04 = new FFTConvolver();
FFTConvolver* conv05 = new FFTConvolver();
FFTConvolver* conv06 = new FFTConvolver();
FFTConvolver* conv07 = new FFTConvolver();
FFTConvolver* conv08 = new FFTConvolver();
FFTConvolver* conv09 = new FFTConvolver();
FFTConvolver* conv10 = new FFTConvolver();
FFTConvolver* conv11 = new FFTConvolver();
FFTConvolver* conv12 = new FFTConvolver();
FFTConvolver* conv13 = new FFTConvolver();
FFTConvolver* conv14 = new FFTConvolver();
FFTConvolver* conv15 = new FFTConvolver();
FFTConvolver* conv16 = new FFTConvolver();
FFTConvolver* convOLL = new FFTConvolver();
FFTConvolver* convOLR = new FFTConvolver();
FFTConvolver* convORL = new FFTConvolver();
FFTConvolver* convORR = new FFTConvolver();

Sample* st1_FL_L = NULL;
Sample* st1_FL_R = NULL;
Sample* st1_FR_L = NULL;
Sample* st1_FR_R = NULL;
Sample* st1_FC_L = NULL;
Sample* st1_FC_R = NULL;
Sample* st1_LF_L = NULL;
Sample* st1_LF_R = NULL;
Sample* st1_RL_L = NULL;
Sample* st1_RL_R = NULL;
Sample* st1_RR_L = NULL;
Sample* st1_RR_R = NULL;
Sample* st1_SL_L = NULL;
Sample* st1_SL_R = NULL;
Sample* st1_SR_L = NULL;
Sample* st1_SR_R = NULL;

Sample* st1_L = NULL;
Sample* st1_R = NULL;

Sample* st2_L = NULL;
Sample* st2_R = NULL;

Sample* st3_L = NULL;
Sample* st3_R = NULL;


std::mutex hrirMutex;
std::mutex enchMutex;


bool inited = false;
/// <summary>
/// 初始化内存，分配用于计算的内存区域
/// </summary>
/// <returns></returns>
bool __stdcall init_mem()
{
    if (inited) {
        return true;
    }

    bool result = true;

    result &= (st1_FL_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_FL_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_FR_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_FR_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_FC_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_FC_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_LF_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_LF_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_SL_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_SL_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_SR_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_SR_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_RL_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_RL_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_RR_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_RR_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_L = (fftconvolver::Sample*)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st1_R = (fftconvolver::Sample*)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st2_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st2_R = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st3_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != NULL;
    result &= (st3_R = (fftconvolver::Sample*)malloc(sizeof(float) * 48000)) != NULL;
    if (result) {
        inited = true;
    }
    return result;
}

/// <summary>
/// 设置环绕声的IR
/// </summary>
/// <param name="ir">和输入音频相同采样率的卷积</param>
/// <param name="irLen">样本长度（浮点数数量）</param>
/// <param name="chanCount">频道数量（7或14）</param>
/// <returns></returns>
bool __stdcall set_sr_ir(const fftconvolver::Sample* ir, int irLen, int chanCount)
{
    int frameCount = irLen / chanCount;
    fftconvolver::Sample* tempBuffer = (fftconvolver::Sample*) malloc(sizeof(float) * frameCount);
    if (tempBuffer == NULL) { return false; }
    bool result = true;
    hrirMutex.lock();
    
    result &= initOneIr(ir, frameCount, chanCount, 0 , conv01, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 1 , conv02, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 8 , conv03, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 9 , conv04, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 6 , conv05, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 7 , conv06, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 6 , conv07, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 7 , conv08, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 4 , conv09, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 5 , conv10, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 12, conv11, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 13, conv12, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 2 , conv13, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 3 , conv14, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 10, conv15, tempBuffer);
    result &= initOneIr(ir, frameCount, chanCount, 11, conv16, tempBuffer);
    hrirMutex.unlock();
    free(tempBuffer);
    return result;
}

bool __stdcall set_en_ir(const fftconvolver::Sample* ll, const fftconvolver::Sample* lr, const fftconvolver::Sample* rl, const fftconvolver::Sample* rr, int irLen)
{
    bool result = true;
    enchMutex.lock();
    convOLL->reset();
    convOLR->reset();
    convORL->reset();
    convORR->reset();

    convOLL->init(2048,ll,irLen);
    convOLR->init(2048,lr,irLen);
    convORL->init(2048,rl,irLen);
    convORR->init(2048,rr,irLen);
    enchMutex.unlock();
    return result;
}

compressor* _comp = new compressor();

void __stdcall set_cmp_param(float srate,float gate, float ratio, float attack, float release)
{
    _comp->setParam(srate, gate, ratio, attack, release);
}

bool _sr_bypass = false;

void __stdcall set_bypass(bool bypass)
{
    _sr_bypass = bypass;
}

void __stdcall set_master_gain(float gain)
{
    _comp->setMasterGain(gain);
}

bool initOneIr(const fftconvolver::Sample* ir, int frameCount, int chanCount, int chanOffset, FFTConvolver* target, fftconvolver::Sample* tempBuffer) {
    int i;
    chanOffset = 0;
    target = conv01;

    if (chanOffset >= chanCount) {
        chanOffset = 13 - chanOffset;
    }

    for (i = 0; i < frameCount; i++) {
        tempBuffer[i] = ir[i * chanCount + chanOffset];
    }

    target->reset();
    return target->init(2048, tempBuffer, frameCount);
}


float _rawMaxs[8];
float rawPeaks[8]; // out to the displayer

int ccd = 1000;
int cd = 1000;

int _channels = 8;

bool fc2f = false;

void __stdcall set_fc2f(bool val)
{
    fc2f = val;
}
float visualizerDownRate = 0.04f;

/// <summary>
/// 一站式处理所有的数据
/// 包含：卷积，增强，压缩
/// </summary>
/// <param name="input">指向原始的8通道音频数据的指针</param>
/// <param name="output">指向输出缓冲区的指针</param>
/// <param name="len">输入的音频帧长度（长度除以频道数量），不得超过48000</param>
/// <returns></returns>

void __stdcall pro_call(const fftconvolver::Sample* input, fftconvolver::Sample* output,fftconvolver::Sample* meters,int offset,int outOffset,int len)
{
    int i;
    int begin = offset;
    int end = offset + len * 8;
    int ptr = begin;
    // 拷贝数据
    for (i = 0; i < len; i++)
    {
        st1_FL_L[i] = input[ptr + 0];
        st1_FL_R[i] = input[ptr + 0];
        st1_FR_L[i] = input[ptr + 1];
        st1_FR_R[i] = input[ptr + 1];
        st1_FC_L[i] = input[ptr + 2];
        st1_FC_R[i] = input[ptr + 2];
        st1_LF_L[i] = input[ptr + 3];
        st1_LF_R[i] = input[ptr + 3];
        st1_RL_L[i] = input[ptr + 4];
        st1_RL_R[i] = input[ptr + 4];
        st1_RR_L[i] = input[ptr + 5];
        st1_RR_R[i] = input[ptr + 5];
        st1_SL_L[i] = input[ptr + 6];
        st1_SL_R[i] = input[ptr + 6];
        st1_SR_L[i] = input[ptr + 7];
        st1_SR_R[i] = input[ptr + 7];

        if (fc2f) {
            st1_FL_L[i] += st1_FC_L[i] * 0.75f;
            st1_FL_R[i] += st1_FC_L[i] * 0.75f;
            st1_FR_L[i] += st1_FC_L[i] * 0.75f;
            st1_FR_R[i] += st1_FC_L[i] * 0.75f;

            st1_FC_L[i] = 0;
            st1_FC_R[i] = 0;
        }

        for (int c = 0; c < _channels; c++)
        {
            float sample = input[ptr + c];
            if (_rawMaxs[c] < sample)
            {
                _rawMaxs[c] = sample;
            }

        }
        cd--;
        if (cd < 0)
        {
            cd = ccd;
            for (int c = 0; c < 8; c++)
            {
                rawPeaks[c] -= visualizerDownRate;
                if (rawPeaks[c] < _rawMaxs[c])
                {
                    rawPeaks[c] = _rawMaxs[c];
                    meters[c] = rawPeaks[c];
                }
                _rawMaxs[c] = 0;

            }
        }

        ptr += 8;
    }


    memset(st2_L, 0, len * sizeof(float));
    memset(st2_R, 0, len * sizeof(float));
    if (!_sr_bypass) {
        hrirMutex.lock();

        conv01->process(st1_FL_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv02->process(st1_FL_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv03->process(st1_FR_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv04->process(st1_FR_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv05->process(st1_FC_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv06->process(st1_FC_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv07->process(st1_LF_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv08->process(st1_LF_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv09->process(st1_RL_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv10->process(st1_RL_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv11->process(st1_RR_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv12->process(st1_RR_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv13->process(st1_SL_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv14->process(st1_SL_R, st1_R, len); sumData(st1_R, st2_R, len);
        conv15->process(st1_SR_L, st1_L, len); sumData(st1_L, st2_L, len);
        conv16->process(st1_SR_R, st1_R, len); sumData(st1_R, st2_R, len);

        hrirMutex.unlock();
    }
    // 目前st2 中是卷积后的数据

    enchMutex.lock();

    memset(st3_L, 0, len * sizeof(float));
    memset(st3_R, 0, len * sizeof(float));
    convOLL->process(st2_L, st1_L, len); sumData(st1_L, st3_L, len);
    convOLR->process(st2_L, st1_R, len); sumData(st1_R, st3_R, len);

    convORL->process(st2_R, st1_L, len); sumData(st1_L, st3_L, len);
    convORR->process(st2_R, st1_R, len); sumData(st1_R, st3_R, len);

    enchMutex.unlock();
    // 目前st3 中是音频增强后的数据
    // 拷贝到输出，然后做一下压缩

    for (i = 0; i < len; i++)
    {
        output[outOffset + i * 2] = st3_L[i];
        output[outOffset + i * 2+1] = st3_L[i+1];
    }

    _comp->process(output,outOffset, len * 2, meters);
}



void sumData(const fftconvolver::Sample* src,fftconvolver::Sample* dst, int len) {
    for (int i = 0; i < len; i++)
    {
        dst[i] += src[i];
    }
}