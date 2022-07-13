#include "math_helper.h"

float mh::linear2db(float linear)
{
	//return (float)(20.0 * Math.Log10(x / 1.0));
	return (float)(20.0 * log10(linear / 1.0));
}

float mh::db2linear(float db)
{
	// return (float) Math.Pow(10d, dB / 20.0);
	return (float)pow(10, db / 20.0);
}
