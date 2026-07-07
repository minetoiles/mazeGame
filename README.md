# mazeGame

Unity로 제작한 3D 미로 탈출 게임입니다. 플레이어는 미로 안에서 아이템(기어)을 모으고, 적을 피해 출구 깃발에 도달해야 합니다.

## 개발 환경

- Unity 6000.0.56f1
- 렌더 파이프라인: URP
- 빌드 타겟: WebGL

## 조작 방법

| 키 | 동작 |
| --- | --- |
| ↑ / ↓ | 전진 / 후진 |
| ← / → | 좌우 90도 회전 |

## 씬 구성

- `StartScene` : 시작 화면
- `SelectScene` : 맵 선택 화면
- `guide`, `guide_case` : 안내 화면
- `MazeScene`, `MazeMap1Scene`, `MazeMap3Scene`, `MazeFollow1Scene`, `MazeFollow3Scene` : 미로 플레이 씬
- `ClearScene` : 클리어 화면
- `check` : 테스트용 씬

## 주요 스크립트 (`Assets/Scripts`)

- `Player/PlayerControl.cs` : 플레이어 이동 및 회전 처리
- `Player/PlayerCollision.cs` : 플레이어 충돌 처리
- `Enemy/` : 적 AI 및 기믹(회전 기어 등) 제어
- `Guider/` : 안내자(가이드) 동작 및 등장 트리거
- `Trigger/EndFlag.cs` : 미로 클리어 트리거, 클리어 씬 전환
- `item_get.cs`, `Map.cs` : 아이템 획득 및 맵 진행 상태 관리
- `Scene/SceneChanger.cs` : 씬 전환 공통 처리

## 프로젝트 열기

1. Unity Hub에서 Unity 6000.0.56f1 버전을 설치합니다.
2. Unity Hub의 `Open` 기능으로 이 저장소 폴더를 엽니다.
3. `Assets/Scenes/StartScene.unity`를 실행하여 플레이합니다.
