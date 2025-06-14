# Metaverse-proj
메타버스를 활용한 게이미피케이션 개발 프로젝트</br>
📌 이 저장소는 전체 Unity 프로젝트 중,
제가 직접 구현한 주요 C# 스크립트를 정리한 저장소입니다.

전체 시연 영상 및 결과물은 👉 [노션 포트폴리오](https://magical-rate-172.notion.site/f8e63da57e584331b1801ceab078e089?pvs=74) 에서 확인하실 수 있습니다.

---

## 🎮 주요 기능

| 기능 | 설명 |
|------|------|
| 🧭 카메라 추적 | 플레이어를 따라다니는 부드러운 카메라 이동 및 회전 |
| 🪨 돌 선택 시스템 | 6개의 석기(돌) 중 하나를 선택하여 아이템 제작 |
| 🧰 인벤토리 UI | 각 아이템의 수량을 실시간으로 표시 |
| 🛠️ 아이템 제작 | 선택된 돌에 따라 전용 제작 UI 활성화 |
| 🧍 NPC 상호작용 및 퀘스트 | (향후 확장 가능) 대화 및 퀘스트 매니저와 연동 구조 존재 |
| 📜 스크롤 UI | 책 클릭 시 내용 스크롤, 완료 시 보상 처리 예정 |
| 🎮 조이스틱 | 이동 입력과 회전을 반영하는 고정형 조이스틱 시스템 |

---
## 📌 주요 스크립트 설명

### 🧭 FollowingCamera.cs
***플레이어를 따라 부드럽게 이동하며, 조이스틱 입력에 따라 카메라 회전 처리***
- `Lerp`, `Slerp`를 활용한 자연스러운 이동 및 회전
- `inven` 태그 존에 진입 시 조이스틱 비활성화 처리 포함

### 🧍 Player.cs
***플레이어 주변 상호작용 처리 (ex. 인벤토리 진입)***
- 현재 상호작용 대상 및 퀘스트 대상 오브젝트 관리
- `IsPlayerMaking` 상태를 통해 제작 중 여부 제어

### 🧠 Gamemanager.cs
***게임 내 상태와 UI 흐름을 총괄 제어하는 중앙 관리자***
- 돌 선택, 책 스크롤, 아이템 클릭 시 수량 증가 등의 이벤트 처리
- UI 조작(Scroll, Panel 등)을 위한 조건 분기 구조 포함

### 🧰 Inventory.cs
***플레이어가 선택한 돌에 따라 전용 제작 UI를 표시***
- 돌 선택 시 Enum 상태를 갱신하고 시각적 강조 처리
- 인벤토리 닫기 시 제작 상태 초기화 (`SetIsPlayerMaking(false)`)

### 📦 ItemScript.cs
***`Item` 객체 리스트를 관리하고 수량 증가/중복 처리***
- 최대 7개의 UI 텍스트 필드에 수량 정보를 출력
- `AddItem()`, `GetItems()`, `UpdateUI()` 계열 메서드 제공
