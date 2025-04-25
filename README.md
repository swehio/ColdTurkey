---
## 프로젝트 소개
<div align = left>
  
### Project : Cold Turkey <br>
### Duration : 2025.03.01 ~ 2025.03.03 <br>
### Genre : Conversation-based Simulated Drug Manufacturing Game <br>

---
## Video


---
## 기술 스택
[![My Skills](https://skillicons.dev/icons?i=cs,visualstudio,git,github,unity,notion&theme=light)](https://skillicons.dev)

---
## 목적
- 객체지향과 디자인패턴을 의미있게 적용
- 원활환 협업을 위한 Wiki 작성된 깃 컨벤션 및 코드컨벤션 적용
- 템플릿을 활용하여 블루프린트, C++ 을 이용해 게임확장
- GameSession, RPC, Replecates를 이용하여 Network 환경조성 
- 멀티플레이 환경에서 작동하기 위해 게임 최적화 적용
- 유효성검사 및 로깅을 통한 유지보수성 및 안정성을 향상시킨 코드 및 블루프린트 작성

---
### Desctiption Part / Email or Blog Link <br>
- MultiPlayGame like HyperActionFight 
- Direction, Network, UI, Gameflow, Optimization : 지성현 /  <br>
- Character, Animation, SkillSystem : 정우영  /  [개발블로그](https://velog.io/@buu1147/2025-04-18-KPT%ED%9A%8C%EA%B3%A0)<br>
- Character, Animation, SkillSystem : 정혜창 / [개발블로그](https://velog.io/@hch9097/posts)<br>
- GameMode, Network, GameSession, Gameflow  : 최원석 /  [개발블로그](https://onestone13.tistory.com/)<br>
- UI, Weapon, Character, Movie, SkillSystem  : 한가윤 / [개발블로그](https://yoosorang.tistory.com) [Git](https://github.com/swehio))<br>
- UI, ShopSystem, EconomySystem  : 최세훈 /  <br>

---
## Project Part Directory And Main Features <br>
<details>
  <summary> Network GameSession </summary>
  
    | -- Source
      | -- GameMode
        | -- MainLobyGameMode // 클라이언트가 닉네임과, 사용할 케릭터를 선택할 수 있다.
        | -- GFBaseGameMode // 모든 플레이어가 선택을 완료 할 경우 다음 레벨로 전환한다.
      | -- Actor
- C++ 기반의 플레이어 로직 설계
  - Enhanced Input System을 사용한 입력 액션
  - CharacterMovement Component을 사용한 캐릭터 로직 설계
  - Tick을 사용하지 않은 이벤트 기반의 플레이어 로직 구현
  - GameInstance와 연동한 레벨 전환시 플레이어 정보 저장/불러오기 기능
</details>

<details>
  <summary> Character </summary>
  
        | -- Character
          | -- BP_MainCharacter // 케릭터가 멀티플레이어를 하기 위한 구조를 갖춘 기본 클래스
            | -- CBP_Default // 케릭터가 멀티플레이어 이후 애니메이션을 적용하기 위한 자료를 가지고 있는 클래스
              | -- ABP_Default // Locomotion과 타격 애니메이션이 들어있는 애니메이션 블루프린트
              | -- CBP_Night  //  리타겟한 스켈레탈이 보이는 케릭터
              | -- CBP_Archer  //  리타겟한 스켈레탈이 보이는 케릭터
              | -- CBP_Berserker //  리타겟한 스켈레탈이 보이는 케릭터
              | -- CBP_Magiction //  리타겟한 스켈레탈이 보이는 케릭터
</details>

<details>
  <summary> GameMode </summary> 

        | -- GameMode  
          | -- GFBaseGameMode  
            | -- GF_FFAGameMode // 개인전 (FFA) 모드  
            | -- GFStoreGameMode // 상점에서 아이템을 구매하는 스토어 모드  
            | -- BP_GM_Multiplayer (Blueprint) // 멀티플레이어용 기본 블루프린트 GameMode  
              | -- BP_GF_DOM_Multiplayer (Blueprint) // 점령전 (DOM, Domination) 모드  
              | -- BP_GF_TDM_Multiplayer (Blueprint) // 팀 데스매치 (TDM, Team Deathmatch) 모드  

- 팀전 모드를 템플릿을 기준으로 팀전 로직을 제거한 개인전 모드(FFA)를 별도로 제작하여 재사용성을 높임.
- 게임 모드를 개인전과 팀전 모드로 나누고, 추가 모드를 쉽게 확장할 수 있도록 설계함.
- 최상위에는 GFBaseGameMode를 두고, 레벨 전환과 플레이어 준비 완료 체크 등 공통 로직을 구현하여 중복을 제거.
</details>

<details>
  <summary> Weapon </summary>
  
          | -- WeaponBase // 근접 무기에 메쉬와 로직을 담는 클래스     
              | -- TowHandedSword // 양손검
              | -- SwordAndShield // 검과 방패
          | -- RangeWeaponBase // 원거리 무기 메쉬와 로직을 담는 클래스
              | -- MagicBook // 마법책
              | -- Bow // 활
          | -- SkillBase // 콜리전과 이펙트를 가진 클래스
              | -- VFX // 이펙트만 소유한 클래스 (제거 및 변경을 원하랗게 하기 위해서)     
</details>

<details>
  <summary> Animation </summary>
### Animation
</details>

<details>
  <summary> Shop </summary>
### Shop
</details>

<details>
  <summary> UI </summary>
### UI
</details>

<details>
  <summary> SkillCoolTime </summary>
### SkillCoolTime
</details>

---
## 개발 환경 / 개발 도구
- C++ 17 (v14.38)
- MSVC v143
- Unreal Engine 5.5
- Visual Studio 2022
- Git LFS
- Rider
</div>

---
## Network GameSession
<details>
<summary>Network GameSession UML Diagram</summary>    

</details>

## Character
<details>
<summary>Character UML Class Diagram</summary>
</details>

## GameMode
<details>
<summary>GameMode UML Class Diagram</summary>
</details>

## Weapon
<details>
<summary>Weapon UML Class Diagram</summary>
</details>

## Animation
<details>
<summary>Animation UML Class Diagram</summary>
</details>

## Shop
<details>
<summary>Shop UML Class Diagram</summary>
</details>

## UI
<details>
<summary>UI UML Class Diagram</summary>
</details>
