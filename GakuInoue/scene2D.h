//********************************************************************************************************************
// �^�C�g��:		�V�[������
// �v���O������:	scene2D.h
//********************************************************************************************************************
#ifndef _SCENE2D_H_
#define _SCENE2D_H_

//********************************************************************************************************************
// �C���N���[�h�t�@�C��
//********************************************************************************************************************
#include "main.h"
#include "scene.h"

//********************************************************************************************************************
// �N���X
//********************************************************************************************************************
// �V�[���N���X
class CScene2D : public CScene
{
public:
	CScene2D();								// �R���X�g���N�^
	~CScene2D();							// �f�X�g���N�^
	static CScene2D* Create(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	HRESULT Init(void);
	HRESULT Init(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	void Uninit(void);
	void Update(void);
	void Draw(void);
	void BindTexture(LPDIRECT3DTEXTURE9 pTexture);

	void			SetVtxBuff(void);
	D3DXVECTOR3		GetPos(void);
	void			SetPos(D3DXVECTOR3 pos);
	void			SetUV(D3DXVECTOR2* pUV);

private:
	LPDIRECT3DTEXTURE9		m_pTexture;		// �e�N�X�`���ւ̃|�C���^
	LPDIRECT3DVERTEXBUFFER9 m_pVtxBuff;		// ���_�o�b�t�@�ւ̃|�C���^
	bool					m_bLoadTexture;	// �e�N�X�`�����ǂݍ��܂ꂽ���ǂ���
	D3DXVECTOR3				m_pos;			// �|���S���̈ʒu
	D3DXVECTOR2				m_uv[4];		// �S���_��UV���W
};

#endif
