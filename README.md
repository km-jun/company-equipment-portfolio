# 중대 장비 관리 시스템

C# WinForms와 Oracle DB를 사용해 병력·장비 정보, 장비 지급·회수 및 정비 상태를 관리하는 데이터베이스 프로그래밍 수업 팀 프로젝트입니다.

- **개발 기간:** 2025.09~2025.12
- **프로젝트 형태:** 2인 팀 프로젝트
- **공개 버전:** 기존 비공개 저장소의 최신 코드를 바탕으로 2026년 10월에 정리했습니다. 새 저장소의 커밋 날짜는 원래 개발 날짜와 다릅니다.
- **본인 참여 범위:** 이력서에는 DB 설계 및 검색 기능 개발 참여로 정리했습니다. 세부 역할은 당시 자료와 코드를 대조해 확인 중이며, 전체 기능을 단독 구현한 프로젝트가 아닙니다.

## 주요 기능

- 병력·장비 기본 정보 등록, 수정, 삭제
- 장비 지급·회수 처리 및 이력 조회
- 장비 상태와 재고 관리, 수리 완료 처리
- 병력·장비 조건 검색과 메인 화면 연동
- 장비 현황·가용률 조회

## 사용 기술

| 구분 | 기술 |
|---|---|
| 언어·UI | C#, Windows Forms |
| 실행 환경 | .NET Framework 4.8, Windows |
| 데이터베이스 | Oracle DB, SQL |
| DB 연결 | ODP.NET `Oracle.DataAccess` |

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

## 로컬 실행 준비

1. Windows에서 Visual Studio와 .NET Framework 4.8 개발 도구를 준비합니다.
2. Oracle DB와 프로젝트에 맞는 ODP.NET을 설치합니다. 기존 프로젝트는 `Oracle.DataAccess` 4.112.2.0 참조를 사용합니다. `project.csproj`의 `HintPath`를 설치한 DLL 경로에 맞춰 수정하고, 애플리케이션과 Oracle 클라이언트의 비트 수를 맞춥니다. 기존 Debug 설정은 x64입니다.
3. 별도의 테스트용 DB 계정을 준비하고, 그 계정으로 `pro3.sql`을 실행합니다. 이 파일은 기존 동명 테이블과 VIEW를 삭제하므로 실제 데이터가 있는 스키마에 실행하면 안 됩니다. SQL 파일은 UTF-8입니다.
4. Windows의 사용자 환경변수 설정에서 `EQUIPMENT_DB_CONNECTION_STRING`을 등록합니다. 접속 문자열 형식은 다음과 같습니다. 대괄호 부분은 자신의 로컬 설정으로 교체하고 실제 접속 정보는 저장소에 올리지 않습니다.

```text
User Id=[LOCAL_DB_USER];Password=[LOCAL_DB_PASSWORD];Data Source=[LOCAL_DB_ALIAS];
```

5. 환경변수를 설정한 뒤 Visual Studio를 다시 열어 `project.sln`을 빌드하고 실행합니다.

원본의 기능 코드를 보존한 공개용 자료입니다. 이번 공개 준비 과정에서 Windows·Oracle 환경의 빌드 및 실제 실행은 재검증하지 않았습니다.

## 공개용 정리 내역

- 원본 비밀번호와 DB 계정 생성 스크립트를 포함하지 않았습니다. 애플리케이션은 환경변수로 접속 정보를 받습니다.
- 보고서·발표자료, 원본 모델 파일, 압축파일은 포함하지 않았습니다.
- SQL의 병력 식별번호·인명·소속과 장비 예제 데이터를 공개용 가상 데이터로 교체했습니다.
- 원본 저장소의 과거 커밋, PR, 이슈를 가져오지 않았습니다.
- 테이블·VIEW 구조, 폼과 UI 리소스, 주요 애플리케이션 로직은 보존했습니다.
