// pch.h: 这是预编译标头文件。
// 下方列出的文件仅编译一次，提高了将来生成的生成性能。
// 这还将影响 IntelliSense 性能，包括代码完成和许多代码浏览功能。
// 但是，如果此处列出的文件中的任何一个在生成之间有更新，它们全部都将被重新编译。
// 请勿在此处添加要频繁更新的文件，这将使得性能优势无效。

#ifndef PCH_H
#define PCH_H

#include <iostream>


// 添加要在此处预编译的标头
#include "framework.h"
#include "src/AudioFFT.h"
#include "src/FFTConvolver.h"
#include "src/TwoStageFFTConvolver.h"
#include "src/Utilities.h"

#endif //PCH_H


#ifdef IMPORT_DLL
#else
#define IMPORT_DLL extern "C" _declspec(dllimport) //指的是允许将其给外部调用
#endif

IMPORT_DLL bool __stdcall con01_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con01_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con01_reset();
IMPORT_DLL bool __stdcall con02_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con02_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con02_reset();
IMPORT_DLL bool __stdcall con03_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con03_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con03_reset();
IMPORT_DLL bool __stdcall con04_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con04_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con04_reset();
IMPORT_DLL bool __stdcall con05_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con05_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con05_reset();
IMPORT_DLL bool __stdcall con06_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con06_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con06_reset();
IMPORT_DLL bool __stdcall con07_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con07_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con07_reset();
IMPORT_DLL bool __stdcall con08_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con08_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con08_reset();
IMPORT_DLL bool __stdcall con09_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con09_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con09_reset();
IMPORT_DLL bool __stdcall con10_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con10_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con10_reset();
IMPORT_DLL bool __stdcall con11_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con11_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con11_reset();
IMPORT_DLL bool __stdcall con12_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con12_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con12_reset();
IMPORT_DLL bool __stdcall con13_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con13_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con13_reset();
IMPORT_DLL bool __stdcall con14_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con14_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con14_reset();
IMPORT_DLL bool __stdcall con15_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con15_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con15_reset();
IMPORT_DLL bool __stdcall con16_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall con16_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall con16_reset();
IMPORT_DLL bool __stdcall conOLL_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall conOLL_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall conOLL_reset();
IMPORT_DLL bool __stdcall conORL_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall conORL_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall conORL_reset();

IMPORT_DLL bool __stdcall conOLR_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall conOLR_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall conOLR_reset();
IMPORT_DLL bool __stdcall conORR_init(int blockSize, const fftconvolver::Sample* ir, int irLen);
IMPORT_DLL void __stdcall conORR_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len);
IMPORT_DLL void __stdcall conORR_reset();


IMPORT_DLL bool __stdcall init_mem();



