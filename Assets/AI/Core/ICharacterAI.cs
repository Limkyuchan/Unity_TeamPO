using UnityEngine;

public interface ICharacterAI
{
    void EnterState();  // ���� ��ȯ �� �ʱ�ȭ �۾�

    void Execute();     // ���� ����

    void ExitState();   // ���� ���� �� ó�� �۾�
}