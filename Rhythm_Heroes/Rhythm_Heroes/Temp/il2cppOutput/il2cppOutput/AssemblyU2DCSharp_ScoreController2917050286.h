﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// UnityEngine.UI.Text
struct Text_t3286458198;

#include "UnityEngine_UnityEngine_MonoBehaviour3012272455.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ScoreController
struct  ScoreController_t2917050286  : public MonoBehaviour_t3012272455
{
public:
	// UnityEngine.UI.Text ScoreController::scoreText
	Text_t3286458198 * ___scoreText_2;
	// UnityEngine.UI.Text ScoreController::wordText
	Text_t3286458198 * ___wordText_3;
	// System.Single ScoreController::scoreCount
	float ___scoreCount_4;

public:
	inline static int32_t get_offset_of_scoreText_2() { return static_cast<int32_t>(offsetof(ScoreController_t2917050286, ___scoreText_2)); }
	inline Text_t3286458198 * get_scoreText_2() const { return ___scoreText_2; }
	inline Text_t3286458198 ** get_address_of_scoreText_2() { return &___scoreText_2; }
	inline void set_scoreText_2(Text_t3286458198 * value)
	{
		___scoreText_2 = value;
		Il2CppCodeGenWriteBarrier(&___scoreText_2, value);
	}

	inline static int32_t get_offset_of_wordText_3() { return static_cast<int32_t>(offsetof(ScoreController_t2917050286, ___wordText_3)); }
	inline Text_t3286458198 * get_wordText_3() const { return ___wordText_3; }
	inline Text_t3286458198 ** get_address_of_wordText_3() { return &___wordText_3; }
	inline void set_wordText_3(Text_t3286458198 * value)
	{
		___wordText_3 = value;
		Il2CppCodeGenWriteBarrier(&___wordText_3, value);
	}

	inline static int32_t get_offset_of_scoreCount_4() { return static_cast<int32_t>(offsetof(ScoreController_t2917050286, ___scoreCount_4)); }
	inline float get_scoreCount_4() const { return ___scoreCount_4; }
	inline float* get_address_of_scoreCount_4() { return &___scoreCount_4; }
	inline void set_scoreCount_4(float value)
	{
		___scoreCount_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif