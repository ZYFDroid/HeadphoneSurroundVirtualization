// pch.h: 这是预编译标头文件。
// 下方列出的文件仅编译一次，提高了将来生成的生成性能。
// 这还将影响 IntelliSense 性能，包括代码完成和许多代码浏览功能。
// 但是，如果此处列出的文件中的任何一个在生成之间有更新，它们全部都将被重新编译。
// 请勿在此处添加要频繁更新的文件，这将使得性能优势无效。

#ifndef PCH_H
#define PCH_H

#define METER_UPDATE_SAMPLES 1000
#define METER_DECAY_RATE 0.04f

#include <iostream>

#include <mutex>

// 添加要在此处预编译的标头
#include "framework.h"
#include "src/AudioFFT.h"
#include "src/FFTConvolver.h"
#include "src/TwoStageFFTConvolver.h"
#include "src/Utilities.h"
#include "math_helper.h"
#include "compressor.h"

#endif //PCH_H


#ifdef IMPORT_DLL
#else
#define IMPORT_DLL extern "C" _declspec(dllimport) //指的是允许将其给外部调用
#endif

IMPORT_DLL bool __stdcall init_mem();
IMPORT_DLL bool __stdcall set_sr_ir(const fftconvolver::Sample* ir, int irLen, int chanCount);
IMPORT_DLL bool __stdcall set_en_ir(const fftconvolver::Sample* ll, const fftconvolver::Sample* lr, const fftconvolver::Sample* rl, const fftconvolver::Sample* rr, int irLen);
IMPORT_DLL void __stdcall set_cmp_param(float srate,float gate,float ratio,float attack,float release);
IMPORT_DLL void __stdcall set_bypass(bool bypass);
IMPORT_DLL void __stdcall set_fc2f(bool fc2f);
IMPORT_DLL void __stdcall set_master_gain(float gain);
IMPORT_DLL void __stdcall pro_call(const fftconvolver::Sample* input,  fftconvolver::Sample* output, fftconvolver::Sample* meters, int offset,int outOffset, int len);

bool initOneIr(const fftconvolver::Sample* ir, int frameCount, int chanCount, int chanOffset, fftconvolver::FFTConvolver* target, fftconvolver::Sample* tempBuffer);
