//********************************************************************************************************************
// �^�C�g��:		�J��������
// �v���O������:	camera.h
//********************************************************************************************************************
#ifndef _CAMERA_H_
#define _CAMERA_H_

//********************************************************************************************************************
// �C���N���[�h�t�@�C��
//********************************************************************************************************************
#include "main.h"

//********************************************************************************************************************
// �N���X
//********************************************************************************************************************
// �J�����N���X
class CCamera
{
public:
	CCamera();							// �R���X�g���N�^
	~CCamera();							// �f�X�g���N�^
	HRESULT Init(void);
	void Uninit(void);
	void Update(void);
	void Set(void);
private:
	D3DXMATRIX m_mtxProjection;	// �v���W�F�N�V�����}�g���b�N�X
	D3DXMATRIX m_mtxView;		// �r���[�}�g���b�N�X

	D3DXVECTOR3 m_posV;			// ���_
	D3DXVECTOR3 m_posR;			// �����_
	D3DXVECTOR3 m_vecU;			// ������x�N�g��
	D3DXVECTOR3	m_posVDest;		// ���_�̖ړI�ʒu
	D3DXVECTOR3	m_posRDest;		// �����_�̖ړI�ʒu
	D3DXVECTOR3 m_vecVR;		// ���_���璍���_�����ւ̒P�ʃx�N�g��
	D3DXVECTOR3 m_vecVerToVR;	// �x�N�g��VR�ɐ����ȒP�ʃx�N�g��
	D3DXVECTOR3 m_rot;			// �����i��]�p�j
	
	float m_fDistance;			// ���_�ƒ����_�̋���
	float m_fDistanceXZ;
	float m_fInitialDistance;	// �n�߂̎��_�ƒ����_�̋���
	float m_fInitialSin;
	float m_fInitialCos;
};

#endif