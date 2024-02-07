# SpartaUnity

# 개발 기간
- 2024년 2월 1일 ~ 2024년 2월 7일


# 개발 환경
- Unity v.2022.3.2.f1
- c#
- .NET 8.0


# 주요 기능
- 필수 기능
	* 캐릭터 정보
    * 이름
    * 정보
    * 등급
    * level
    * 경험치
    * 스탯
	* 스탯보기
  * 인벤토리
  * 장착기능

	

# 구성(gameObject and Cs)
	
- <메인화면> : MainScene
	* Main Camera
	* Player : 캐릭터 & 캐릭터 이름 표시
	* GameManager : 메인화면 버튼 선택에 따른 변화 제어
	* UI : UI bar, Character 변경 버튼 & UI창

	Folder(파일 설명)
  * Animations
    캐릭터 애니메이션 설정
	* Input
		Input system을 활용한 마우스 방향에 따라 캐릭터 회전(장착품 이슈로 인해 미적용)
	* Externals
		외부에서 받아온 파일들
	* Prefabs(not completed)
		별도로 object가 보이지는 않지만 공격 범위를 제공하기 위해 prefab 설정
	* Scriptable Object
    		Scriptable Object와 연관된 c# 파일과 데이터
	* Script
    		EuqipTool : 장착품 데이터 설정
    		EquipManager : 장착,해제에 따른 gameobject 관리
    		GameManager : 메인화면 버튼 등 관리
    		Inventory : 인벤토리 설정 및 버튼 제어
    		PlayerController : 본래 마우스 위치에 따른 캐릭터 제어(미적용)
    		PlayerInfo : player 모든 정보 관리(스탯 포함)
    
		
		
		
