# 중대 장비 관리 시스템

병력·장비 정보를 등록하고, 장비 지급·회수와 정비 이력을 관리하는 Windows 데스크톱 프로그램입니다.

데이터베이스 프로그래밍 수업 팀 프로젝트로 개발했습니다. 팀원 공동 작업물이 포함된 공개용 저장소입니다.

- **개발 기간:** 2025.09~2025.12
- **팀 구성:** 학생 2명
- **담당 역할:** DB 설계 및 검색 기능 개발 참여

## 주요 사용 기술

C#, WinForms(.NET Framework 4.8), Oracle DB

## 주요 기능

- 병력·장비 기본 정보 등록, 수정, 삭제
- 장비 지급·회수 처리 및 이력 조회
- 장비 상태와 재고 관리, 수리 완료 처리
- 병력·장비 조건 검색과 메인 화면 연동
- 장비 현황·가용률 조회

## 로컬 실행

Windows, Visual Studio, .NET Framework 4.8 개발 도구와 Oracle DB·ODP.NET이 필요합니다.

```bash
git clone https://github.com/km-jun/company-equipment-portfolio.git
cd company-equipment-portfolio
```

1. 별도의 테스트용 DB 계정에서 `pro3.sql`을 실행합니다. 기존 동명 테이블과 VIEW를 삭제하므로 실제 데이터가 있는 스키마에서는 실행하지 않습니다.
2. 환경변수 `EQUIPMENT_DB_CONNECTION_STRING`에 DB 접속 정보를 설정합니다.
3. Visual Studio에서 `project.sln`을 열고 ODP.NET 참조를 맞춘 뒤 빌드·실행합니다. 환경변수 설정 후에는 Visual Studio를 다시 열어야 합니다.

Oracle 연결·환경변수·빌드 설정은 [실행 상세 안내](docs/running.md)를 참고하세요.

## 현재 상태

원래 개발 코드를 바탕으로 정리한 공개용 자료입니다. Windows·Oracle 환경에서의 빌드와 실제 실행은 재검증하지 않았습니다.

## 관련 문서

- [실행 상세 안내](docs/running.md)
- [코드·DB 구성](docs/structure.md)
- [공개용 정리 내역](docs/publication-notes.md)
