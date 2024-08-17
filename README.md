# [Zombero Game Portfolio]


## 1. 프로젝트 소개

<div align="center">

  <img src="https://github.com/user-attachments/assets/bbf87c18-8bb5-4f78-8f3b-89815df475c1" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/a0516eea-442e-41ec-bed1-6819eab7db4c" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/0a0f3334-245d-4794-94d4-1f2665892f00" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/cdb9eb56-9511-4ea5-b8d5-fc3420dbd165" width="49%" height="280"/>

  < 게임 플레이 사진 >

</div>

> + 총 7일 동안 제작한 zombero:Hero Shooter  게임의 모작입니다.
> 
> + 개인 프로젝트
> 
> + 개발기간: 2023.10.04 ~ 2023.10.11 (총 7일)


<br>

## 2. 개발 환경

+ 개발 엔진 : Unity 3D

+ 언어 : C#

+ 형상 관리: SVN

<br>

## 3. 사용 기술
| 기술 | 설명 |
|:---:|:---|
| Nav | 보스가 플레이어 추격 |
| 프리팹 | 총알 발사 |
| 대리자 | 이벤트 전달 |
| mathf 클래스 | 조이스틱으로 이동 구현 |
| trail renderer | 총알 궤적 |
| enum | 방패 회전 구현 |
| Event Wrapper | 스페이스 스톤 획득 시 씬 전환 이벤트 처리 |

<br>


## 5. 핵심 기능


#### 캐릭터 선택
<img src="https://github.com/user-attachments/assets/11cc95ff-1e0a-41db-99a3-302b18869e95" width="49%" height="280"/>

+ Controller의 Thumbstick 으로 좌우 이동
+ Controller의 A버튼 클릭하면 캐릭터 선택 완료, 게임씬으로 전환


#### 이동 시스템
<div align="center">

  <img src="https://github.com/user-attachments/assets/0c9152d7-3a7b-4341-8474-9505adc12a4f" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/2dad20b5-6b8c-481f-a554-48394df6d80d" width="49%" height="280"/>

</div>

+ 자동 이동
+ Leap : Contoller의 A 버튼을 이용하여 이동 가능


#### 공격
<div align="center">

  <img src="https://github.com/user-attachments/assets/e561759c-4568-4fc2-9fe4-ba2b972b0adb" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/a9fb460c-7c83-4f43-928b-f6cc181c6bed" width="49%" height="280"/>

</div>

+ 방패 던지기 : Controller의 HandTrigger버튼으로 조작 가능
+ 방패 찍기 : Controller의 IndexTrigger 버튼으로 조작 가능


#### 적
<div align="center">

  <img src="https://github.com/user-attachments/assets/681a87de-7626-4a73-904e-093a1984104b" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/e2b303b9-a74e-4939-9d5d-6e0f50b46941" width="49%" height="280"/>

</div>

+ 공중적- 레이저 공격
+ 지상적- 총알 공격 , 순간 빠른 속도로 이동


#### 엔딩
<img src="https://github.com/user-attachments/assets/04ec79d1-8c07-4b55-b1f4-5a899eb42117" width="49%" height="280"/>

+ 모든 적을 물리치면 생성
+ 스페이스 스톤 획득 시 씬 전환, 다음 스테이지 잠금 해제 

<br>


## 7. 티스토리 개발일지
+ https://syyeom1002.tistory.com/category/3D%20%EC%BD%98%ED%85%90%EC%B8%A0%20%EC%A0%9C%EC%9E%91


## 8. 플레이 영상
+ https://www.youtube.com/watch?v=FLcZElzEC0A&t

---
