# bgwait

bgwait�R�}���h�́Aunix �V�F���� wait�R�}���h�̂悤�ȓ��������܂��B  

## �g����

a.bat �� b.bat �� c.bat  �����Ŏ��s���A�S�Ă̎��s���I�������� d.bat �����s�������B  

�ȉ��̗�ł́Aa.bat b.bat c.bat ���o�b�N�O���E���h�ŋN���� d.bat ���N�����Ă��܂��B  
a.bat b.bat c.bat ���ꂼ��̎��s�I����҂����� d.bat �����s����邱�ƂɂȂ�܂��B
    @echo off
    start a.bat
    start b.bat
    start c.bat
    rem -- 
    call d.bat

bgwait�R�}���h���g���� a.bat b.bat c.bat ���I������܂� d.bat �̎��s���s���܂���B
    @echo off
    start a.bat
    start b.bat
    start c.bat
    rem -- wait a.bat,b.bat,c.bat
    bgwait
    call d.bat
	
## ���s���̐���

bgwait�R�}���h�́A�����̐e�v���Z�X�Ɠ����e�v���Z�XID�����v���Z�X��WMI���g����10�b�Ԋu�ŊĎ����܂��B �o�b�N�O���E���h���s�������v���O������10�b�ȓ��ɏI�����Ă��Ă�bgwait�R�}���h�̏I���܂ōő�10�b�҂�����邱�ƂɂȂ�܂��B
