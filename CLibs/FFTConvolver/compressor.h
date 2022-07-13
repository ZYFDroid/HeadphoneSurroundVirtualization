#pragma once


namespace ap {
	class compressor
	{
	public:
		/// <summary>
		/// ����ѹ��������
		/// </summary>
		/// <param name="srate">ѹ����������</param>
		/// <param name="gate">��������</param>
		/// <param name="ratio">ѹ����</param>
		/// <param name="attack">����ʱ��</param>
		/// <param name="release">�ͷ�ʱ��</param>
		void setParam(float srate,float gate, float ratio, float attack, float release);

		/// <summary>
		/// ����һ��
		/// </summary>
		/// <param name="data">����������</param>
		/// <param name="len">���ݵĳ���</param>
		/// <param name="display">������ʾ�Ǳ��̵�����ָ��</param>
		/// <returns></returns>
		void process(float* data,int outOffset, int len, float* display);
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="mastergain">������</param>
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

