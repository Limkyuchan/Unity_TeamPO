using UnityEngine;

public interface ICharacterAI
{
    void EnterState();  // 상태 전환 시 초기화 작업

    void Execute();     // 상태 실행

    void ExitState();   // 상태 종료 시 처리 작업
}