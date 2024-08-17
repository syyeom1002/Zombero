# [Zombero Game Portfolio]


## 1. 프로젝트 소개

<div align="center">

  <img src="https://github.com/user-attachments/assets/7cd874bf-7f3b-4633-8c32-34ee0622d32c" width="30%" height="400"/>
  <img src="https://github.com/user-attachments/assets/a8469f01-1979-4cb5-90ef-543c7e1e0d42" width="30%" height="400"/>
  <img src="https://github.com/user-attachments/assets/88f2642e-693e-42f4-975c-eab6bc9261f5" width="30%" height="400"/>

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
| NavMeshAgent  | 보스가 플레이어 추격 |
| Prefab | Coroutine과 더불어 연속 총알 발사 구현 |
| trail renderer | 총알 궤적 구현 |

<br>


## 5. 핵심 기능


#### 플레이어 이동 및 공격
<img src="https://github.com/user-attachments/assets/11cc95ff-1e0a-41db-99a3-302b18869e95" width="49%" height="280"/>

+ 조이스틱으로 이동 가능
+ 이동을 멈추면 보스를 향해 총알 공격


#### 보스 이동
<div align="center">

  <img src="https://github.com/user-attachments/assets/0c9152d7-3a7b-4341-8474-9505adc12a4f" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/2dad20b5-6b8c-481f-a554-48394df6d80d" width="49%" height="280"/>

</div>

+ 보스의 상태는 총 5가지 - 기본/ 이동/ 원거리 공격/ 근거리 공격/ 죽음
+ 플레이어가 추격 반경(30.0f) 내에 있으면 계속 플레이어를 향해 이동


#### 보스 공격
<div align="center">

  <img src="https://github.com/user-attachments/assets/e561759c-4568-4fc2-9fe4-ba2b972b0adb" width="49%" height="280"/>
  <img src="https://github.com/user-attachments/assets/a9fb460c-7c83-4f43-928b-f6cc181c6bed" width="49%" height="280"/>

</div>

+ 원거리 공격 : 플레이어가 원거리 공격 반경(10.0f) 안에 있으면 공을 던져 공격
+ 근접 공격 : 플레이어가 근거리 공격 반경(4.0f) 안에 있으면 도끼로 찍으며 공격


<br>


## 7. 티스토리 개발일지
+ https://syyeom1002.tistory.com/category/3D%20%EC%BD%98%ED%85%90%EC%B8%A0%20%EC%A0%9C%EC%9E%91


## 8. 플레이 영상
+ https://youtube.com/shorts/LLbA0BCrMRs

---
