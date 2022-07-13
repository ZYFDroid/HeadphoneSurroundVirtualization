// pch.cpp: 与预编译标头对应的源文件

#include "pch.h"
using namespace fftconvolver;

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

Sample* st2_L = NULL;
Sample* st2_R = NULL;

Sample* st3_L = NULL;
Sample* st3_R = NULL;


bool __stdcall con01_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv01->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con01_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv01->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con01_reset()
{
    conv01->reset();
}
bool __stdcall con02_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv02->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con02_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv02->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con02_reset()
{
    conv02->reset();
}
bool __stdcall con03_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv03->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con03_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv03->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con03_reset()
{
    conv03->reset();
}
bool __stdcall con04_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv04->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con04_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv04->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con04_reset()
{
    conv04->reset();
}
bool __stdcall con05_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv05->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con05_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv05->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con05_reset()
{
    conv05->reset();
}
bool __stdcall con06_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv06->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con06_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv06->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con06_reset()
{
    conv06->reset();
}
bool __stdcall con07_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv07->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con07_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv07->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con07_reset()
{
    conv07->reset();
}
bool __stdcall con08_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv08->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con08_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv08->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con08_reset()
{
    conv08->reset();
}
bool __stdcall con09_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv09->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con09_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv09->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con09_reset()
{
    conv09->reset();
}
bool __stdcall con10_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv10->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con10_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv10->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con10_reset()
{
    conv10->reset();
}
bool __stdcall con11_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv11->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con11_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv11->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con11_reset()
{
    conv11->reset();
}
bool __stdcall con12_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv12->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con12_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv12->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con12_reset()
{
    conv12->reset();
}
bool __stdcall con13_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv13->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con13_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv13->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con13_reset()
{
    conv13->reset();
}
bool __stdcall con14_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv14->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con14_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv14->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con14_reset()
{
    conv14->reset();
}
bool __stdcall con15_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv15->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con15_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv15->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con15_reset()
{
    conv15->reset();
}
bool __stdcall con16_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return conv16->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall con16_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    conv16->process(input, (Sample*)output, (size_t)len);
}

void __stdcall con16_reset()
{
    conv16->reset();
}
// begin of stage2
bool __stdcall conOLL_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return convOLL->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall conOLL_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    convOLL->process(input, (Sample*)output, (size_t)len);
}

void __stdcall conOLL_reset()
{
    convOLL->reset();
}

bool __stdcall conOLR_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return convOLR->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall conOLR_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    convOLR->process(input, (Sample*)output, (size_t)len);
}

void __stdcall conOLR_reset()
{
    convOLR->reset();
}




bool __stdcall conORL_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return convORL->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall conORL_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    convORL->process(input, (Sample*)output, (size_t)len);
}

void __stdcall conORL_reset()
{
    convORL->reset();
}

bool __stdcall conORR_init(int blockSize, const fftconvolver::Sample* ir, int irLen)
{
    return convORR->init((size_t)blockSize, ir, (size_t)irLen);
}

void __stdcall conORR_process(const fftconvolver::Sample* input, const fftconvolver::Sample* output, int len)
{
    convORR->process(input, (Sample*)output, (size_t)len);
}

void __stdcall conORR_reset()
{
    convORR->reset();
}


bool __stdcall init_mem()
{
    bool result = true;

    result &= (st1_FL_L = (fftconvolver::Sample *)malloc(sizeof(float) * 48000)) != 0;

    return result;
}