-- 공개용 SQL: 병력·장비 예제는 가상 데이터입니다. 실제 인명·군번·소속·장비 데이터가 아닙니다.
-- 주의: 이 스크립트는 기존 동명 테이블과 VIEW를 삭제하고 다시 생성합니다. 전용 테스트 스키마에서만 실행하세요.
----------------------------------------------------
-- 0. 기존 객체 정리 (뷰 + 테이블)
----------------------------------------------------
BEGIN EXECUTE IMMEDIATE 'DROP VIEW v_recent_hist'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP VIEW v_active_issue'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP VIEW v_broken_equip'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE issue_history CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE transaction_history CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE soldier CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE equipment CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE position CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE rank CASCADE CONSTRAINTS PURGE'; EXCEPTION WHEN OTHERS THEN NULL; END;
/

----------------------------------------------------
-- 1. RANK 테이블
----------------------------------------------------
CREATE TABLE rank (
    rank_name   VARCHAR2(20) PRIMARY KEY		-- 계급명
);

----------------------------------------------------
-- 2. POSITION 테이블
----------------------------------------------------
CREATE TABLE position (
    position_name   VARCHAR2(50) PRIMARY KEY      -- 보직명
);

----------------------------------------------------
-- 3. EQUIPMENT 테이블
----------------------------------------------------
CREATE TABLE equipment (
    equip_code       VARCHAR2(20)  PRIMARY KEY,   -- 장비코드
    equip_name       VARCHAR2(100) NOT NULL,      -- 장비명
    equip_type       VARCHAR2(50),                -- 장비구분
    equip_status     VARCHAR2(30),                -- 정상/고장/수리중 (UI용)
    status           VARCHAR2(20),                -- READY/OUT/BROKEN/SERVICE
    total_qty        NUMBER        DEFAULT 0,     -- 총 보유수량
    stock_qty        NUMBER        DEFAULT 0,     -- 가용수량
    unit             VARCHAR2(20),                -- 단위
    last_issue_date  DATE,                       -- 최근 지급일
    avail_rate       NUMBER(5,2),                -- 가용률(%)
    remark           VARCHAR2(200)               -- 비고
);

----------------------------------------------------
-- 4. SOLDIER 테이블
----------------------------------------------------
CREATE TABLE soldier (
    soldier_no  VARCHAR2(20) PRIMARY KEY,      -- 내부용 PK(군번)
    name        VARCHAR2(50) NOT NULL,           -- 이름
    rank        VARCHAR2(20) REFERENCES rank(rank_name),                    -- 계급
    unit        VARCHAR2(50),                    -- 소속
    position    VARCHAR2(50) REFERENCES position(position_name)                     -- 보직
);

----------------------------------------------------
-- 5. ISSUE_HISTORY (지급/회수 이력)
----------------------------------------------------
CREATE TABLE issue_history (
    issue_id     NUMBER       PRIMARY KEY,       -- 지급번호
    soldier_no   VARCHAR2(20) REFERENCES soldier(soldier_no),
    equip_code   VARCHAR2(20) REFERENCES equipment(equip_code),
    issue_date   DATE         DEFAULT SYSDATE,
    return_date  DATE
);

----------------------------------------------------
-- 6. TRANSACTION_HISTORY (로그용)
----------------------------------------------------
CREATE TABLE transaction_history (
    trans_id     NUMBER       PRIMARY KEY,
    soldier_no       VARCHAR2(20) REFERENCES soldier(soldier_no),
    equip_code   VARCHAR2(20) REFERENCES equipment(equip_code),
    issue_date   DATE         DEFAULT SYSDATE,
    return_date  DATE
);

