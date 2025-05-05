---
## 프로젝트 소개
<div align = left>
  
### Project : Cold Turkey <br>
### Duration : 2025.03.01 ~ 2025.03.03 <br>
### Genre : 시나리오 기반 판타지 약제 게임 <br>
이 프로젝트는 다양한 종족과 상호작용하며 약을 제조하는 판타지 세계를 배경으로 한 게임입니다. 플레이어는 정보를 수집하고, 각 종족의 특성을 고려하여 약을 조합하며, 선택에 따라 다양한 엔딩을 경험하게 됩니다.

---
## Video


---
## 기술 스택
[![My Skills](https://skillicons.dev/icons?i=cs,visualstudio,git,github,unity,notion&theme=light)](https://skillicons.dev)

---
## 게임 플레이 방식
1. 정보 수집 단계
각 스테이지에서 5개의 정보를 제공하며, 그 중 최소 2개를 확인해야 다음 단계로 진행할 수 있습니다.

모든 정보를 수집하면 진엔딩을 볼 수 있는 조건이 충족됩니다.

2. 약 제조 단계
재료 선택: 각 재료는 특정 종족에 대한 효과나 부작용이 있으며, 이를 고려하여 조합해야 합니다.

특수 능력 - 청원: 플레이어는 약 제조 시 '청원' 능력을 사용할 수 있으며, 이 능력을 사용한 약은 인간의 피가 흐르는 자에게만 효과적입니다.

독약: 특정 조합은 독약이 되어 대부분의 종족에게 치명적인 결과를 초래하며, 이는 배드 엔딩으로 이어집니다.

---
## 역할 분담 <br>
- GameManager, GameFlow, DialogSystem, CharacterAnimation : 김지호  / <br>
- Game Planning : 이수현 / <br>
- GameMode, Network, GameSession, Gameflow  : 유시아 / <br>
- PotionMakerSystem : 한가윤 / [개발블로그](https://yoosorang.tistory.com) [Git](https://github.com/swehio))<br>
- UIDesign, CharacterDesign,   :  /  <br>

---
## 폴더 구조 <br>
```plaintext
Assets/
├── Animations/         애니메이션 관련 파일
├── EditorAttributes/   에디터 커스터마이징 관련 설정
├── FontAsset/          폰트 에셋 관련 데이터
├── PSD/                PSD 이미지 및 리소스 폴더
├── Prefabs/            재사용 가능한 게임 오브젝트 프리팹
├── Resources/          Resources.Load()로 로딩 가능한 리소스
├── SOs/                ScriptableObject 관련 데이터
├── Scenes/             Unity 씬(.unity) 파일
├── Scripts/            게임 로직 및 시스템 스크립트
├── Settings/           게임 설정 및 컨피그 파일
├── Shaders/            셰이더 파일들
├── SharpUI/            UI 관련 스크립트 및 레이아웃
├── Test_Sia/           테스트용 기능 또는 예제 폴더
└── TextMesh Pro/       TextMesh Pro 관련 리소스
```
---
## 기술 의사결정 <br>
### 1. 응집도 높은 엔딩 분기 처리를 위한 Potion 설계
마을에서의 선택지 열람 여부와 약의 재료 조합에 따라 플레이어의 엔딩이 결정되는 시스템이 필요했습니다.  
이를 위해 다음과 같은 구조적 판단을 내렸습니다:

#### ▪️ 결정 사항
- **`Potion` 클래스 내부에 약의 상태 정보를 모두 포함**하도록 설계
  - 재료 배열 (`int[] ingredients`)
  - 주인공 능력 사용 여부 (`hasPower`)
  - 독약 여부 (`hasPoison`)
  - 제조된 스프라이트 정보 (`Sprite`)
- 이렇게 구성된 `Potion` 객체를 **최종 단계 (예: Result Scene)**에 전달하여  
  분기 조건 평가 및 결과 출력이 가능하도록 하였습니다.

#### ▪️ 목적 및 효과
- 엔딩 분기 조건 로직이 단일 객체(Potion)에 집약되어 있어 응집도와 가독성이 높음
- 유지보수 및 확장 시 `Potion` 객체만 다루면 되므로 유연한 게임 로직 확장 가능
---
## Trouble Shooting
### 1. Potion 데이터 전달 시 얕은 복사로 인한 데이터 손실
#### ▪️문제상황
`Submit()` 함수에서 `PotionData`를 `GameManager`에 전달하는 과정에서 얕은 복사(shallow copy) 문제가 발생했습니다.

이 방식은 `PotionData`의 참조만 전달하기 때문에, 이후 `currentPotion` 오브젝트가 `Destroy()`로 제거되면  
참조된 데이터까지 함께 소멸되거나 null로 초기화되어 `GameManager` 내부의 포션 정보가 손실되는 문제가 발생했습니다.

그 결과, 결과 계산 시 데이터 누락 현상이 발생했습니다.

#### ▪️해결 방법
깊은 복사(Deep Copy) 방식 적용

`Potion` 클래스에 깊은 복사를 수행할 수 있는 생성자를 추가하고, `SetPotion()` 호출 시 새로운 인스턴스를 복사하여 전달하도록 수정했습니다:

```csharp
// 깊은 복사로 안전하게 전달
GameManager.Instance.SetPotion(new Potion(PotionData));
```
### 2. Git 이름 변경으로 인한 코드 손실
#### ▪️문제상황
기획자분이 파일 이름을 변경한 뒤 Git에 푸시하는 과정에서  
기존 경로에 대한 참조가 끊기며 씬(Scene) 파일이 삭제되는 문제가 발생했습니다.

이로 인해 팀 프로젝트의 중요한 하나의 씬이 전체적으로 날아가는 상황이 벌어졌습니다.

#### ▪️해결 방법
- Git의 커밋 해시(commit hash)를 통해 해당 커밋으로 직접 진입  
- 문제 발생 직전 커밋으로 reset 및 되돌리기 작업 수행
- 씬 파일을 복구한 후, 실수로 올리려던 다이어로그 일부만 다시 생성하여 피해를 최소화하였습니다
