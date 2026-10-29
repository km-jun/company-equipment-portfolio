# 코드·DB 구성

## 코드 구성

| 경로 | 내용 |
|---|---|
| `project.sln` | Visual Studio 솔루션 |
| `project/DBClass.cs` | 공통 DB 연결·처리 모듈 |
| `project/main.cs` | 지급·회수, 상태 관리 화면과 처리 로직 |
| `project/Serch.cs` | 검색 조건 선택 및 메인 화면 전달 |
| `project/soldier.cs` | 병력 정보 관리 |
| `project/equipment.cs` | 장비 정보 관리 |
| `project/infomation.cs` | 장비 현황 조회 |
| `pro3.sql` | 테이블·VIEW 정의와 공개용 가상 데이터 |

## DB 구성

`rank`, `position`, `equipment`, `soldier`, `issue_history`, `transaction_history` 테이블과 조회용 VIEW 3개로 구성됩니다. 병력과 장비를 지급·회수 이력 테이블에서 참조합니다.

[README로 돌아가기](../README.md)