----------------------------------------------------
-- 7. 기본 데이터 (장비)
----------------------------------------------------
INSERT INTO equipment VALUES ('DEMO-E001','예시장비01','훈련용','정상','READY',5,5,'개',NULL,100,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E002','예시장비02','훈련용','정상','OUT',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E003','예시장비03','훈련용','고장','BROKEN',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E004','예시장비04','훈련용','수리중','SERVICE',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E005','예시장비05','훈련용','정상','READY',5,5,'개',NULL,100,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E006','예시장비06','훈련용','정상','OUT',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E007','예시장비07','훈련용','고장','BROKEN',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E008','예시장비08','훈련용','수리중','SERVICE',5,0,'개',NULL,0,'공개용 가상 데이터');
INSERT INTO equipment VALUES ('DEMO-E009','예시장비09','훈련용','정상','READY',5,5,'개',NULL,100,'공개용 가상 데이터');


----------------------------------------------------
-- 8. 기본 데이터 (보직)
----------------------------------------------------
INSERT INTO position VALUES ('통신병');
INSERT INTO position VALUES ('소총수');
INSERT INTO position VALUES ('기관총 사수');
INSERT INTO position VALUES ('기관총 부사수');
INSERT INTO position VALUES ('분대장');

----------------------------------------------------
-- 9. 기본 데이터 (계급)
----------------------------------------------------
INSERT INTO rank VALUES ('이병');
INSERT INTO rank VALUES ('일병');
INSERT INTO rank VALUES ('상병');
INSERT INTO rank VALUES ('병장');


----------------------------------------------------
-- 10. 기본 데이터 (병사)
----------------------------------------------------
INSERT INTO soldier VALUES ('DEMO-S001', '예시병사01', '이병', '가상부대', '소총수');
INSERT INTO soldier VALUES ('DEMO-S002', '예시병사02', '일병', '가상부대', '기관총 사수');
INSERT INTO soldier VALUES ('DEMO-S003', '예시병사03', '상병', '가상부대', '기관총 부사수');
INSERT INTO soldier VALUES ('DEMO-S004', '예시병사04', '병장', '가상부대', '분대장');
INSERT INTO soldier VALUES ('DEMO-S005', '예시병사05', '이병', '가상부대', '통신병');

----------------------------------------------------
-- 11. 기본 데이터 (지급/회수 이력)
----------------------------------------------------
INSERT INTO issue_history       VALUES (1,'DEMO-S001','DEMO-E001',SYSDATE-1,NULL);
INSERT INTO issue_history       VALUES (2,'DEMO-S002','DEMO-E009',SYSDATE-3,SYSDATE-1);
INSERT INTO issue_history       VALUES (3,'DEMO-S003','DEMO-E008',SYSDATE-2,NULL);

INSERT INTO transaction_history VALUES (1,'DEMO-S001','DEMO-E001',SYSDATE-1,NULL);
INSERT INTO transaction_history VALUES (2,'DEMO-S002','DEMO-E009',SYSDATE-3,SYSDATE-1);
INSERT INTO transaction_history VALUES (3,'DEMO-S003','DEMO-E008',SYSDATE-2,NULL);

COMMIT;

----------------------------------------------------
-- 12. VIEW 정의 (메인 3개 그리드)
----------------------------------------------------

-- 12-1. 고장/수리중 장비 (dgvBroken)
CREATE OR REPLACE VIEW v_broken_equip AS
SELECT
    equip_code,
    equip_name,
    equip_type,
    equip_status,
    total_qty,
    stock_qty,
    remark
FROM equipment
WHERE status IN ('BROKEN','SERVICE');

----------------------------------------------------

-- 12-2. 지급중 병력(미회수) (dgvActive)
--   ★ C# dgvActive_CellClick 인덱스 순서에 맞춰 컬럼 순서 고정 ★
--   0: issue_id
--   1: soldier_no
--   2: name
--   3: rank
--   4: unit
--   5: equip_code
--   6: equip_name
--   7: issue_date
CREATE OR REPLACE VIEW v_active_issue AS
SELECT
    i.issue_id,
    s.soldier_no,
    s.name,
    s.rank,
    s.unit,
    e.equip_code,
    e.equip_name,
    i.issue_date
FROM issue_history i
JOIN soldier   s ON i.soldier_no = s.soldier_no
JOIN equipment e ON i.equip_code = e.equip_code
WHERE i.return_date IS NULL;

----------------------------------------------------

-- 12-3. 최근 지급·회수 내역 (dgvRecent)
CREATE OR REPLACE VIEW v_recent_hist AS
SELECT
    h.issue_date,
    CASE
        WHEN h.return_date IS NULL THEN '지급'
        ELSE '회수'
    END AS action_type,
    s.soldier_no,
    s.name,
    s.unit,
    e.equip_code,
    e.equip_name,
    h.return_date
FROM transaction_history h
JOIN soldier   s ON h.soldier_no     = s.soldier_no
JOIN equipment e ON h.equip_code = e.equip_code
ORDER BY h.issue_date DESC;
/

----------------------------------------------------
-- END
----------------------------------------------------
