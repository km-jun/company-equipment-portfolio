# 실행 상세 안내

1. Windows에서 Visual Studio와 .NET Framework 4.8 개발 도구를 준비합니다.
2. Oracle DB와 프로젝트에 맞는 ODP.NET을 설치합니다. 기존 프로젝트는 `Oracle.DataAccess` 4.112.2.0 참조를 사용합니다. `project/project.csproj`의 `HintPath`를 설치한 DLL 경로에 맞춰 수정하고, 애플리케이션과 Oracle 클라이언트의 비트 수를 맞춥니다. 기존 Debug 설정은 x64입니다.
3. 별도의 테스트용 DB 계정을 준비하고, 그 계정으로 `pro3.sql`을 실행합니다. 이 파일은 기존 동명 테이블과 VIEW를 삭제하므로 실제 데이터가 있는 스키마에 실행하면 안 됩니다. SQL 파일은 UTF-8입니다.
4. Windows의 사용자 환경변수 설정에서 `EQUIPMENT_DB_CONNECTION_STRING`을 등록합니다. 접속 문자열 형식은 다음과 같습니다. 대괄호 부분은 자신의 로컬 설정으로 교체하고 실제 접속 정보는 저장소에 올리지 않습니다.

```text
User Id=[LOCAL_DB_USER];Password=[LOCAL_DB_PASSWORD];Data Source=[LOCAL_DB_ALIAS];
```

5. 환경변수를 설정한 뒤 Visual Studio를 다시 열어 `project.sln`을 빌드하고 실행합니다.

원본의 기능 코드를 보존한 공개용 자료입니다. 이번 공개 준비 과정에서 Windows·Oracle 환경의 빌드 및 실제 실행은 재검증하지 않았습니다.

[README로 돌아가기](../README.md)
