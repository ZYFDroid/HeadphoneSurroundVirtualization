#pragma once


namespace ap {
	class compressor
	{
	public:
		/// <summary>
		/// 设置压缩器参数
		/// </summary>
		/// <param name="srate">压缩器采样率</param>
		/// <param name="gate">噪音门限</param>
		/// <param name="ratio">压缩比</param>
		/// <param name="attack">启动时间</param>
		/// <param name="release">释放时间</param>
		void setParam(float srate,float gate, float ratio, float attack, float release);

		/// <summary>
		/// 处理一次
		/// </summary>
		/// <param name="data">立体声数据</param>
		/// <param name="len">数据的长度</param>
		/// <param name="display">用于显示仪表盘的数组指针</param>
		/// <returns></returns>
		void process(float* data,int outOffset, int len, float* display);
		/// <summary>
		/// 设置总增益
		/// </summary>
		/// <param name="mastergain">总增益</param>
		void setMasterGain(float mastergain);

	private:
		float visualizerDownRate = 0.04f;
		float _currentGain = 0.0f;
		float _compressorGain = 0.0f;
		float _MininumGain = 0.0f;
		float _gainAttackRate = 0.0f;
		float _gainDecayRate = 0.0f;
		float _gate = 0.0f;
		int _decayCd = 0;
		int _decayCds = 100;
		float _gain = 1.0f;

		float _maxLeft = 0.0f;
		float _maxRight = 0.0f;


		float outLeft = 0.0f;
		float outRight = 0.0f;

		int cd = 500;
		int ccd = 1000;
	};
}

